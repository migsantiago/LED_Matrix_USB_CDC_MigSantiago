/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

#include "commands.h"
#include "stdlib.h"

/*-------------------------------------------------------------------
 * Local Defines
 * ----------------------------------------------------------------*/
#define CMD_GAME_LIFE_WIDTH                 (7)
#define CMD_GAME_LIFE_HEIGHT                (7)
#define CMD_GAME_LIFE_MS                    (1000) /* ms */

/*-------------------------------------------------------------------
 * Objects
 * ----------------------------------------------------------------*/

/* Number matrix */
static const uint8_t Matrix_Numbers[10][5] =
{
    {0x07, 0x05, 0x05, 0x05, 0x07}, /* 0 */
    {0x01, 0x03, 0x01, 0x01, 0x01}, /* 1 */
    {0x07, 0x01, 0x07, 0x04, 0x07}, /* 2 */
    {0x07, 0x01, 0x07, 0x01, 0x07}, /* 3 */
    {0x05, 0x05, 0x07, 0x01, 0x01}, /* 4 */
    {0x07, 0x04, 0x07, 0x01, 0x07}, /* 5 */
    {0x07, 0x04, 0x07, 0x05, 0x07}, /* 6 */
    {0x07, 0x01, 0x01, 0x01, 0x01}, /* 7 */
    {0x07, 0x05, 0x07, 0x05, 0x07}, /* 8 */
    {0x07, 0x05, 0x07, 0x01, 0x01}, /* 9 */
};

/* Current time */
Time_T Current_Time = {0, 0, 0};

/* What the current command is */
extern PIC_Command_T Current_Command;

/* What is the current matrix rotation */
Matrix_Rotation_T Current_Rotation = ROTATE_0_DEG;

/*-------------------------------------------------------------------
 * Local Function prototypes
 * ----------------------------------------------------------------*/
static inline bool Game_Of_Life_Get_Cell(int8_t x, int8_t y, uint8_t* cells);
static inline void Game_Of_Life_Set_Cell(int8_t x, int8_t y, uint8_t* cells, bool value);

/*-------------------------------------------------------------------
 * Function definitions
 * ----------------------------------------------------------------*/

void Update_RTC(void)
{
    static uint16_t ticks = 0;

    /* A ms has passed */
    ++ticks;

    if(TIMER_2_TICKS_PER_S == ticks)
    {
        /* A second has passed */
        ticks = 0;
        //LAT_USB_LED++;

        ++Current_Time.second;

        if(60 == Current_Time.second)
        {
            Current_Time.second = 0;
            ++Current_Time.minute;

            if(60 == Current_Time.minute)
            {
                Current_Time.minute = 0;
                ++Current_Time.hour;

                if(24 == Current_Time.hour)
                {
                    Current_Time.hour = 0;
                }
            }
        }
    }
}

void Process_Timer_2_Tick(uint8_t* command, uint8_t* column_data)
{
    static uint16_t game_of_life_ticks = 0;

    (void)command;
    PIR1bits.TMR2IF = 0;

    Update_RTC();

    switch(Current_Command)
    {
        case DRAW_TIME:
            Process_DRAW_TIME(NULL, column_data);
            break;
        case GAME_OF_LIFE:
           ++game_of_life_ticks;
           if(CMD_GAME_LIFE_MS == game_of_life_ticks)
           {
              game_of_life_ticks = 0;
              Process_GAME_OF_LIFE(NULL, column_data);
           }
           break;
        default:
            break;
    }
}

void Process_UNUSED(uint8_t* command, uint8_t* column_data)
{
    (void)command;
    (void)column_data;
}

void Process_DRAW_RAW_FRAME(uint8_t* command, uint8_t* column_data)
{
    int i;

    /* Copy 7 rows */
    for (i = 1; i < (MAX_ROWS + 1); ++i)
    {
        column_data[i - 1] = command[i];
    }
}

void Process_SET_RTC(uint8_t* command, uint8_t* column_data)
{
    Current_Time.hour = command[1];
    Current_Time.minute = command[2];
    Current_Time.second = command[3];

    (void)column_data;
}

void Process_DRAW_A_NUMBER(uint8_t* command, uint8_t* column_data)
{
    int i;

    /* Copy 5 rows */
    for (i = 0; i < MAX_ROWS - 2; ++i)
    {
        /* Copy data for the requested number */
        column_data[i] = Matrix_Numbers[command[1]][i];
    }
    column_data[5] = 0;
    column_data[6] = 0;
}

void Process_DRAW_TIME(uint8_t* command, uint8_t* column_data)
{
    static uint16_t ticks = 0;
    static uint8_t draw_hour = true;
    int i;
    uint8_t temp_hour;

    if(0 == Current_Time.hour)
    {
       temp_hour = 12;
    }
    else if(Current_Time.hour > 12)
    {
        temp_hour = Current_Time.hour - 12;
    }
    else
    {
        temp_hour = Current_Time.hour;
    }

    (void)command;

    ++ticks;
    if(DRAW_TIME_PERIOD == ticks)
    {
        ticks = 0;

        if(draw_hour)
        {
            draw_hour = false;

            if(temp_hour < 10)
            {
                /* Copy 5 rows of the hour */
                for (i = 0; i < MAX_ROWS - 2; ++i) {
                    /* Copy data for the requested hour starting from the second row */
                    column_data[i + 1] = Matrix_Numbers[temp_hour][i] << 2;
                }
            }
            else
            {
                /* Copy 5 rows of the hour (ten) */
                for (i = 0; i < MAX_ROWS - 2; ++i)
                {
                    /* Copy data for the hour (always 1) starting from the second row */
                    column_data[i + 1] = Matrix_Numbers[1][i] << 5;
                }
                /* Copy 5 rows of the hour (units) */
                for (i = 0; i < MAX_ROWS - 2; ++i)
                {
                    /* Copy data for the hour (unit) starting from the second row */
                    column_data[i + 1] |= Matrix_Numbers[temp_hour - 10][i] << 1;
                }
            }
            /* Add a colon */
            column_data[2] |= 0x01;
            column_data[4] |= 0x01;
        }
        else
        {
            draw_hour = true;

            /* Copy 5 rows of the minutes (ten) */
            for (i = 0; i < MAX_ROWS - 2; ++i)
            {
                /* Copy data for the minute (always 1) starting from the second row */
                column_data[i + 1] = Matrix_Numbers[Current_Time.minute / 10][i] << 4;
            }
            /* Copy 5 rows of the minutes (units) */
            for (i = 0; i < MAX_ROWS - 2; ++i)
            {
                /* Copy data for the minute (unit) starting from the second row */
                column_data[i + 1] |= Matrix_Numbers[Current_Time.minute % 10][i];
            }
        }

        /* Clear the first and last rows */
        column_data[0] = 0;
        column_data[6] = 0;
    }
}

void Process_SET_ROTATION(uint8_t* command, uint8_t* column_data)
{
    (void)column_data;

    Current_Rotation = command[1];
}

void Process_GAME_OF_LIFE(uint8_t* command, uint8_t* column_data)
{
   static bool initialized = false;
   int8_t x;
   int8_t y;
   static uint8_t cells[CMD_GAME_LIFE_HEIGHT] = {0};
   uint8_t new_cells[CMD_GAME_LIFE_HEIGHT] = {0};
   uint8_t neighbors;
   bool cell;

   if(!initialized)
   {
      /* Get the time and use it to populate the cells */
      srand(((uint16_t)Current_Time.minute << 8) | (uint16_t)Current_Time.second);
      for(y = 0; y < CMD_GAME_LIFE_HEIGHT; ++y)
      {
         cells[y] = rand();
         new_cells[y] = cells[y];
      }
      initialized = true;
   }

   /* Analyze each cell and determine their new state */
   for(y = 0; y < CMD_GAME_LIFE_HEIGHT; ++y)
   {
      for(x = 0; x < CMD_GAME_LIFE_WIDTH; ++x)
      {
         neighbors = 0;

         /* Top right */
         if(Game_Of_Life_Get_Cell(x - 1, y - 1, cells))
         {
            ++neighbors;
         }
         /* Top middle */
         if(Game_Of_Life_Get_Cell(x, y - 1, cells))
         {
            ++neighbors;
         }
         /* Top left */
         if(Game_Of_Life_Get_Cell(x + 1, y - 1, cells))
         {
            ++neighbors;
         }
         /* Right */
         if(Game_Of_Life_Get_Cell(x - 1, y, cells))
         {
            ++neighbors;
         }
         /* Left */
         if(Game_Of_Life_Get_Cell(x + 1, y, cells))
         {
            ++neighbors;
         }
         /* Bottom right */
         if(Game_Of_Life_Get_Cell(x - 1, y + 1, cells))
         {
            ++neighbors;
         }
         /* Bottom middle */
         if(Game_Of_Life_Get_Cell(x, y + 1, cells))
         {
            ++neighbors;
         }
         /* Bottom left */
         if(Game_Of_Life_Get_Cell(x + 1, y + 1, cells))
         {
            ++neighbors;
         }

         /* Get the value of the cell itself */
         cell = Game_Of_Life_Get_Cell(x, y, cells);

         /* Alive */
         if(cell)
         {
            if((2 != neighbors) && (3 != neighbors))
            {
               Game_Of_Life_Set_Cell(x, y, new_cells, false);
            }
         }
         /* Dead */
         else
         {
            if(3 == neighbors)
            {
               /* It takes three to give birth! */
               Game_Of_Life_Set_Cell(x, y, new_cells, true);
            }
         }
      }
   }

   /* new_cells now contains the new stage of the cells */
   for(y = 0; y < CMD_GAME_LIFE_HEIGHT; ++y)
   {
      cells[y] = new_cells[y];
      column_data[y] = new_cells[y];
   }

   /* If all cells died, re-start the game */
   x = 0;
   for(y = 0; y < CMD_GAME_LIFE_HEIGHT; ++y)
   {
      x |= cells[y];
      if(x)
      {
         break;
      }
   }
   if(!x)
   {
      initialized = false;
   }
}

static inline bool Game_Of_Life_Get_Cell(int8_t x, int8_t y, uint8_t* cells)
{
   if((x >= 0) && (y >= 0) && (x < CMD_GAME_LIFE_WIDTH) && (y < CMD_GAME_LIFE_HEIGHT))
   {
      return (cells[y] & (1 << x));
   }
   else
   {
      return false;
   }
}

static inline void Game_Of_Life_Set_Cell(int8_t x, int8_t y, uint8_t* cells, bool value)
{
   if(value)
   {
      cells[y] |= (1 << x);
   }
   else
   {
      cells[y] &= ~(1 << x);
   }
}
