# Módulo 10: Mejora del rendimiento y la capacidad de respuesta de las aplicaciones



Fichero de Instrucciones: Instructions\20483C_MOD010_DEMO.md

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

## Lección 2: Realización de operaciones de forma asincrónica

### Demostración: Uso de la biblioteca paralela Tak para invocar operaciones APM

#### Pasos de preparación

1. Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Vaya a ** [Repository Root] \ Allfiles \ Mod10 \ Democode \ Starter ** y luego abra el archivo ** APMTasks.sln **.
    > ** Nota: ** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación ** Preguntarme por cada proyecto en esta solución ** y luego haga clic en ** Aceptar **.

#### Pasos de demostración

1. En el menú ** Crear **, haga clic en ** Crear solución **.
2. En el menú ** Depurar **, haga clic en ** Iniciar sin depurar **.
3. En el cuadro de texto, escriba ** http: //www.fourthcoffee.com** y luego haga clic en ** Comprobar URL **.
   Observe que la etiqueta muestra el mensaje ** La URL devolvió el siguiente código de estado: OK **.
4. Cierre la ventana ** MainWindow **.
5. En ** Explorador de soluciones **, expanda ** MainWindow.xaml ** y, a continuación, haga doble clic en ** MainWindow.xaml.cs **.
6. Revise el código en la clase ** MainWindow **:
    - Observe que el método ** btnCheckUrl_Click ** crea un objeto ** HttpWebRequest ** y luego llama al método ** BeginGetResponse **.
    - Observe que el método ** BeginGetResponse ** especifica el método ** ResponseCallback ** como un método de devolución de llamada asíncrono.
    - Observe que el método ** ResponseCallback ** llama al método ** HttpWebResponse.EndGetResponse ** para obtener el resultado de la solicitud web y luego actualiza la interfaz de usuario.
7. Elimine el método ** ResponseCallback **.
8. Modifique la declaración del método ** btnCheckUrl_Click ** para incluir el modificador ** async ** de la siguiente manera:
    `` `cs
    private async void btnCheckUrl_Click (remitente del objeto, RoutedEventArgs e)
    ''
9. En el método ** btnCheckUrl_Click **, elimine la siguiente línea de código:
    `` `cs
    request.BeginGetResponse (nuevo AsyncCallback (ResponseCallback), solicitud);
    ''
10. Agregue el siguiente código en lugar de la línea que acaba de eliminar:
    `` `cs
    HttpWebResponse response = await Task <WebResponse> .Factory.FromAsync (request.BeginGetResponse, request.EndGetResponse, request) as HttpWebResponse;
    lblResult.Content = String.Format ("La URL devolvió el siguiente código de estado: {0}", response.StatusCode);
    ''
11. Observe que la clase ** MainWindow ** ahora es mucho más simple y concisa.
12. En el menú ** Depurar **, haga clic en ** Iniciar sin depurar **.
13. En el cuadro de texto, escriba ** http: //www.fourthcoffee.com** y luego haga clic en ** Comprobar URL **.
14. Observe que la etiqueta muestra el mensaje ** La URL devolvió el siguiente código de estado: OK **.
15. Observe que la aplicación funciona exactamente igual que antes.
16. Cierre la ventana ** MainWindow ** y, a continuación, cierre Visual Studio.

## Lección 3: Sincronización del acceso concurrente a los datos

### Demostración: uso de declaraciones de bloqueo

#### Pasos de preparación

1. Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navegue a ** [Repository Root] \ Allfiles \ Mod10 \ Democode \ Starter **, y luego abra el archivo ** Locking.sln **.
    > ** Nota: ** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación ** Preguntarme por cada proyecto en esta solución ** y luego haga clic en ** Aceptar **.

#### Pasos de demostración

1. En ** Explorador de soluciones **, haga doble clic en ** Coffee.cs **.
2. Repase la clase ** Café **, prestando especial atención al método ** MakeCoffees **.
3. Observe cómo el método ** MakeCoffees ** usa una declaración ** lock ** para evitar el acceso simultáneo al código crítico.
4. En ** Explorador de soluciones **, haga doble clic en ** Program.cs **.
5. En la clase ** Programa **, revise el método ** Principal **.
6. Observe cómo el método ** Main ** utiliza un bucle ** Parallel.For ** para realizar simultáneamente 100 pedidos de entre uno y 100 cafés.
7. En el menú ** Crear **, haga clic en ** Crear solución **.
8. En el menú ** Depurar **, haga clic en ** Iniciar depuración **.
9. Revise la salida de la ventana de la consola y observe que la aplicación realiza un seguimiento de los niveles de existencias de manera efectiva.
10. Para cerrar la ventana de la consola, presione Entrar.
11. En la clase ** Coffee **, comente la siguiente línea de código:
    `` `cs
    bloqueo (coffeeLock)
    ''
12. En el menú ** Depurar **, haga clic en ** Iniciar depuración **.
13. Observe que la aplicación lanza una excepción con el mensaje ** ¡El stock no puede ser negativo! **
14. Explique que esto se debe al acceso concurrente a la sección de código crítico en el método ** MakeCoffees **.
15. En el menú ** Depurar **, haga clic en ** Detener depuración **.
16. Cierre Visual Studio.

### Demostración: mejora de la capacidad de respuesta y el rendimiento del laboratorio de aplicaciones

#### Pasos de preparación

Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Pasos de demostración

1. Abra la solución ** Grades.sln ** de la carpeta ** [Repository Root] \ Allfiles \ Mod10 \ Labfiles \ Solution \ Exercise 2 **.
    > ** Nota: ** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación ** Preguntarme por cada proyecto en esta solución ** y luego haga clic en ** Aceptar **.
2. En el Explorador de soluciones, haga clic con el botón derecho en ** Solución "Calificaciones" ** y luego haga clic en ** Propiedades **.
3. En la página ** Proyecto de inicio **, haga clic en ** Varios proyectos de inicio **. Establezca ** Grades.Web ** y ** Grades.WPF ** en ** Inicio ** y luego haga clic en ** Aceptar **.
4. Construya la solución.
5. En el proyecto ** Grades.WPF **, expanda ** MainWindow.xaml ** y luego abra ** MainWindow.xaml.cs ** y luego busque el método ** Refresh **.
6. Explique a los alumnos que durante el Ejercicio 1, convertirán el método ** Refresh ** en un método ** async **.
7. En el método ** Refresh **, en el bloque ** caso "Teacher" **, ubique la llamada a ** utils.GetTeacher **.
8. Explique a los estudiantes que convertirán el método ** GetTeacher ** en un método que se pueda esperar, de modo que espere a que el método regrese sin bloquear el hilo de la interfaz de usuario.
9. En la instrucción que llama a ** utils.GetTeacher **, haga clic con el botón derecho en ** GetTeacher ** y luego haga clic en ** Ir a definición **.
10. Explique que para que el método ** GetTeacher ** sea esperado, los estudiantes deben:
    - Convierta ** GetTeacher ** en un método ** asíncrono **.
    - Cambie el tipo de retorno del método de ** Profesor ** a ** Tarea \ <Profesor \> **.
    - Utilice una tarea para ejecutar la consulta LINQ.
    - Utilice un operador ** en espera ** para obtener el resultado de la consulta.
11. En la carpeta ** Vistas **, expanda ** StudentsPage.xaml ** y luego abra ** StudentsPage.xaml.cs **, y luego busque el método ** Refresh **.
12. En el método ** Refresh **, ubique la llamada a ** utils.GetStudentsByTeacher **.
13. Explique a los estudiantes que convertirán el método ** GetStudentsByTeacher ** en un método asincrónico que usa un método de devolución de llamada para actualizar la interfaz de usuario.
14. En la declaración que llama a ** utils.GetStudentsByTeacher **, haga clic con el botón derecho en ** GetStudentsByTeacher ** y luego haga clic en ** Ir a definición **.
15. Explique a los estudiantes que usarán una tarea para ejecutar la consulta LINQ, usarán un operador ** await ** para obtener el resultado de la consulta y luego pasarán los resultados como un argumento al método de devolución de llamada.
16. En ** StudentsPage.xaml.cs **, ubique el método ** OnGetStudentsByTeacherComplete **.
17. Explique a los estudiantes que este es el método de devolución de llamada y muestre cómo usa un objeto ** Dispatcher ** para actualizar la interfaz de usuario.
18. En la carpeta ** Controls **, abra el archivo ** BusyIndicator.xaml **.
19. Explique a los estudiantes que durante el ejercicio 2 crearán este control de usuario.
20. Preste atención al control ** ProgressBar **, que muestra una animación simple siempre que el control está visible, y al código XAML que crea el control.
21. Abra el archivo ** MainWindow.xaml **, localice el elemento ** BusyIndicator ** y luego señale que la visibilidad del control se establece inicialmente en ** Collapsed **.
22. En ** MainWindow.xaml.cs **, localice los métodos de control de eventos ** StartBusy ** y ** EndBusy **. Señale que el método ** StartBusy ** hace que el control ** BusyIndicator ** sea visible y el método ** EndBusy ** oculta el control ** BusyIndicator **.
23. Abra el archivo ** StudentsPage.xaml.cs ** y luego señale lo siguiente:
    - Los eventos ** StartBusy ** y ** EndBusy **.
    - El método ** StartBusyEvent ** que genera el evento ** StartBusy **.
    - El método ** EndBusyEvent ** que genera el evento ** EndBusy **.
24. Busque el método ** Actualizar **.
25. Señale que el método genera el evento ** StartBusy ** antes de la llamada a ** GetStudentsByTeacher **.
26. Señale que el método genera el evento ** EndBusy ** después de la llamada a ** GetStudentsByTeacher **.
27. En el archivo ** MainWindow.xaml **, busque el elemento ** StudentsPage **.
28. Explique que los eventos ** StartBusy ** y ** EndBusy ** están conectados a los métodos de manejo de eventos ** StartBusy ** y ** EndBusy ** respectivamente.
29. Ejecute la aplicación y luego inicie sesión como ** vallee ** con la contraseña ** contraseña99 **.
30. Señale que la aplicación muestra el control ** BusyIndicator ** mientras espera que se cargue la lista de estudiantes.
31. Haga clic en ** Cerrar sesión ** y luego cierre la aplicación.
32. Cierre ** Visual Studio ** y en el cuadro de diálogo de Microsoft Visual Studio, haga clic en ** Sí **.

© 2018 Microsoft Corporation. Todos los derechos reservados.

El texto de este documento está disponible bajo la [Licencia Creative Commons Attribution 3.0] (https://creativecommons.org/licenses/by/3.0/legalcode), se pueden aplicar términos adicionales. Todo el resto del contenido de este documento (incluidas, entre otras, marcas comerciales, logotipos, imágenes, etc.) ** no ** está incluido en la concesión de la licencia Creative Commons. Este documento no le proporciona ningún derecho legal sobre la propiedad intelectual de ningún producto de Microsoft. Puede copiar y utilizar este documento para fines internos de referencia.

Este documento se proporciona "tal cual". La información y las opiniones expresadas en este documento, incluidas las URL y otras referencias a sitios web de Internet, pueden cambiar sin previo aviso. Usted asume el riesgo de utilizarlo. Algunos ejemplos son solo ilustrativos y son ficticios. No se pretende ni se infiere ninguna asociación real. Microsoft no ofrece ninguna garantía, expresa o implícita, con respecto a la información proporcionada aquí.