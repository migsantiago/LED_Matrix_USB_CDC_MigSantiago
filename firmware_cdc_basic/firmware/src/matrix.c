/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

#include "matrix.h"

/*-------------------------------------------------------------------
 * Objects
 * ----------------------------------------------------------------*/

extern Matrix_Rotation_T Current_Rotation;

/*-------------------------------------------------------------------
 * Function definitions
 * ----------------------------------------------------------------*/

void Turn_Off_Columns(void)
{
    LAT_COL_0 = 0;
    LAT_COL_1 = 0;
    LAT_COL_2 = 0;
    LAT_COL_3 = 0;
    LAT_COL_4 = 0;
    LAT_COL_5 = 0;
    LAT_COL_6 = 0;
}

void Turn_Off_Rows(void)
{
    LAT_GATE_0 = 0;
    LAT_GATE_1 = 0;
    LAT_GATE_2 = 0;
    LAT_GATE_3 = 0;
    LAT_GATE_4 = 0;
    LAT_GATE_5 = 0;
    LAT_GATE_6 = 0;
}

void Initialize_Matrix(void)
{
    Turn_Off_Columns();
    Turn_Off_Rows();
}

uint8_t* Rotate_Matrix(uint8_t* column_data, Matrix_Rotation_T rotate)
{
    static uint8_t rotated_matrix[MAX_ROWS];
    uint8_t x;
    uint8_t y;

    /* Initialize the rotated matrix */
    for (x = 0; x < MAX_ROWS; ++x)
    {
        rotated_matrix[x] = 0;
    }

    if(rotate == ROTATE_0_DEG)
    {
        for (x = 0; x < MAX_ROWS; ++x)
        {
            rotated_matrix[x] = column_data[x];
        }
    }
    else if(rotate == ROTATE_90_DEG)
    {
        for(x = 0; x < MAX_ROWS; ++x)
        {
            for(y = (MAX_COLUMNS - 1); y != 0xFF; --y)
            {
                /* If the current pixel is set */
                if(column_data[y] & (1 << x))
                {
                    rotated_matrix[x] |= 1 << (MAX_COLUMNS - y - 1);
                }
            }
        }
    }
    else if(rotate == ROTATE_180_DEG)
    {
        /* Invert the order of the rows */
        y = 6;
        for(x = 0; x < MAX_ROWS; ++x)
        {
            rotated_matrix[x] = column_data[y];
            --y;
            /* Mirror the bits */
            Mirror_Bits(&rotated_matrix[x]);
            /* Shift one pixel */
            rotated_matrix[x] >>= 1;
        }        
    }
    else if (rotate == ROTATE_270_DEG)
    {
        for(x = 0; x < MAX_ROWS; ++x)
        {
            for(y = (MAX_COLUMNS - 1); y != 0xFF; --y)
            {
                if(column_data[x] & (1 << y))
                {
                    rotated_matrix[MAX_COLUMNS - y - 1] |= 1 << x;
                }
            }
        }
    }

    return rotated_matrix;
}

void Mirror_Bits(uint8_t* c)
{
    uint8_t i;
    uint8_t mirrored = 0;

    for (i = 0; i < 8; ++i)
    {
        mirrored <<= 1;
        if (*c & 0x01)
        {
            mirrored |= 0x01;
        }
        *c >>= 1;
    }
    *c = mirrored;
}

void Redraw_Matrix(uint8_t* column_data)
{
    static uint8_t current_row = 6;
    uint8_t current_column;
    uint8_t column_state;
    uint8_t* local_matrix;

    /* Rotate the image if needed */
    local_matrix = Rotate_Matrix(column_data, Current_Rotation);

    Turn_Off_Columns();
    Turn_Off_Rows();

    ++current_row;
    if(current_row == MAX_ROWS)
    {
        current_row = 0;
    }

    /* Turn on the next row */
    switch (current_row)
    {
        case 0:
            LAT_GATE_0 = 1;
            break;
        case 1:
            LAT_GATE_1 = 1;
            break;
        case 2:
            LAT_GATE_2 = 1;
            break;
        case 3:
            LAT_GATE_3 = 1;
            break;
        case 4:
            LAT_GATE_4 = 1;
            break;
        case 5:
            LAT_GATE_5 = 1;
            break;
        case 6:
            LAT_GATE_6 = 1;
            break;
        default:
            break;
    }

    /* Load the current column pattern */
    for(current_column = 0; current_column < MAX_COLUMNS; ++current_column)
    {
        column_state = (local_matrix[current_row] & (1 << current_column)) && 1;

        switch(current_column)
        {
            case 0:
                LAT_COL_6 = column_state;
                break;
            case 1:
                LAT_COL_5 = column_state;
                break;
            case 2:
                LAT_COL_4 = column_state;
                break;
            case 3:
                LAT_COL_3 = column_state;
                break;
            case 4:
                LAT_COL_2 = column_state;
                break;
            case 5:
                LAT_COL_1 = column_state;
                break;
            case 6:
                LAT_COL_0 = column_state;
                break;
            default:
                break;
        }
    }
}
