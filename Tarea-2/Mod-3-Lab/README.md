# Laboratorio Módulo 3 - Desarrollo del código para una aplicación gráfica

## Lab: Escribir el código para la aplicación del prototipo de grados

Tiempo estimado: **90 minutos**

Fichero de Instrucciones: Instructions\20483C_MOD03_LAK.md

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

### Configuración del Lab

Asegúrate de que has clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)


### Ejercicio 1: Añadiendo la lógica de navegación a la aplicación del prototipo de grados

#### Tarea 1: Examinar la ventana y las vistas en la aplicación

1. Haga clic en **Visual Studio 2017**.
2. En **Estudio Visual**, en el menú **Archivo**, apunta a **Abrir**, y luego haz clic en **Proyecto/Solución**.
3. 3. En el cuadro de diálogo **Abrir Proyecto**, apunta a **[Raíz del Repositorio]\N-Todos los Archivos\NMod03\N-Labfiles\N-Ejercicio 1**, haz clic en **GradesPrototype.sln**, y luego haz clic en **Abrir**.
   >**Nota :** Si aparece cualquier cuadro de diálogo de advertencia de seguridad, desactive la casilla **Ask me for each project in this solution** y luego haga clic en **OK**.
4. En el menú **Construir**, haga clic en **Construir la solución**.
5. 5. En **Solution Explorer**, expandir **GradesPrototype**, y luego hacer doble clic en **MainWindow.xaml**.
6. Tenga en cuenta que esta es la ventana principal de la aplicación que albergará las siguientes vistas:
   - **LogonPage.xaml**
   - **Perfil del estudiante.xaml**
   - **StudentsPage.xaml**
7. En **Solution Explorer**, expandir **Views**, y luego hacer doble clic en **LogonPage.xaml**.
8. Note que esta vista contiene cajas de texto para el nombre de usuario y la contraseña, una caja de verificación para identificar al usuario como profesor, y un botón para iniciar la sesión de la aplicación.
9. En **Solution Explorer**, haga doble clic en **StudentProfile.xaml**.
10. Observe que esta vista contiene un boletín de notas que actualmente muestra una lista de notas ficticias. La vista también contiene un botón **Atrás** y un espacio en blanco que mostrará el nombre del estudiante. Esta vista se muestra cuando un estudiante se conecta o cuando un profesor ve el perfil de un estudiante.
11. En **Explorador de soluciones**, haga doble clic en **PáginaEstudiantes.xaml**.
12. Note que esta vista contiene la lista de estudiantes de una clase en particular. Esta vista se muestra cuando un profesor se conecta. Un profesor puede hacer clic en el nombre de un estudiante y se mostrará la vista **Perfil del estudiante**, que contiene los datos del estudiante seleccionado.

#### Tarea 2: Definir el evento LogonSuccess y añadir un código falso para el evento Logon_Click

1. En el menú **Ver**, haga clic en **Lista de tareas**.
2. 2. En la ventana **Task List**, elija la opción **Entire Solution** de la lista de la izquierda.
3. 3. Haga doble clic en el **TODO: Ejercicio 1: Tarea 2a: Definir la tarea del manejador de eventos LogonSuccess**.
4. 4. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    evento público EventHandler LogonSuccess;
    ```
5. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 1: Tarea 2b: Implementar el manejador de eventos Logon_Click para la tarea Logon button**.
6. 6. En el editor de códigos, haga clic en la línea en blanco debajo de los comentarios, y luego escriba el siguiente código:
    ```cs
    vacío privado Logon_Click(object sender, RoutedEventArgs e)
    {
        // Guarda el nombre de usuario y la función (tipo de usuario) especificados en el formulario en el contexto global
        SessionContext.UserName = nombre de usuario.Texto;
        SessionContext.UserRole = (bool)userrole.IsChecked ? Rol.Profesor : Rol.Estudiante;

        // Si el rol es Estudiante, establece la propiedad CurrentStudent en el contexto global a un estudiante ficticio; Eric Gruber
        si (SessionContext.UserRole == Role.Student)
        {
            Contexto de la sesión. Estudiante actual = "Eric Gruber";
        }

        // Subir el evento LogonSuccess
        si (LogonSuccess != null)
        {
            LogonSuccess(esto, nulo);
        }
    }
    ```
7. En **Solution Explorer**, haga doble clic en **LogonPage.xaml**.
8. En el editor XAML, localice la tarea **TODO: Ejercicio 1: Tarea 2c: Especificar que el botón Logon debe levantar el manejador de eventos Logon_Click en la tarea de esta vista**.
9. En la línea debajo del comentario, modifique el marcado de XAML
    "xml
    <Button Grid.Row="3" Grid.ColumnSpan="2" VerticalAlignment="Center" HorizontalAlignment="Center" Content="Log on" FontSize="24" \>
    ```
    para que se vea como el siguiente marcado:
    "xml
    <Button Grid.Row="3" Grid.ColumnSpan="2" VerticalAlignment="Center" HorizontalAlignment="Center" Content="Log on" FontSize="24" Click="Logon_Click" />
    ```


#### Tarea 3: Añadir código para mostrar la vista de inicio de sesión

1. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Ejercicio 1: Tarea 3a: Mostrar la vista de inicio de sesión y ocultar la lista de estudiantes y la tarea de la vista de un solo estudiante**.
2. 2. En el editor de códigos, haga clic en la línea en blanco del método **GotoLogon**, y luego escriba el siguiente código:
    ```cs
    // Mostrar la vista de inicio de sesión y ocultar la lista de estudiantes y la vista de un solo estudiante
    logonPage.Visibility = Visibilidad.Visible;
    estudiantesPágina.Visibilidad = Visibilidad.Colapsada;
    perfilestudiante.Visibilidad = Visibilidad.Colapsado;
    ```
3. En la ventana **Task List**, haga doble clic en la tarea **TODO: Ejercicio 1: Tarea 3b: Manejar la tarea de inicio de sesión exitoso**.
4. 4. En el editor de códigos, haga clic en la línea en blanco debajo de los comentarios, y luego escriba el siguiente código:
    ```cs
    // Manejar el inicio de sesión con éxito
    vacío privado Logon_Success(object sender, EventArgs e)
    {
        // Actualizar la pantalla y mostrar los datos del usuario conectado
        logonPage.Visibility = Visibilidad.Colapsado;
        gridLoggedIn.Visibility = Visibilidad.Visible;
        Actualizar;
    }
    ```
5. En **Solution Explorer**, haga doble clic en **MainWindow.xaml**.
6. En el editor XAML, localice la tarea **TODO: Ejercicio 1: Tarea 3c: 7. Captura el evento LogonSuccess y llama al manejador de eventos Logon_Success (a ser creado)** tarea.
7. En la línea debajo del comentario, modifique la marca XAML
    "xml
    <y:LogonPage x:Name="logonPage" Visibility="Collapsed" />
    ```
    para que se vea como el siguiente marcado:
    "xml
    <y:LogonPage x:Name="logonPage" LogonSuccess="Logon_Success" Visibility="Collapsed" />
    ```

#### Tarea 4: Añadir código para determinar el tipo de usuario

1. En la ventana **Task List**, haga doble clic en la tarea **TODO: Ejercicio 1: Tarea 4a: Actualizar la pantalla para el usuario conectado (estudiante o profesor)**.
2. 2. En el editor de códigos, haga clic en la línea en blanco en el método **Refrescar**, y luego escriba el siguiente código:
    ```cs
    switch (SessionContext.UserRole)
    {
        caso Role. Estudiante:
            // Mostrar el nombre del estudiante en el banner de la parte superior de la página
            txtName.Text = string.Format("Welcome {0}", SessionContext.UserName);

            // Mostrar los detalles del estudiante actual
            GotoStudentProfile();
            romper;

        caso Role.Teacher:
            // Mostrar el nombre del profesor en el banner de la parte superior de la página
            txtName.Text = string.Format("Welcome {0}", SessionContext.UserName);

            // Mostrar la lista de estudiantes para el profesor
            GotoStudentsPage();
            romper;
    }
    ```
3. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 1: Tarea 4b: Mostrar los detalles de una tarea de un solo estudiante**.
4. 4. En el editor de códigos, haga clic en la línea en blanco del método **GotoStudentProfile**, y luego escriba el siguiente código:
    ```cs
    // Ocultar la lista de estudiantes
    estudiantesPágina.Visibilidad = Visibilidad.Colapsado;

    // Mostrar la vista para un solo estudiante
    Perfil del estudiante. Visibilidad = Visibilidad. Visible;
    studentProfile.Refresh();
    ```
5. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 1: Tarea 4c: Mostrar la lista de estudiantes** tarea.
6. 6. En el editor de códigos, haga clic en la línea en blanco del método **GotoStudentsPage**, y luego escriba el siguiente código:
    ```cs
    // Ocultar la vista para un solo estudiante (si es visible)
    Perfil del estudiante. Visibilidad = Visibilidad. Colapsado;

    // Mostrar la lista de estudiantes
    estudiantesPágina.Visibilidad = Visibilidad.Visible;
    estudiantesPágina.Actualizar();
    ```
7. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 1: Tarea 4d: Muestra los detalles del estudiante actual incluyendo las calificaciones de la tarea del estudiante**.
8. 9. En el editor de códigos, haga clic en la línea en blanco en el método **Refrescar**, y luego escriba el siguiente código:
    ```cs
    // Analizar el nombre del estudiante en el nombre y el apellido usando una expresión regular
    // El nombre es la cadena inicial hasta el primer espacio.
    // El apellido es la cadena después del espacio
    Match MatchNames = Regex.Match(SessionContext.CurrentStudent, @"([^ ]+) ([^ ]+)");

    si (matchNames.Success)
    {
        cadena firstName = matchNames.Groups[1].Value; // La indexación en la colección de Grupos comienza en 1, no en 0
        cadena apellido = coincidencia de nombres. Grupos[2]. Valor;

        // Mostrar el nombre y el apellido en los controles del Bloque de Texto en el StackPanel del estudiante.
        ((TextBlock)nombredeestudiante.Niños[0]).Texto = nombre de pila;
        ((Bloque de texto) nombre de estudiante. Niños[1]). Texto = apellido;
    }

    // Si el usuario actual es un estudiante, oculta el botón Atrás.
    // (sólo aplicable a los profesores que pueden usar el botón de retroceso para volver a la lista de estudiantes)
    si (SessionContext.UserRole == Role.Student)
    {
        btnBack.Visibilidad = Visibilidad.Oculta;
    }
    más
    {
        btnBack.Visibility = Visibilidad.Visible;
    }
    ```


#### Tarea 5: Manejar el evento Student_Click

1. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 1: Tarea 5a: Manejar el evento de clic para una tarea de un estudiante**.
2. 2. En el editor de códigos, haga clic en la línea en blanco del método **Student_Click**, y luego escriba el siguiente código:
    ```cs
    Botón itemClick = remitente como Botón;
    si (itemClick != null)
    {
        // Averigua qué estudiante fue pulsado - la propiedad de la etiqueta del botón contiene el nombre
        cadena estudianteNombre = (cadena)elementoClick.Tag;
        if (StudentSelected != null)
        {
            // Subir el evento StudentSelected (manejado por MainWindow) para mostrar los detalles de este estudiante
            StudentSelected(remitente, nuevo StudentEventArgs(nombredelestudiante));
        }
    }
    ```
3. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 1: Tarea 5b: Manejar el evento StudentSelected cuando el usuario hace clic en un estudiante de la tarea de la página de Estudiantes**.
4. 4. En el editor de códigos, haga clic en la línea en blanco del método **studentsPage_StudentSelected**, y luego escriba el siguiente código:
    ```cs
    Contexto de la sesión. Estudiante actual = e.Niño;
    GotoStudentProfile();
    ```
5. En **Solution Explorer**, haga doble clic en **MainWindow.xaml**.
6. En el editor XAML, localice la tarea **TODO: Ejercicio 1: Tarea 5c: Atrapa el evento StudentSelected y llama a la tarea del manejador de eventos StudentsPage_StudentSelected.
7. En la línea debajo del comentario, modifica la marca XAML
    "xml
    <y:Página de estudiantes x:Nombre="página de estudiantes" Visibilidad="Colapsado" />
    ```
    para que se vea como el siguiente marcado:
    "xml
    <y:EstudiantesPágina x:Nombre="estudiantesPágina" StudentSelected="estudiantesPágina_EstudiantesSeleccionados" Visibility="Colapsado" />
    ```

#### Tarea 6: Construir y probar la aplicación

1. En el menú **Construir**, haga clic en **Construir solución**.
2. En el menú **Debug**, haga clic en **Iniciar sin depuración**.
3. 3. Cuando la aplicación se cargue, en el cuadro de texto **Nombre de usuario**, escriba **vallee**, y en el cuadro de texto **Contraseña**, escriba **contraseña**.
4. 4. Selecciona la casilla **Profesor**, y luego haz clic en **Entrar en**.
5. 5. Verifique que la aplicación muestre la vista **PáginaEstudiante**.
    ![alt text](./Imágenes/20483C_03_StudentsPage.png "La página de los estudiantes")
6. Haga clic en el estudiante **Kevin Liu** y verifique que la aplicación muestra la vista **Perfil del estudiante**.
    ![alt text](./Imágenes/20483C_03_Perfil del EstudianteKevinLiu.png "La página del perfil del estudiante")
7. Haga clic en **Log off**.
8. En el cuadro de texto **Nombre de usuario**, borre el contenido existente, y luego escriba **grubere**.
9. 9. Despeja la casilla de verificación **Profesor**, y luego haz clic en **Entrar en**.
10. 10. Verifique que la aplicación muestra la página de perfil del estudiante para **Eric Gruber**.
11. 11. Cierre la aplicación.
12. En el menú **Archivo**, haga clic en **Cerrar solución**.

>**Resultado:** Después de completar este ejercicio, debería haber actualizado la aplicación **Prototipo de Grades** para responder a los eventos del usuario y moverse entre las vistas de la aplicación de forma adecuada.

### Ejercicio 2: Creación de tipos de datos para almacenar información de usuario y de grado

#### Tarea 1: Definir las estructuras básicas para mantener la información del grado, del estudiante y del profesor.

1. En **Estudio Visual**, en el menú **Archivo**, apunte a **Abrir**, y luego haga clic en **Proyecto/Solución**.
2. 2. En el cuadro de diálogo **Abrir Proyecto**, apunta a **[Raíz del Repositorio]\N-Todos los Archivos\NMod03\N-Labfiles\N-Ejercicio 2**, apunta a **GradesPrototype.sln**, y luego haz clic en **Abrir**.
   >**Nota :** Si aparece cualquier cuadro de diálogo de advertencia de seguridad, desactive la casilla **Ask me for each project in this solution** y luego haga clic en **OK**.
3. En el menú **Ver**, haga clic en **Lista de tareas**.
4. 4. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 2: Tarea 1a: Crear la tarea de la estructura de grados**.
5. 5. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    estructura pública Grado
    {
        public int StudentID { get; set; }
        public string AssessmentDate { get; set; }
        public string SubjectName { get; set; }
        public string Assessment { get; set; }
        public string Comentarios { get; set; }
    }
    ```
6. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 2: Tarea 1b: Crear la tarea de la estructura del estudiante**.
7. 7. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    estructura pública Estudiante
    {
        public int StudentID { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    ```
8. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 2: Tarea 1c: Crear la tarea de la estructura del profesor**.
9. 9. En el editor de códigos, haga clic al final de la línea de comentarios, presione Enter, y luego escriba el siguiente código:
    ```cs
    estructura pública Maestro
    {
        Public int TeacherID { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        cadena pública { get; set; }
    }
    ```


#### Tarea 2: Examinar la fuente de datos ficticia utilizada para poblar las colecciones

1. En **Solution Explorer**, expandir **GradesPrototype**, expandir **Data**, y luego hacer doble clic en **DataSource.cs**.
2. 2. En el editor de código, expande la región **Datos de Muestra**, y luego localiza el método **CrearDatos**.
3. Note cómo la **Lista de Matriz de Maestros** está poblada con datos **Maestros**, cada uno de los cuales contiene los campos **TeacherID**, **Nombre de Usuario**, **Contraseña**, **Sobrenombre**, **Apellido**, y **Clase**.
4. Observe cómo la **Lista de Arreglo de Estudiantes** se llena con datos de **Estudiante**, cada uno de los cuales contiene los campos **StudentID**, **UserName**, **Password**, **TeacherID**, **FirstName**, y **LastName**.
5. Observe cómo la **Grades ArrayList** se completa con datos de **Grade**, cada uno de los cuales contiene los campos **StudentID**, **AssessmentDate**, **SubjectName**, **Assessment**, y **Comments**.
6. En el **Menú Archivo**, haga clic en **Cerrar Solución**.

>**Resultado:** Después de completar este ejercicio, la aplicación contendrá las instrucciones para el profesor, el estudiante y los tipos de grado.



### Ejercicio 3: Mostrando información de usuario y grado

#### Tarea 1: Añadir el evento LogonFailed

1. En **Estudio Visual**, en el menú **Archivo**, apunte a **Abrir**, y luego haga clic en **Proyecto/Solución**.
2. 2. En el cuadro de diálogo **Abrir Proyecto**, apunta a **[Raíz del Repositorio]\N-Todos los Archivos {Mod03\Labfiles\N-Ejercicio 3**, apunta a **GradesPrototype.sln**, y luego haz clic en **Abrir**.
   >**Nota :** Si aparece cualquier cuadro de diálogo de advertencia de seguridad, desactive la casilla **Ask me for each project in this solution** y luego haga clic en **OK**.
3. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 1a: Definir la tarea LogonFailed event**.
4. 4. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    evento público EventHandler LogonFailed;
    ```
5. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 1b: 6. Validar el nombre de usuario y la contraseña contra la colección de usuarios en la tarea **Tarea de la ventana MainWindow**.
6. En el editor de códigos, en el método **Logon_Click**, haga clic en la línea en blanco, y luego escriba el siguiente código:
    ```cs
    // Encuentra al usuario en la lista de posibles usuarios - primero comprueba si el usuario es un profesor
    var teacher = (de Teacher t en DataSource.Teachers
                   donde String.Compare(t.Nombredeusuario, nombredeusuario.Texto) == 0 &&
                         String.Compare(t.Contraseña, contraseña.Contraseña) == 0
                   seleccione t).FirstOrDefault();

    // Si el nombre de usuario del usuario recuperado usando LINQ no está vacío, entonces el usuario es un profesor
    si (!String.IsNullOrEmpty(maestro.nombredeusuario))
    {
        // Guardar la identificación de usuario y la función (profesor o estudiante) y el nombre de usuario en el contexto global
        SessionContext.UserID = teacher.TeacherID;
        SessionContext.UserRole = Role.Teacher;
        SessionContext.UserName = teacher.UserName;
        SessionContext.CurrentTeacher = teacher;

        // Subir el evento LogonSuccess y terminar
        LogonSuccess(esto, nulo);
        volver;
    }
    // Si el usuario no es un profesor, compruebe si el nombre de usuario y la contraseña coinciden con los de un estudiante
    más
    {
        var estudiante = (de Student s en DataSource.Students
                       donde String.Compare(s.Nombredeusuario, nombredeusuario.Texto) == 0 &&
                             String.Compare(s.Contraseña, contraseña.Contraseña) == 0
                       seleccione s).FirstOrDefault();

        // Si el nombre de usuario del usuario recuperado usando LINQ no está vacío, entonces el usuario es un estudiante.
        si (!String.IsNullOrEmpty(estudiante.nombredeusuario))
        {
            // Guarda los detalles del estudiante en el contexto global
            SessionContext.UserID = student.StudentID;
            SessionContext.UserRole = Role.Student;
            SessionContext.UserName = student.UserName;
            SessionContext.CurrentStudent = estudiante;

            // Subir el evento LogonSuccess y terminar
            LogonSuccess(esto, nulo);
            volver;
        }
    }

    // Si las credenciales no coinciden con las de un profesor o un estudiante, entonces deben ser inválidas.
    // Subir el evento LogonFailed
    LogonFailed(esto, nulo);
    ```

#### Tarea 2: Añadir el manejador de eventos Logon_Failed

1. En la ventana **Task List**, haga doble clic en la tarea **TODO: Ejercicio 3: Tarea 2a: Manejar el fallo de inicio de sesión**.
2. 2. En el editor de códigos, haga clic en la línea en blanco debajo de los comentarios, y luego escriba el siguiente código:
    ```cs
    vacío privado Logon_Failed(object sender, EventArgs e)
    {
        // Mostrar un mensaje de error. El usuario debe intentarlo de nuevo
        MessageBox.Show("Nombre de usuario o contraseña inválidos", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    ```
3. En **Solution Explorer**, haga doble clic en **MainWindow.xaml**.
4. En el editor XAML, localice la tarea **TODO: Ejercicio 3: Tarea 2b: 5. Conecte el evento LogonFailed de la vista LogonPage al método Logon_Failed de la tarea MainWindow.xaml.cs**.
5. En la línea debajo del comentario, modifique la marca XAML
    "xml
    <y:LogonPage x:Name="logonPage" LogonSuccess="Logon_Success" Visibility="Collapsed" />
    ```
    para que se vea como el siguiente marcado:
    "xml
    <y:LogonPage x:Name="logonPage" LogonSuccess="Logon_Success" LogonFailed="Logon_Failed" Visibility="Collapsed" />
    ```
6. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 2c: Mostrar el nombre del estudiante en el banner en la parte superior de la página** tarea.
7. 7. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    // Mostrar el nombre del estudiante en el banner en la parte superior de la página
    txtName.Text = string.Format("Welcome {0} {1}", SessionContext.CurrentStudent.FirstName, SessionContext.CurrentStudent.LastName);
    ```
8. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 2d: Mostrar el nombre del profesor en el banner en la parte superior de la página** tarea.
9. 9. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    // Mostrar el nombre del profesor en el banner de la parte superior de la página
    txtName.Text = string.Format("Welcome {0} {1}", SessionContext.CurrentTeacher.FirstName, SessionContext.CurrentTeacher.LastName);
    ```

#### Tarea 3: Mostrar los estudiantes para el profesor actual

1. En **Solution Explorer**, expandir **Views**, y luego hacer doble clic en **StudentsPage.xaml**.
2. 2. En el editor XAML, localiza el **ItemsControl** llamado **lista** y observa cómo se utiliza la vinculación de datos para mostrar el nombre de cada estudiante.
   >**Nota:** La vinculación de datos también se utiliza para recuperar el StudentID de un estudiante. Esta vinculación se utiliza cuando un usuario hace clic en un estudiante de la lista **Página del estudiante** para identificar al estudiante cuyos datos se van a mostrar en la página **Perfil del estudiante**.
3. 3. En la ventana **Task List**, haga doble clic en la tarea **TODO: Ejercicio 3: Tarea 3a: Mostrar los estudiantes para el profesor actual (realizada en SessionContext.CurrentTeacher)**.
4. 4. En el editor de códigos, en el método **Refrescar**, haga clic en la línea en blanco, y luego escriba el siguiente código:
    ```cs
    // Encontrar estudiantes para el profesor actual
    Estudiantes de ArrayList = nueva ArrayList();

    foreach (Estudiante en DataSource.Students)
    {
        si (student.TeacherID == SessionContext.CurrentTeacher.TeacherID)
        {
            estudiantes. Añade (estudiante);
        }
    }

    // Vincular la colección a la plantilla de artículos de la lista
    list.ItemsSource = estudiantes;

    // Mostrar el nombre de la clase
    txtClass.Text = String.Format("Class {0}", SessionContext.CurrentTeacher.Class);
    ```
5. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 3b: Si el usuario hace clic en un estudiante, muestre los detalles de esa tarea del estudiante**.
6. 6. En el editor de códigos, en el método **Student_Click**, haga clic en la línea en blanco, y luego escriba el siguiente código:
    ```cs
    Botón itemClick = remitente como Botón;

    si (itemClick != null)
    {
        // Averigua qué estudiante fue pulsado
        int estudianteID = (int)itemClick.Tag;

        si (EstudianteSeleccionado !=nulo)
        {
            // Encuentra los detalles del estudiante examinando el DataContext del Botón
            Estudiante estudiante = (Estudiante)artículoClick.DataContexto;

            // Subir el evento EstudianteSeleccionado (manejado por la Ventana Principal para mostrar los detalles de este estudiante
            StudentSelected(remitente, nuevo StudentEventArgs(estudiante));
        }
    }
    ```
7. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 3c: 8. Poner al estudiante actual en el contexto global con el estudiante especificado en la tarea del parámetro StudentEventArgs**.
8. 8. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    Contexto de la sesión. Estudiante actual = e.Niño;
    ```

#### Tarea 4: Establecer el DataContext para la página

1. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 4a: Mostrar los detalles de la tarea del estudiante actual (realizada en SessionContext.CurrentStudent)**.
2. 2. En el editor de códigos, haga clic en la línea en blanco debajo del comentario, y luego escriba el siguiente código:
    ```cs
    // Vincular el panel de pila de nombres de estudiantes para mostrar los detalles del estudiante en los bloques de texto de este panel.
    Nombre del estudiante. Contexto de datos. Contexto de la sesión. Estudiante actual;

    // Si el usuario actual es un estudiante, oculta el botón Atrás.
    // (sólo aplicable a los profesores que pueden usar el botón de retroceso para volver a la lista de estudiantes)
    si (SessionContext.UserRole == Role.Student)
    {
        btnBack.Visibilidad = Visibilidad.Oculta;
    }
    más
    {
        btnBack.Visibility = Visibilidad.Visible;
    }
    ```
3. En **Solution Explorer**, expandir **Views** y luego hacer doble clic en **StudentProfile.xaml**.
4. 4. En el editor XAML, localice la tarea **TODO: Ejercicio 3: Tarea 4b: Vincular el Bloque de Texto FirstName a la propiedad FirstName del DataContext para esta tarea de control**.
5. En la línea debajo del comentario, modifique la marca XAML
    "xml
    <TextBlock x:Name="firstName" FontSize="16" />
    ```
    para que se vea como el siguiente marcado:
    "xml
    <TextBlock x:Name="firstName" Text="{Binding FirstName}" FontSize="16" />
    ```
6. En el editor de XAML, localice la tarea **TODO: Ejercicio 3: Tarea 4c: Vincular el bloque de texto LastName a la propiedad LastName del DataContext para esta tarea de control.
7. En la línea debajo del comentario, modifique la marca XAML
    "xml
    <TextBlock x:Name="apellido" FontSize="16"/>
    ```
    para que se vea como el siguiente marcado:
    "xml
    <TextBlock x:Name="apellido" Text="{Apellido vinculante}" FontSize="16" />
    ```
8. En la ventana **Task List**, haga doble clic en el **TODO: Ejercicio 3: Tarea 4d: 9. Crear una lista de las calificaciones del estudiante y mostrar esta lista en la página** tarea.
9. 9. En el editor de códigos, haga clic al final de la línea de comentarios, presione Enter, y luego escriba el siguiente código:
    ```cs
    // Find all the grades for the student
    ArrayList grades = new ArrayList();

    foreach (Grade grade in DataSource.Grades)
    {
        if (grade.StudentID == SessionContext.CurrentStudent.StudentID)
        {
            grades.Add(grade);
        }
    }

    // Display the grades in the studentGrades ItemsControl by using databinding
    studentGrades.ItemsSource = grades;
    ```


#### Tarea 5: Construir y probar la aplicación

1. En el menú **Construir**, haga clic en **Construir solución**.
2. En el menú **Debug**, haga clic en **Iniciar sin depuración**.
3. 3. Cuando la aplicación se cargue, en el cuadro de texto **Nombre de usuario**, escriba **parkerd**, en el cuadro de texto **Contraseña**, escriba **contraseña**, y luego haga clic en **Entrar en**.
4. 4. Verifique que aparezca el cuadro de diálogo **Logon Failed**, y luego haga clic en **OK**.
5. 5. En el cuadro de texto **Nombre de usuario**, borre el contenido existente, escriba **vallee**, y luego haga clic en **Entrar en**.
6. 6. Verifique que aparezca la página **Estudiantes**, mostrando una lista de estudiantes.
7. 7. Haga clic en el estudiante **Kevin Liu** y verifique que aparece la página **Perfil del estudiante**.
8. 8. Haga clic en **Log off**.
9. En el cuadro de texto **Nombre de usuario**, borre el contenido existente, escriba **grubere**, y luego haga clic en **Log on**.
10. 10. Verifique que se muestre la página **Perfil del estudiante** para **Eric Gruber**.
11. 11. Cierre la aplicación.
12. 12. En el menú **Archivo**, haga clic en **Cerrar solución**.

>**Resultado:** Después de completar este ejercicio, sólo los usuarios válidos podrán iniciar sesión en la aplicación y sólo verán los datos adecuados a su función.


