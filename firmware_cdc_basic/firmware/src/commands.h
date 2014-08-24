/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

#ifndef COMMANDS_H
#define	COMMANDS_H

#include "system.h"
#include "matrix.h"

#ifdef	__cplusplus
extern "C" {
#endif

/*-------------------------------------------------------------------
 * Defines
 * ----------------------------------------------------------------*/

#define TIMER_2_PR2                     (250 - 1)
#define TIMER_2_TICKS_PER_S             ((uint16_t)1000)

#define DRAW_TIME_PERIOD                ((uint16_t)2000) /* ms */

/*-------------------------------------------------------------------
 * Typedefs
 * ----------------------------------------------------------------*/

/* List of commands to send to the PIC */
typedef enum PIC_Command_Tag
{
    UNUSED = 0,                 /* Unused */
    DRAW_RAW_FRAME,             /* Draw the sent frame */
    SET_RTC,                    /* Send the current time to the PIC */
    DRAW_A_NUMBER,              /* Draw a number */
    DRAW_TIME,                  /* Draw the current time */
    SET_ROTATION,               /* Set the matrix rotation */
    GAME_OF_LIFE,               /* Play the game of life */
    MAX_COMMANDS
}PIC_Command_T;

/* Structure to hold the time */
typedef struct Time_Tag
{
    uint8_t hour;
    uint8_t minute;
    uint8_t second;
}Time_T;

/*-------------------------------------------------------------------
 * Function prototypes
 * ----------------------------------------------------------------*/

void Update_RTC(void);

void Process_Timer_2_Tick(uint8_t* command, uint8_t* column_data);
void Process_UNUSED(uint8_t* command, uint8_t* column_data);
void Process_DRAW_RAW_FRAME(uint8_t* command, uint8_t* column_data);
void Process_SET_RTC(uint8_t* command, uint8_t* column_data);
void Process_DRAW_A_NUMBER(uint8_t* command, uint8_t* column_data);
void Process_DRAW_TIME(uint8_t* command, uint8_t* column_data);
void Process_SET_ROTATION(uint8_t* command, uint8_t* column_data);
void Process_GAME_OF_LIFE(uint8_t* command, uint8_t* column_data);

#ifdef	__cplusplus
}
#endif

#endif	/* COMMANDS_H */

