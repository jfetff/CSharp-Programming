
# Módulo 12: Creación de tipos y ensamblajes reutilizables

# Laboratorio: Especificación de los datos para incluir en el informe de calificaciones


Tiempo estimado:** 75 minutos **

Fichero de Instrucciones: Instructions\20483C_MOD12_LAK.md

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
2. Inicializar la base de datos:
   - En la lista **Aplicaciones**, haga clic en **Explorador de archivos**.
   - Navegue a la carpeta **[Repository Root]\AllFilesMod12\Labfiles\Databases** y luego haga doble clic en **SetupSchoolGradesDB.cmd**.
        > **NOTA:** Si aparece un cuadro de diálogo de Windows protegió su PC, haga clic en **Más información** y luego haga clic en **Ejecutar de todos modos**.
   - Cierre **Explorador de archivos**.

## Ejercicio 1: Creación y aplicación del atributo IncludeInReport

### Tarea 1: Escribe el código para la clase IncludeInReportAttribute

1. Abra **Visual Studio 2019**.
2. En **Visual Studio**, en el menú **Archivo**, seleccione **Abrir** y luego haga clic en **Proyecto/Solución**.
3. En el cuadro de diálogo **Abrir proyecto**, vaya a **[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 1**, haga clic en **Grades.sln** y luego haga clic en **Abrir**.
    > **Nota:** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación **Preguntarme por cada proyecto en esta solución** y luego haga clic en **Aceptar**.
4. En **Explorador de soluciones**, haga clic con el botón derecho en Solución **"Calificaciones" **y, a continuación, haga clic en **Propiedades**.
5. En la página **Proyecto de inicio**, haga clic en **Varios proyectos de inicio**, configure **Grades.Web** y **Grades.WPF **en **Inicio** y luego haga clic en **Aceptar**.
6. En **Explorador de soluciones**, expanda **Grades.Utilities** y luego haga doble clic en **IncludeInReport.cs**.
7. En el menú **Ver**, haga clic en **Lista de tareas**.
8. En la ventana **Lista de tareas**, haga doble clic en ***TODO: Exercise 1: Task 1a: Specify that IncludeInReportAttribute is an attribute class**.
9. En el editor de código, debajo del comentario, haga clic en al final del código público **public class IncludeInReportAttribute** y luego escriba el siguiente código:
    `` `cs
    : Atributo
    ''
10. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 1: Task 1b: Specify the possible targets to which the IncludeInReport attribute can be applied**.
11. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    ```
12. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 1: Task 1c: Define a private field to hold the value of the attribute**.
13. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
   ```cs
    private bool _include;
    ```
14. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 1: Task 1d: Add public properties that specify how an included item should be formatted**.
15. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    public bool Underline { get; set; }
    public bool Bold { get; set; }
    ```
16. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 1: Task 1e: Add a public property that specifies a label (if any) for the item**.
17. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    public string Label { get; set; }
    ```
18. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 1: Task 1f: Define constructors**.
19. En el editor de código, haga clic al final del comentario, presione Entrar y luego escriba el siguiente código:
    ```cs
    public IncludeInReportAttribute()
    {
        this._include = true;
        this.Underline = false;
        this.Bold = false;
        this.Label = string.Empty;
    }

    public IncludeInReportAttribute(bool includeInReport)
    {
        this._include = includeInReport;
        this.Underline = false;
        this.Bold = false;
        this.Label = string.Empty;
    }
    ```

### Tarea 2: Aplicar el atributo IncludeInReportAttribute a las propiedades adecuadas

1. En **Explorador de soluciones**, expanda **Grades.WPF** y luego haga doble clic en **Data.cs**.
2. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 1: Task 2: Add the IncludeInReport attribute to the appropriate properties in the LocalGrade class**.
3. En la clase **LocalGrade**, expanda la región **Propiedades** y luego expanda la región **Propiedades de solo lectura**.
4. Encima del código de **cadena pública SubjectName**, haga clic en la línea en blanco y luego escriba el siguiente código:
    ```cs
    [IncludeInReport(Label="Subject Name", Bold=true, Underline=true)]
    ```
5. Encima del código **public string AssessmentDateString**, haga clic en la línea en blanco, presione Entrar y luego escriba el siguiente código:
    ```cs
    [IncludeInReport (Label="Date")]
    ```
6. Expanda la región **Propiedades del formulario**.
7. Encima del código **public string Assessment**, haga clic en la línea en blanco, presione Intro y luego escriba el siguiente código:
    ```cs
    [IncludeInReport(Label = "Grade")]
    ```
8. Encima del código **Comentarios de cadena pública**, haga clic en el espacio en blanco, presione Intro y luego escriba el siguiente código:
    ```cs
    [IncludeInReport(Label = "Comments")]
    ```

### Tarea 3: compila la aplicación y revisa los metadatos para la clase LocalGrades

1. En el menú **Depurar**, haga clic en **Iniciar depuración**.
2. Cierre la aplicación.
3. Abra **Explorador de archivos** y busque la carpeta **C:\Archivos de programa (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools**.
    > **Nota:** La versión NETFX puede ser superior a 4
4. Haga clic con el botón derecho en **ildasm.exe,** y luego haga clic en **Abrir**.
5. En la ventana **IL DASM**, en el menú **Archivo**, haga clic en **Abrir**.
6. En el cuadro de diálogo **Abrir**, busque **[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 1\Grades.WPF\bin\Debug**, haga clic en **Grades.WPF.exe** y luego haga clic en **Abrir**.
7. En la ventana de la aplicación **IL DASM**, expanda **Grades.WPF, **expanda **Grades.WPF.LocalGrade**, y luego haga doble clic en **Assessment: instance string()**.
8. En la ventana **Grades.WPF.LocalGrade::Assessment: instance string()**, en el método **Assessment**, verifique que la **.custom instance void [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** código está presente, y luego cierre la ventana.
9. En la ventana de la aplicación **IL DASM**, haga doble clic en **AssessmentDateString : instance string()**.
10. En la ventana **Grades.WPF.LocalGrade::AssessmentDateString : instance string()**, en el método **AssessmentDateString**, verifique que el código **.custom instance void [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** está presente, y luego cierre la ventana.
11. En la ventana de la aplicación **IL DASM**, haga doble clic en **Comments : instance string()**.
12. En la ventana **Grades.WPF.LocalGrade::Comments : instance string()**, en el método **Comments**, verifique que el código **.custom instance void [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** está presente, y luego cierre la ventana.
13. En la ventana de la aplicación **IL DASM**, haga doble clic en **SubjectName : instance string();**.
14. En la ventana **Grades.WPF.LocalGrade::SubjectName : instance string()**, en el método **SubjectName**, verifique que el codigo**.custom instance void [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** está presente, y luego cierre la ventana.
15. Cierre la aplicación **IL DASM**.
16. Cierre **Explorador de archivos**.
17. En **Visual Studio**, en el menú **Archivo**, haga clic en **Cerrar solución**.

> **Resultado:** Después de completar este ejercicio, el ensamblaje **Grades.Utilities **contendrá un atributo personalizado **IncludeInReport** y la clase **Grades **contendrá campos y propiedades que están etiquetados con ese atributo .

## Ejercicio 2: Actualización del informe

### Tarea 1: Implementar una clase auxiliar estática llamada IncludeProcessor

1. En **Visual Studio**, en el menú **Archivo**, seleccione **Abrir** y luego haga clic en **Proyecto/Solución**.
2. En el cuadro de diálogo **Abrir proyecto**, vaya a **[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 2**, haga clic en **Grades.sln** y luego haga clic en **Abrir**.
    > **Nota:** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación **Preguntarme por cada proyecto en esta solución** y luego haga clic en **Aceptar**.
3. En **Explorador de soluciones**, haga clic con el botón derecho en Solución **"Calificaciones" **y, a continuación, haga clic en **Propiedades**.
4. En la página **Proyecto de inicio**, haga clic en **Varios proyectos de inicio**, configure **Grades.Web** y **Grades.WPF **en **Inicio** y luego haga clic en **Aceptar**.
5. En **Explorador de soluciones**, expanda **Grades.Utilities** y luego haga doble clic en **IncludeInReport.cs**.
6. Debajo de la ventana **Salida**, haga clic en **Lista de tareas**.
7. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 1a: Define a struct that specifies the formatting to apply to an item**.
8. En el editor de código, haga clic en la línea en blanco de la estructura **FormatField** y luego escriba el siguiente código:
    ```cs
    public string Value;
    public string Label;
    public bool IsBold;
    public bool IsUnderlined;
    ```
9. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 1b: Find all the public fields and properties in the dataForReport object**.
10. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    Type dataForReportType = dataForReport.GetType();
    fieldsAndProperties.AddRange(dataForReportType.GetFields());
    fieldsAndProperties.AddRange(dataForReportType.GetProperties());
    ```
11. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 1c: Iterate through all public fields and properties, and process each item that is tagged with the IncludeInReport attribute**.
12. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    foreach (MemberInfo member in fieldsAndProperties)
    {
    ```
13. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 1d: Determine whether the current member is tagged with the IncludeInReport attribute**.
14. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    object[] attributes = member.GetCustomAttributes(false);
    IncludeInReportAttribute attributeFound = Array.Find(attributes, a => a.GetType() == typeof(IncludeInReportAttribute)) as IncludeInReportAttribute;
    ```
15. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 1e: If the member is tagged with the IncludeInReport attribute, construct a FormatField item**de elemento de FormatField.
16. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    if (attributeFound != null)
    {
        // Find the value of the item tagged with the IncludeInReport attribute
        string itemValue;
        if (member is FieldInfo)
        {
            itemValue = (member as FieldInfo).GetValue(dataForReport).ToString();
        }
        else
        {
            itemValue = (member as PropertyInfo).GetValue(dataForReport).ToString();
        }
    ```
17. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 1f: Construct a FormatField item with this data**.
18. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    FormatField item = new FormatField()
    {
        Value = itemValue,
        Label = attributeFound.Label,
        IsBold = attributeFound.Bold,
        IsUnderlined = attributeFound.Underline
    };
    ```
19. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 1g: Add the FormatField item to the collection to be returned**.
20. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
           items.Add(item);
        }
    }
    ```

### Tarea 2: Actualizar la funcionalidad del informe para la vista StudentProfile

1. En **Explorador de soluciones**, expanda **Grades.WPF**, expanda **Vistas**, expanda **StudentProfile.xaml** y luego haga doble clic en **StudentProfile.xaml.cs**.
2. En la ventana **Lista de tareas**, haga doble clic en la tarea **TODO: Exercise 2: Task 2a: Use the IncludeProcessor to determine which fields in the Grade object are tagged**.
3. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    List<FormatField> itemsToReport = IncludeProcessor.GetItemsToInclude(grade);
    ```
4. En la ventana **Lista de tareas**, haga doble clic en **TODO: Exercise 2: Task 2b: Output each tagged item, using the format specified by the properties of the IncludeInReport attribute for each item**.
5. En el editor de código, haga clic en la línea en blanco debajo del comentario y luego escriba el siguiente código:
    ```cs
    foreach (FormatField item in itemsToReport)
    {
        wrapper.AppendText(item.Label == string.Empty ? item.Value : item.Label + ": " + item.Value, item.IsBold, item.IsUnderlined);

        wrapper.InsertCarriageReturn();
    }
    ```

### Tarea 3: compila y prueba la aplicación

1. En el menú **Crear**, haga clic en **Crear solución**.
2. En el menú **Depurar**, haga clic en **Iniciar sin depurar**.
3. En el cuadro de texto **Nombre de usuario**, escriba **vallee**, y en el cuadro de texto **Password**, escriba **password99** y luego haga clic en **Iniciar sesión**.
4. En la vista **Clase 3C**, haga clic en **Kevin Liu**.
5. Verifique que aparezca el informe del estudiante de **Kevin Liu** y luego haga clic en **guardar informe**.
6. En el cuadro de diálogo **Guardar como**, busque la carpeta **[Raíz del repositorio]\AllFiles\Mod12\Labfiles\Starter\Exercise 2**.
7. En el cuadro de texto **Nombre de archivo**, escriba **KevinLiuGradesReport** y luego haga clic en **Guardar**.
8. Cierre la aplicación.
9. En **Visual Studio**, en el menú **Archivo**, haga clic en **Cerrar solución**.
10. Abra **Explorador de archivos**, busque **[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 2**, y luego verifique que **KevinLiuGradesReport.docx **se haya generado.
11. Haga clic con el botón derecho en **KevinLiuGradesReport.docx** y luego haga clic en **Abrir**.
12. Verifique que el documento contenga el informe de calificaciones de **Kevin Liu** y que tenga el formato correcto, y luego cierre **Microsoft Word**.

> **Resultado:** Después de completar este ejercicio, la aplicación se actualizará para usar la reflexión para incluir solo los campos etiquetados y las propiedades en el informe de calificaciones.

## Ejercicio 3: Almacenamiento de las calificaciones, ensamblaje de utilidades de forma centralizada (si el tiempo lo permite)

### Tarea 1: Firmar el ensamblado Grades.Utilities e implementarlo en la caché de ensamblado general (GAC)

1. En **Visual Studio**, en el menú **Archivo**, seleccione **Abrir** y luego haga clic en **Proyecto/Solución**.
2. En el cuadro de diálogo **Abrir proyecto**, busque **[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 3**, haga clic en **Grades.sln** y luego haga clic en **Abrir**.
    > **Nota:** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación **Preguntarme por cada proyecto en esta solución** y luego haga clic en **Aceptar**.
3. En **Explorador de soluciones**, haga clic con el botón derecho en **Solución "Calificaciones" **y, a continuación, haga clic en **Propiedades**.
4. En la página **Proyecto de inicio**, haga clic en **Varios proyectos de inicio**, configure **Grades.Web** y **Grades.WPF **en **Inicio** y luego haga clic en **Aceptar**.
5. Cambie a **Windows 10**.
6. Vaya a la lista **Aplicaciones** y haga clic en **Explorador de archivos**.
7. Busque **Símbolo del sistema para desarrolladores para VS 2017** y haga clic con el botón derecho en el icono **Símbolo del sistema para desarrolladores para VS 2017** y haga clic en **Ejecutar como administrador**.
8. En el cuadro de diálogo **Control de cuentas de usuario**, haga clic en **Sí**.
9. En la ventana **Símbolo del sistema**, escriba el siguiente código y luego presione Entrar:
    ```cs
    cd [Repository Root]\AllFiles\Mod12\Labfiles\Starter
    ```
10. En la ventana **Símbolo del sistema**, escriba el siguiente código y luego presione Entrar:
    ```cs
    sn -k GradesKey.snk
    ```
11. Verifique que se muestre el texto **Key pair written to GradesKey.snk**.
12. En **Visual Studio**, en **Explorador de soluciones**, haga clic con el botón derecho en **Grades.Utilities **y, a continuación, haga clic en **Propiedades**.
13. En la pestaña **Firma**, seleccione **Firmar el ensamblaje**.
14. En la lista **Elija un archivo de clave de nombre seguro**, haga clic en **Examinar**.
15. En el cuadro de diálogo **Seleccionar archivo**, busque **[Raíz del repositorio]\AllFiles\Mod12\Labfiles\Starter**, haga clic en **GradesKey.snk** y luego haga clic en **Abrir**.
16. En el menú **Crear**, haga clic en **Crear solución**.
17. Cambie a la ventana **Símbolo del sistema**, escriba el siguiente código y luego presione Entrar:
    ```cs
    cd "[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 3\Grades.Utilities\bin\Debug"
    ```
18. En la ventana **Símbolo del sistema**, escriba el siguiente código y luego presione Entrar:
    ```cs
    gacutil -i Grades.Utilities.dll
    ```
19. Verifique que se muestre el texto **Ensamblado agregado exitosamente a la caché** y luego cierre la ventana **Símbolo del sistema**.

### Tarea 2: Hacer referencia al ensamblado Grades.Utilities en el GAC desde la aplicación

1. En **Visual Studio**, en **Solution Explorer**, expanda **Grades.WPF**, expanda **References**, haga clic con el botón derecho en **Grades.Utilities **y, a continuación, haga clic en **Eliminar**.
2. Haga clic con el botón derecho en **Referencias** y luego haga clic en **Agregar referencia**.
3. En el cuadro de diálogo **Administrador de referencias - Grades.WPF**, haga clic en el botón **Examinar**.
4. En el cuadro de diálogo **Seleccione los archivos para hacer referencia**, vaya a **[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 3\Grades.Utilities\bin\Debug**,
    haga clic en **Grades.Utilities.dll** y luego haga clic en **Agregar**.
5. En el cuadro de diálogo **Administrador de referencias - Grades.WPF**, haga clic en **Aceptar**.
6. En el menú **Crear**, haga clic en **Crear solución**.
7. En el menú **Depurar**, haga clic en **Iniciar sin depurar**.
8. En el cuadro de texto **Nombre de usuario**, escriba **vallee**, y en el cuadro de texto **Password**, escriba **password99** y luego haga clic en **Iniciar sesión**.
9. En la vista **Class 3C**, haga clic en **Kevin Liu**.
10. Verifique que aparezca el informe del estudiante de **Kevin Liu** y luego haga clic en **guardar informe**.
11. En el cuadro de diálogo **Guardar como**, busque la carpeta **[Repository Root]\AllFiles\Mod12\Labfiles\Starter\Exercise 3**.
12. En el cuadro de texto **Nombre de archivo**, escriba **KevinLiuGradesReport** y luego haga clic en **Guardar**.
13. Cierre la aplicación.
14. En **Visual Studio**, en el menú **Archivo**, haga clic en **Cerrar solución**.
15. Abra **Explorador de archivos**, busque **[Raíz del repositorio]\AllFiles\Mod12\Labfiles\Starter\Exercise 3**,
    y luego verifique que se haya generado **KevinLiuGradesReport.docx**.
16. Haga clic con el botón derecho en **KevinLiuGradesReport.docx** y luego haga clic en **Abrir**.
17. Verifique que el documento contenga el informe de calificaciones de **Kevin Liu** y que tenga el formato correcto, y luego cierre **Word**.

> **Resultado:** Después de completar este ejercicio, tendrá una versión firmada del ensamblaje **Grades.Utilities **implementado en el GAC.