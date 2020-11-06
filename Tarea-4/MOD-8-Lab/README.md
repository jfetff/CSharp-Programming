# Módulo 8: Acceso a datos remotos

# Laboratorio: Recuperación y modificación de datos de calificaciones de forma remota


Tiempo estimado:** 60 minutos **

Fichero de Instrucciones: Instructions\20483C_MOD08_LAK.md

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

## Configuración del Lab


## Pasos de preparación

1. Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Inicialice la base de datos:
   - En la lista **Aplicaciones**, haga clic en **Explorador de archivos**.
   - En el Explorador de archivos, navegue a la carpeta **[Repository Root]\Allfiles\Mod08\Labfiles\Databases** y luego haga doble clic en **SetupSchoolGradesDB.cmd**.
        > **Nota:** Si aparece un cuadro de diálogo de Windows protegió su PC, haga clic en **Más información** y luego haga clic en **Ejecutar de todos modos**. Cierre el Explorador de archivos.
3. Asegúrese de haber completado los siguientes pasos antes de comenzar a trabajar en este módulo:
   - Instale **Microsoft.OData.ConnectedService.vsix **desde **[Repository Root]\AllFiles\Assets**.
   - Instale **WcfDataServices.exe **desde **[Repository Root]\AllFiles\Assets**.
   - Ejecute el archivo **WCF.reg **desde **[Repository Root]\AllFiles\Assets**.

## Ejercicio 1: Creación de un servicio de datos WCF para la base de datos SchoolGrades

### Tarea 1: Configurar el servicio de datos en el proyecto Grades.Web

1. Abra **Visual Studio 2019**.
2. En **Visual Studio**, en el menú **Archivo**, seleccione **Abrir** y luego haga clic en **Proyecto/Solución**.
3. En el cuadro de diálogo **Abrir proyecto**, vaya a **[Repository Root]\Allfiles\Mod08\Labfiles\Starter\Exercise 1**, haga clic en **GradesPrototype.sln** y luego haga clic en **Abrir**.
    > **Nota:** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación **Preguntarme por cada proyecto en esta solución** y luego haga clic en **Aceptar**.
4. En **Explorador de soluciones**, haga clic con el botón derecho en la solución **GradesPrototype** y luego haga clic en **Restaurar paquetes NuGet**.
5. En el proyecto **Grades.Web**, haga clic con el botón derecho en **Referencs** y luego haga clic en **Agregar referencia**.
6. En el cuadro de diálogo **Administrador de referencias - Grades.Web**, realice los siguientes pasos:
   - Haga clic en **Proyectos** y luego seleccione **Grades.DataModel**.
   - Haga clic en **Examinar**.
   - En el cuadro de diálogo **Seleccione los archivos para hacer referencia**, busque la carpeta **[Repository Root]\Allfiles\Mod08\Labfiles\Starter\Exercise 1\packages\EntityFramework.5.0.0\lib\net45**, haga clic en **EntityFramework.dll** y haga clic en **Agregar**.
   - Haga clic en Aceptar**.
7. En el Explorador de soluciones, expanda el proyecto **GradesPrototype** y luego haga doble clic en **App.config**.
8. En el editor de código, copie el siguiente XML en el portapapeles:
    ```xml
    <connectionStrings>
        <add name="SchoolGradesDBEntities" connectionString="metadata=res://*/GradesModel.csdl|res://*/GradesModel.ssdl|res://*/GradesModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(localdb)\MSSQLLocalDB;initial catalog=SchoolGradesDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    </connectionStrings>
    ```
9. En **Explorador de soluciones**, en el proyecto **Grades.Web**, haga doble clic en **Web.config**.
10. Haga clic en al final del elemento **\<configuración\>** de apertura, presione Entrar y luego pegue el contenido del portapapeles.

### Tarea 2: Especificar el contexto de datos de GradesDBEntities para el servicio de datos

1. En **Explorador de soluciones**, en el proyecto **Grades.Web**, expanda **Servicios** y luego haga doble clic en **GradesWebDataService.svc**.
2. En el editor de código, escriba el siguiente código debajo de todos los **using**:
    ```cs
    using Grades.DataModel;
    ```
3. En el menú **Ver**, haga clic en **Lista de tareas**.
4. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Ejercicio 1: Tarea 2a: Reemplace la palabra clave del objeto con el nombre de la clase de la fuente de datos**.
5. En el editor de código, ubique el comentario **TODO: Ejercicio 1: Tarea 2a: Reemplace la palabra clave del objeto con su nombre de clase de fuente de datos**, y luego escriba el siguiente código en lugar de la palabra clave **objeto**:
    ```cs
    SchoolGradesDBEntities
    ```
6. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 1: Task 2b: set rules to indicate which entity sets and service operations are visible, updatable, etc**.
7. En el editor de código, haga clic al final de la línea de comentarios, presione Entrar y luego escriba el siguiente código:
    ```cs
    // Configure all entity sets to permit read and write access.
    config.SetEntitySetAccessRule("Grades", EntitySetRights.All);
    config.SetEntitySetAccessRule("Teachers", EntitySetRights.All);
    config.SetEntitySetAccessRule("Students", EntitySetRights.All);
    config.SetEntitySetAccessRule("Subjects", EntitySetRights.All);
    config.SetEntitySetAccessRule("Users", EntitySetRights.All);
    ```

### Tarea 3: agregar una operación para recuperar a todos los estudiantes en una clase específica

1. Haga clic después de las llaves de cierre para el método **InitializeService**, presione Entrar dos veces y luego escriba el siguiente código:
    ```cs
    // Find all students in a specified class.
    [WebGet]
    public IEnumerable<Student> StudentsInClass(string className)
    {
        var students = from Student s in this.CurrentDataSource.Students
                       where String.Equals(s.Teacher.Class, className)
                       select s;

        return students;
    }
    ```
2. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 1: Task 2b: set rules to indicate which entity sets and service operations are visible, updatable, etc**.
3. En el editor de código, haga clic en al final de la línea de comentarios, presione Entrar y luego escriba el siguiente código:
    ```cs
    // Configure the StudentsInClass operation as read-only.
    config.SetServiceOperationAccessRule("StudentsInClass", ServiceOperationRights.AllRead);
    ```

### Tarea 4: Crear y probar el servicio de datos

1. En el menú **Crear**, haga clic en **Crear solución**.
2. En **Explorar soluciones **r, en el proyecto **Grades.Web**, en la carpeta **Servicios**, haga clic con el botón derecho en **GradesWebDataService.svc** y luego haga clic en **Ver en el navegador (Microsoft Edge)**.
3. En Microsoft Edge, si aparece el mensaje **La configuración de la intranet está desactivada de forma predeterminada**, haga clic en **No volver a mostrar este mensaje**.
4. Verifique que Microsoft Edge muestre una descripción XML de las entidades que expone el Servicio de datos.
5. Cierre el navegador.
6. En Visual Studio, en el menú **Archivo**, haga clic en **Cerrar solución**.

> **Resultado:** Después de completar este ejercicio, debería haber configurado un servicio de datos WCF en la aplicación para proporcionar acceso remoto a la base de datos **SchoolGrades**.

## Ejercicio 2: Integración del servicio de datos en la aplicación

### Tarea 1: Agregar un servicio conectado de OData para el servicio de datos WCF a la aplicación GradesPrototype

1. En Visual Studio, en el menú **Archivo**, seleccione **Abrir** y luego haga clic en **Proyecto/Solución**.
2. En el cuadro de diálogo **Abrir proyecto**, busque **[Raíz del repositorio]\Allfiles\Mod08\Labfiles\Starter\Ejercicio 2**, haga clic en **GradesPrototype.sln** y luego haga clic en **Abrir**.
    > **Nota:** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación **Preguntarme por cada proyecto en esta solución** y luego haga clic en **Aceptar**.
3. En **Solution Explorer**, haga clic con el botón derecho en la solución **GradesPrototype** y luego haga clic en **Set StartUp Projects**.
4. En el cuadro de diálogo **Páginas de propiedades de la solución 'GradesPrototype'**, haga clic en **Varios proyectos de inicio**.
5. En la columna **Acción** para **Grades.Web** y **GradesPrototype**, haga clic en **Inicio** y luego en **Aceptar**.
6. En el menú **Generar**, haga clic en **Reconstruir solución**.
7. En el Explorador de soluciones, en el proyecto **Grades.Web**, en la carpeta **Servicios**, haga clic con el botón derecho en **GradesWebDataService.svc** y luego haga clic en **Ver en el navegador (Microsoft Edge) * *.
8. En **Solution Explorer**, expanda **GradesPrototype**, expanda **References**, haga clic con el botón derecho en **Grades.DataModel** y luego haga clic en **Remove**.
9. Haga clic con el botón derecho en **Referencias** y luego haga clic en **Agregar servicio conectado**.
10. En la ventana **Servicios conectados**, elija **Servicio conectado de OData**.
11. En el cuadro de diálogo **Configurar punto final**, en el cuadro de texto **Nombre del servicio**, escriba **Grades.DataModel**.
12. En el cuadro de texto **Dirección**, escriba **http://localhost:1655/Services/GradesWebDataService.svc/$metadata** y luego haga clic en **Siguiente**.
13. Haga clic en **Finalizar** y espere hasta que se complete el proceso.
14. En **Solution Explorer**, en el proyecto **GradesPrototype**, expanda **Connected Services**, expanda la carpeta **Grades.DataModel** y luego haga doble clic en **Reference.cs **.
15. En el editor de código, modifique el código** del espacio de nombres SchoolGradesDBModel** para que se parezca al siguiente código:
    ```cs
    namespace Grades.DataModel
    ```'
16. En **Explorador de soluciones**, haga clic con el botón derecho en el proyecto **GradesPrototype**, seleccione **Agregar** y luego haga clic en **Nueva carpeta**.
17. Elimine el nombre existente, escriba **DataModel** y luego presione Entrar.
18. En **Explorador de soluciones**, expanda el proyecto **Grades.DataModel**, haga clic con el botón derecho en **Classes.cs **y, a continuación, haga clic en **Copiar**.
19. En **GradesPrototype**, haga clic con el botón derecho en **DataModel** y luego haga clic en **Pegar**.
20. En **Grades.DataModel**, haga clic con el botón derecho en **customGrade.cs** y luego haga clic en **Copiar**.
21. En **GradesPrototype**, haga clic con el botón derecho en **DataModel** y luego haga clic en **Pegar**.
22. En **Grades.DataModel**, haga clic con el botón derecho en **customTeacher.cs** y luego haga clic en **Copiar**.
23. En **GradesPrototype**, haga clic con el botón derecho en **DataModel** y luego haga clic en **Pegar**.

### Tarea 2: Modificar el código que accede al EDM para usar el Servicio de datos WCF

1. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 2a: Specify the URL of the GradesWebDataService**.
2. En el editor de código, debajo del comentario, haga clic dentro del paréntesis y luego escriba el siguiente código:
    ```cs
    new Uri("http://localhost:1655/Services/GradesWebDataService.svc")
    ```
3. Agregue el siguiente código a la clase **SessionContext**, después del método **Guardar **:
    ```cs
    static SessionContext()
    {
        DBContext.MergeOption = System.Data.Services.Client.MergeOption.PreserveChanges;
    }
    ```
4. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 2b: Load User and Grades data with Students**.
5. En el editor de código, al final del comentario, presione Entrar y luego escriba el siguiente código:
    ```cs
    SessionContext.DBContext.LoadProperty(student, "User");
    SessionContext.DBContext.LoadProperty(student, "Grades");
    ```
6. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 2c: Load User and Students data with Teachers**.
7. En el editor de código, debajo del comentario, haga clic al final del código **SessionContext.DBContext.Teachers** y luego escriba el siguiente código:
    ```cs
    .Expand("User, Students")
    ```
8. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 2d: Load User and Grades data with Students**.
9. En el editor de código, debajo del comentario, haga clic al final del código **SessionContext.DBContext.Students** y luego escriba el siguiente código:
    ```cs
    .Expand("User, Grades")
    ```
10. En **Explorador de soluciones**, en el proyecto **GradesPrototype**, expanda **DataModel** y luego haga doble clic en **customTeacher.cs**.
11. Haga clic al final del código **usando System.Threading.Tasks**, presione Entrar y luego escriba el siguiente código:
    ```cs
    using GradesPrototype.Services;
    ```
12. En el editor de código, ubique **TODO: Exercise 2: Task 2e: Refer to the Students collection in the SessionContext.DBContext object** del objeto SessionContext.DBContext en el archivo **customTeacher.cs**. Hay dos comentarios con este texto. Esto se debe a que el comentario se encuentra en el archivo **customTeacher.cs **que copió del proyecto **Grades.DataModel**. Asegúrese de modificar el archivo **customTeacher.cs **en el proyecto **GradesPrototype**.
13. En la línea debajo del comentario, elimine la palabra **Estudiantes** y luego escriba el siguiente código:
    ```cs
    SessionContext.DBContext.Students
    ```
14. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 2f: Reference the SessionContext.DBContext.Students collection**.
15. En el editor de código, debajo del comentario, cambie
    ```cs
    SessionContext.DBContext.Students.Local
    ```
    al siguiente código:
    ```cs
    SessionContext.DBContext.Students.Expand("User, Grades")
    ```
16. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 2g: Use the AddToGrades method to add a new grade.**
17. En el editor de código, debajo del comentario, cambie
    ```cs
    SessionContext.DBContext.Grades.Add(newGrade);
    ```
    al siguiente código:
    ```cs
    SessionContext.DBContext.AddToGrades(newGrade);
    ```
18. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 2h: Load Subject data with Grades**.
19. En el editor de código, debajo del comentario, cambie **SessionContext.DBContext.Grades** al siguiente código:
    ```cs
    SessionContext.DBContext.Grades.Expand("Subject")
    ```
20. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 2i: Use the AddToStudents method to add a new student**.
21. En el editor de código, debajo del comentario, cambie
    ```cs
    SessionContext.DBContext.Students.Add(newStudent);
    ```
    al siguiente código:
    ```cs
    SessionContext.DBContext.AddToStudents(newStudent);
    ```

### Tarea 3: Modificar el código que guarda los cambios en la base de datos para usar el servicio de datos WCF

1. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 3a: Specify that the selected student has been changed**.
2. En el editor de código, haga clic en el espacio en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    SessionContext.DBContext.UpdateObject(student);
    ```
3. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 3b: Specify that the current student has been changed**.
4. En el editor de código, haga clic en el espacio en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
  SessionContext.DBContext.UpdateObject(SessionContext.CurrentStudent);
    ```
5. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 3c: Specify that the current user has been changed**.
6. Haga clic en el espacio en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    SessionContext.DBContext.UpdateObject(currentUser);
    ```

### Tarea 4: compila y prueba la aplicación para verificar que aún funciona correctamente

1. En el menú **Crear**, haga clic en **Crear solución**.
2. En el menú **Depurar**, haga clic en **Iniciar sin depurar**.
3. En el cuadro de texto **Nombre de usuario**, escriba **vallee**.
4. En el cuadro de texto **Password**, escriba **password99** y luego haga clic en **Iniciar sesión**.
5. En la lista de alumnos, haga clic en **Eric Gruber** y luego haga clic en **Eliminar alumno**.
6. En el cuadro de diálogo **Confirmar**, haga clic en **Sí**.
7. Verifique que **Eric Gruber **se elimine de la lista de estudiantes.
8. Haga clic en **Inscribir estudiante**.
9. En el cuadro de diálogo **Asignar alumno**, haga clic en **Jon Orton**.
10. En el cuadro de diálogo **Confirmar**, haga clic en **Sí**.
11. En el cuadro de diálogo **Asignar estudiante**, haga clic en **Cerrar** y luego verifique que **Jon Orton **se haya agregado a la lista de estudiantes.
12. Haga clic en **Cambiar contraseña**.
13. En el cuadro de diálogo **Cambiar contraseña**, en el cuadro de texto **Contraseña anterior**, escriba **password99**.
14. En el cuadro de texto **Nueva contraseña**, escriba **password88**.
15. En el cuadro de texto **Confirmar**, escriba **password88** y luego haga clic en **Aceptar**.
16. En el cuadro de diálogo **Password**, haga clic en **Aceptar** y luego haga clic en **Cerrar sesión**.
17. Haga clic en **Iniciar sesión**, verifique que aparezca el cuadro de diálogo **Error de inicio de sesión** y luego haga clic en **Aceptar**.
18. En el cuadro de texto **Password**, escriba **password88** y luego haga clic en **Iniciar sesión**.
19. Verifique que se muestre la lista de estudiantes.
20. Haga clic en **Cerrar sesión **y, a continuación, en el cuadro de texto **Nombre de usuario**, escriba **grubere**.
21. En el cuadro de texto **Password**, escriba **password** y luego haga clic en **Iniciar sesión**.
22. Verifique que aparezca el perfil de estudiante de Eric Gruber y luego haga clic en **Cerrar sesión**.
23. Cierre la aplicación.
24. En Visual Studio, en el menú **Archivo**, haga clic en **Cerrar solución**.

> **Resultado:** Después de completar este ejercicio, debería haber actualizado la aplicación **Grades Prototype** para usar OData Connected Service.

## Ejercicio 3: Recuperación de fotografías de estudiantes en Internet (si el tiempo lo permite)

### Tarea 1: Crear la clase de convertidor de valor ImageNameConverter

1. En Visual Studio, en el menú **Archivo**, seleccione **Abrir** y luego haga clic en **Proyecto/Solución**.
2. En el cuadro de diálogo **Abrir proyecto**, vaya a **[Repository Root]\Allfiles\Mod08\Labfiles\Starter\Exercise 3**, haga clic en **GradesPrototype.sln** y luego haga clic en **Abrir**.
    > **Nota:** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación **Preguntarme por cada proyecto en esta solución** y luego haga clic en **Aceptar**.
3. En **Solution Explorer**, haga clic con el botón derecho en la solución **GradesPrototype** y luego haga clic en **Set StartUp Projects**.
4. En el cuadro de diálogo **Páginas de propiedades de la solución 'GradesPrototype'**, haga clic en **Varios proyectos de inicio**.
5. En la columna **Acción** para **Grades.Web** y **GradesPrototype**, haga clic en **Inicio** y luego en **Aceptar**.
6. En el menú **Generar**, haga clic en **Reconstruir solución**.
7. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 3: Task 1: Create the ImageNameConverter value converter to convert the image name of a student photograph into the URL of the image on the Web server**.
8. Haga clic al final del comentario **// Converter class for transforming an image name for a photograph into a URL**, presione Entrar y luego escriba el siguiente código:
    ```cs
    public class ImageNameConverter : IValueConverter
    {
    }
    ```
9. En la clase **ImageNameConverter**, escriba el siguiente código:
    ```cs
    const string webFolder = "http://localhost:1650/Images/Portraits/";
    ```
10. Haga clic con el botón derecho en la palabra clave **IValueConverter**, seleccione **Quick Actions and refactorings** y, a continuación, haga clic en **Implementar interfaz**.
11. En el método **Convert**, elimine la declaración existente que arroja una **NotImplementedException** y luego escriba el siguiente código:
    ```cs
    string fileName = value as string;

    if (fileName != null)
    {
        return string.Format("{0}{1}", webFolder, fileName);
    }
    else
    {
        return string.Empty;
    }
    ```
12. En el menú **Crear**, haga clic en **Crear solución**.

### Tarea 2: agregar un control de imagen a la vista StudentsPage y vincularlo a la propiedad ImageName

1. En **Explorador de soluciones**, en el proyecto **GradesPrototype**, expanda **Vistas** y luego haga doble clic en **StudentsPage.xaml**.
2. En el editor XAML, en el elemento **UserControl **en la parte superior del marcado, haga clic después de **xmlns:d="http://schemas.microsoft.com/expression/blend/2008"** línea, presione Entrar y luego escriba el siguiente marcado:
    ```xml
    xmlns:local="clr-namespace:GradesPrototype.Views"
    ```
3. Busque **TODO: Exercise 3: Task 2a. Add an instance of the ImageNameConverter class as a resource to the view**, haga clic al final del comentario, presione Entrar y luego escriba el siguiente marcado:
    ```xml
    <UserControl.Resources>
        <local:ImageNameConverter x:Key="ImageNameConverter"/>
    </UserControl.Resources>
    ```
4. Busque **TODO: Exercise 3: Task 2b. Add an Image control to display the photo of the student**, haga clic al final del comentario, presione Entrar y luego escriba el siguiente marcado:
    ```xml
    <Image Height="100" />
    ```
5. Busque **Exercise 3: Task 2c. Bind the Image control to the ImageName property and use the ImageNameConverter to convert the image name into a URL**.
6. En la línea sobre el comentario, modifique el
    ```xml
    <Image Height="100" />
    ```
    markup to look like the following markup:
    ```xml
    <Image Height="100" Source="{Binding ImageName, Converter={StaticResource ImageNameConverter}}" />
    ```

### Tarea 3: Agregar un control de imagen a la vista Perfil de estudiante y vincularlo a la propiedad ImageName

1. En el Explorador de soluciones, haga doble clic en **StudentProfile.xaml**.
2. Busque **TODO: Exercise 3: Task 3a. Add an instance of the ImageNameConverter class as a resource to the view**.
3. Haga clic en al final del comentario, presione Entrar y luego escriba el siguiente marcado:
    ```xml
    <app:ImageNameConverter x:Key="ImageNameConverter"/>
    ```
4. Busque **TODO: Exercise 3: Task 3b. Add an Image control to display the photo of the student and bind the Image control to the ImageName property and use the ImageNameConverter to convert the image name into a URL**.
5. Haga clic en al final del comentario, presione Entrar y luego escriba el siguiente marcado:
    ```xml
    <Image Height="150" Source="{Binding ImageName, Converter={StaticResource ImageNameConverter}}" />
    ```

### Tarea 4: Agregar un control de imagen al control AssignStudentDialog y vincularlo a la propiedad ImageName

1. En **Explorador de soluciones**, expanda **Controles** y luego haga doble clic en **AssignStudentDialog.xaml**.
2. En el editor XAML, en la parte superior del marcado, haga clic en al final de la línea **xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"**, presione Entrar, y luego escriba el siguiente marcado:
    ```xml
    xmlns:local="clr-namespace:GradesPrototype.Views"
    ```
3. Busque **TODO: Exercise 3: Task 4a. Add an instance of the ImageNameConverter class as a resource to the view**.
4. Haga clic en al final del comentario, presione Entrar y luego escriba el siguiente marcado:
    ```xml
    <Window.Resources>
        <local:ImageNameConverter x:Key="ImageNameConverter"/>
    </Window.Resources>
    ```
5. Busque **TODO: Exercise 3: Task 4b. Add an Image control to display the photo of the student and bind the control to the ImageName property and use the ImageNameConverter to convert the image name into a URL**.
6. Haga clic en al final del comentario, presione Entrar y luego escriba el siguiente marcado:
    ```xml
    <Image Height="100" Source="{Binding ImageName, Converter = {StaticResource ImageNameConverter}}" />
    ```

### Tarea 5: compila y prueba la aplicación, verificando que las fotografías de los alumnos aparezcan en la lista de alumnos del profesor

1. En el menú **Crear**, haga clic en **Crear solución**.
2. En el menú **Depurar**, haga clic en **Iniciar sin depurar**.
3. En el cuadro de texto **Nombre de usuario**, escriba **vallee**.
4. En el cuadro de texto **Password**, escriba **password88** y luego haga clic en **Iniciar sesión**.
5. Verifique que la lista de estudiantes ahora incluya imágenes.
6. Haga clic en **George Li** y luego verifique que el perfil del estudiante aparezca con una imagen.
7. Haga clic en **Eliminar alumno**.
8. En el cuadro de diálogo **Confirmar**, haga clic en **Sí**.
9. Haga clic en **Inscribir estudiante**.
10. En el cuadro de diálogo **Asignar alumno**, verifique que cada uno de los alumnos no asignados tenga una imagen.
11. Haga clic en **George Li**.
12. En el cuadro de diálogo **Confirmar**, haga clic en **Sí**.
13. En el cuadro de diálogo **Asignar alumno**, haga clic en **Cerrar**.
14. Verifique que George Li se agregue a la lista de estudiantes con una imagen.
15. Cierre la aplicación.
16. En el menú **Archivo**, haga clic en **Cerrar solución**.

> **Resultado:** Después de completar este ejercicio, la lista de estudiantes, el perfil del estudiante y el cuadro de diálogo del estudiante no asignado mostrarán las imágenes de los estudiantes que se recuperaron en la web.