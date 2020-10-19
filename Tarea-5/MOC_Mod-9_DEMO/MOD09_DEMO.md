# Módulo 9: Diseño de la interfaz de usuario para una aplicación gráfica


Fichero de Instrucciones: Instructions\20483C_MOD09_DEMO.md

Entregar el url de GitHub con la solución y un readme con las siguiente información:

1. **Nombres y apellidos:** José René Fuentes Cortez
2. **Fecha:** 14 de Octubre 2020.
3. **Resumen del Modulo 2:** Este módulo consta de tres ejercicios:
    -  En el primer ejercio nos ayuda a actualizar la aplicación para refactorizar el código duplicado en métodos reutilizables.
    - En el ejercicio 2 los datos del estudiante serán validados antes de ser guardados por la aplicación.
    - En el ejercicio 3 hacemos que la aplicación pueda manipular los datos modificados del estudiante para que se  guarden en la base de datos.


4. **Dificultad o problemas presentados y como se resolvieron:** Ninguna.

**NOTA**: Si no hay descripcion de problemas o dificultades, y al yo descargar el código para realizar la comprobacion y el código no funcionar, el resultado de la califaciación del laboratorio será afectado.

---

## Lección 1: Usar XAML para diseñar una interfaz de usuario

### Demostración: uso de la vista Diseño para crear una interfaz de usuario XAML

#### Pasos de preparación

Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Pasos de demostración

1. Abra ** Visual Studio 2017 **.
2. En Visual Studio, en el menú ** Archivo **, seleccione ** Nuevo ** y luego haga clic en ** Proyecto **.
3. En el cuadro de diálogo ** Nuevo proyecto **, en la lista ** Instalado **, haga clic en ** Visual C \ # **, y luego en la lista ** Tipo de proyecto **, haga clic en ** Aplicación WPF ( .NET Framework)**.
4. En el cuadro de texto ** Nombre **, escriba ** DesignView **.
5. En el cuadro de texto ** Ubicación **, establezca la ubicación en ** [Raíz del repositorio] \\ Allfiles \\ Mod09 \\ Democode **, y luego haga clic en ** Aceptar **.
6. En el panel ** XAML **, en el elemento ** Ventana **, cambie el valor del atributo ** Título ** a ** Ordene su café aquí **.
7. Agregue el siguiente marcado entre las etiquetas ** Grid ** de apertura y cierre:
    xml
    <Grid.RowDefinitions>
       <RowDefinition Height = "Auto" />
       <RowDefinition Height = "*" />
    </Grid.RowDefinitions>
    ''
8. Abra el panel ** Caja de herramientas **, expanda ** Controles WPF comunes ** y luego haga doble clic en ** Botón **.
9. En la superficie de diseño, arrastre el botón hacia la parte superior de la pantalla hasta que aparezca un mensaje ** Presione Tab para colocar dentro de la fila 0 **. Presione ** Tab ** y luego suelte el botón.
10. En el panel ** XAML **, en el elemento ** Botón **, cambie el valor del atributo ** Contenido ** a ** ¡Hazme un café! **.
11. Cambie el valor del atributo ** HorizontalAlignment ** a ** Center **.
12. Cambie el valor del atributo ** Ancho ** a ** Auto **.
13. En la ventana ** Propiedades **, asegúrese de que el botón esté seleccionado y, a continuación, en el cuadro de texto ** Nombre **, escriba ** btnGetCoffee **.
14. En el panel ** Caja de herramientas **, haga doble clic en ** Etiqueta **.
15. En la superficie de diseño, arrastre la etiqueta a cualquier lugar de la fila inferior de la ** Cuadrícula **.
16. En el panel ** XAML **, en el elemento ** Etiqueta **, cambie el valor del atributo ** Contenido ** a una cadena vacía.
17. Cambie el valor del atributo ** HorizontalAlignment ** a ** Center **.
18. En la ventana ** Propiedades **, asegúrese de que la etiqueta esté seleccionada y luego, en el cuadro de texto ** Nombre **, escriba ** lblResult **.
19. En la superficie de diseño, haga doble clic en ** Make Me a Coffee! **.
20. Observe que Visual Studio crea automáticamente un método de controlador de eventos y cambia a la página de código subyacente.
21. En el método ** btnGetCoffee_Click **, agregue el siguiente código:
    `` `cs
    lblResult.Content = "Su café está en camino.";
    ''
22. En el menú ** Depurar **, haga clic en ** Iniciar sin depurar **.
23. En la ventana ** Ordene su café aquí **, haga clic en ** ¡Prepáreme un café! **.
24. Observe que la etiqueta muestra un mensaje.
25. Cierre la ventana ** Ordene su café aquí ** y luego cierre Visual Studio.

## Lección 3: Diseñar una interfaz de usuario

### Demostración: personalización de fotografías de estudiantes y diseño del laboratorio de aplicaciones

#### Pasos de preparación

1. Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Inicializar la base de datos:
    - En la ** lista de aplicaciones **, haga clic en ** Explorador de archivos **.
    - En ** Explorador de archivos **, navegue hasta la carpeta ** [Repository Root] \ Allfiles \ Mod09 \ Labfiles \ Databases ** y luego haga doble clic en ** SetupSchoolGradesDB.cmd **.
        > ** Nota: ** Si aparece un cuadro de diálogo de Windows protegió su PC, haga clic en Más información y luego en Ejecutar de todos modos.
    - Cierre ** Explorador de archivos **.

#### Pasos de demostración

1. desde la carpeta ** [Repository Root] \ Allfiles \ Mod09 \ Labfiles \ Solution \ Exercise 3 **, abra la solución ** Grades.sln **.
    > ** Nota: ** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación ** Preguntarme por cada proyecto en esta solución ** y luego haga clic en ** Aceptar **.
2. En ** Explorador de soluciones **, haga clic con el botón derecho en ** "Calificaciones" de la solución ** y, a continuación, haga clic en ** Propiedades **.
3. En la página ** Proyecto de inicio **, haga clic en ** Varios proyectos de inicio **. Establezca ** Grades.Web ** y ** Grades.WPF ** en ** Inicio ** y luego haga clic en ** Aceptar **.
    Explique a los estudiantes que tendrán que realizar este paso cada vez que abran archivos de inicio de laboratorio porque la información del proyecto de inicio se almacena en el archivo de opciones de usuario .suo para una solución que no está incluida en Allfiles para este curso.
4. Construya la solución.
5. En el proyecto ** Grades.WPF **, en la carpeta ** Controles **, abra ** StudentPhoto.xaml **.
6. Revise el marcado XAML y explique a los estudiantes que en el ejercicio 1 del laboratorio, crearán un control de usuario ** StudentPhoto ** y agregarán código para usarlo en la aplicación.
7. En la carpeta ** Vistas **, abra ** StudentsPage.xaml ** y explique a los estudiantes que crearán los elementos ** ItemsControl ** y ** DataTemplate ** en este archivo para alojar la ** StudentPhoto ** control y el botón ** eliminar **.
8. Expanda ** StudentsPage.xaml ** y luego abra ** StudentsPage.xaml.cs ** y busque el evento ** Student_Click **.
9. Explique a los estudiantes que agregarán este código para generar el evento ** StudentSelected ** cuando un usuario haga clic en una fotografía.
10. En la carpeta ** Vistas **, abra ** StudentProfile.xaml **.
11. Localice el elemento ** StudentPhoto ** y explique a los alumnos que agregarán el control de usuario a esta vista.
12. Abra ** LogonPage.xaml ** y explique a los estudiantes que en el ejercicio 2 definirán dos estilos: uno para el botón ** Iniciar sesión ** y otro para el cuadro de texto ** contraseña **. Además, muestre a los estudiantes el marcado donde se aplica el estilo a un control.
13. En la carpeta ** Temas **, abra ** Generic.xaml **. Explique a los estudiantes que aquí definirán propiedades para etiquetas y texto en toda la aplicación.
14. Ejecute la aplicación y señale el estilo de las etiquetas y los cuadros de texto en la página ** Iniciar sesión **.
15. Inicie sesión como ** vallee ** con la contraseña ** contraseña99 **.
16. Mueva el mouse sobre uno de los estudiantes en la lista de estudiantes y señale que la fotografía se anima.
17. Mueva el mouse sobre un botón ** quitar ** y señale que la fotografía se atenúa.
18. Cierre la sesión y luego inicie sesión como ** liyale ** con la contraseña ** contraseña **.
19. Explique que los padres ahora pueden usar la aplicación y revisar las calificaciones de todos sus hijos.
20. Haga clic en el nombre de cada niño por turno y luego cierre la sesión.
21. Cierre la aplicación y luego cierre Visual Studio.

© 2018 Microsoft Corporation. Todos los derechos reservados.

El texto de este documento está disponible bajo la [Licencia Creative Commons Attribution 3.0] (https://creativecommons.org/licenses/by/3.0/legalcode), se pueden aplicar términos adicionales. Todo el resto del contenido de este documento (incluidas, entre otras, marcas comerciales, logotipos, imágenes, etc.) ** no ** está incluido en la concesión de la licencia Creative Commons. Este documento no le proporciona ningún derecho legal sobre la propiedad intelectual de ningún producto de Microsoft. Puede copiar y utilizar este documento para fines internos de referencia.

Este documento se proporciona "tal cual". La información y las opiniones expresadas en este documento, incluidas las URL y otras referencias a sitios web de Internet, pueden cambiar sin previo aviso. Usted asume el riesgo de utilizarlo. Algunos ejemplos son solo ilustrativos y son ficticios. No se pretende ni se infiere ninguna asociación real. Microsoft no ofrece ninguna garantía, expresa o implícita, con respecto a la información proporcionada aquí.