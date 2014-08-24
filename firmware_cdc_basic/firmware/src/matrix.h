/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

#ifndef MATRIX_H
#define	MATRIX_H

#ifdef	__cplusplus
extern "C" {
#endif

#include "stdint.h"
#include "system.h"

/*-------------------------------------------------------------------
 * Typedefs
 * ----------------------------------------------------------------*/

typedef enum Matrix_Rotation_Tag
{
    ROTATE_0_DEG = 0,
    ROTATE_90_DEG,
    ROTATE_180_DEG,
    ROTATE_270_DEG
}Matrix_Rotation_T;

/*-------------------------------------------------------------------
 * Function prototypes
 * ----------------------------------------------------------------*/

void Turn_Off_Columns(void);
void Turn_Off_Rows(void);
void Initialize_Matrix(void);
void Mirror_Bits(uint8_t* c);
void Redraw_Matrix(uint8_t* column_data);
uint8_t* Rotate_Matrix(uint8_t* column_data, Matrix_Rotation_T rotate);


#ifdef	__cplusplus
}
#endif

#endif	/* MATRIX_H */
