#include <stdio.h>
#include <math.h>
#include <stdio>
#include <math>

char a;
int a, b, c, d, radio, i;
float x, y, z;
char w;

void main()
{
    printf("\nHola mundo");
    printf("\n============");
    printf("\nRadio = ");
    scanf("%i");

    radio = (3 + 5) * 8 - (10 - 4) / 2;

    z = (a + b) * c;

    if ((3 + 5) * 8 > z)
    {
        printf("\nEs mayor");
    }

    if (radio % 2 == 0)
    {
        printf("\nRadio es par");
    }
    else
    {
        printf("\nRadio es impar");
    }

    do{
        z += 2;
        printf("\n+1");
    }while ( i < 20 );

    z++;
        
}