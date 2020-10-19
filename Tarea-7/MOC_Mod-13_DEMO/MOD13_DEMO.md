# Módulo 13: Cifrado y descifrado de datos



Fichero de Instrucciones: Instructions\20483C_MOD03_DEMO.md

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


## Lección 1: Implementación de cifrado simétrico

### Demostración: cifrado y descifrado de datos

#### Pasos de preparación

1. Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navegue a ** [Repository Root] \ Allfiles \ Mod13 \ Democode \ FourthCoffee.MessageSafe **, y luego abra el archivo ** FourthCoffee.MessageSafe.sln **.
    > ** Nota: ** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación ** Preguntarme por cada proyecto en esta solución ** y luego haga clic en ** Aceptar **.
3. En ** Explorador de soluciones **, expanda el proyecto ** FourthCoffee.MessageSafe **, haga doble clic en ** App.config **.
4. Busque la siguiente línea:
    xml
   <add key = "EncryptedFilePath" value = "[Raíz del repositorio] \ Allfiles \ Mod13 \ Democode \ Data" />
    ''
5. Reemplace ** [Repository Root] ** con su ** Ruta del repositorio **.

#### Pasos de demostración

1. En Visual Studio, en el menú ** Ver **, haga clic en ** Lista de tareas **.
2. En la ventana ** Lista de tareas **, haga doble clic en la tarea ** TODO: 01: Crear una instancia del objeto _algorithm **.
3. Explique que el siguiente código crea una instancia de la clase ** AesManaged **.
    `` `cs
    this._algorithm = new AesManaged ();
    ''
4. Haga doble clic en la tarea ** TODO: 02: Dispose of the _algorithm object **.
5. Explique que el siguiente código invoca el método ** Dispose ** para liberar cualquier recurso que el algoritmo pueda haber usado después de determinar que el objeto ** _ algoritmo ** no es nulo.
    `` `cs
    si (this._algorithm! = null)
    {
        this._algorithm.Dispose ();
    }
    ''
6. Haga doble clic en ** TODO: 03: Derive a Rfc2898DeriveBytes object from the password and salt ** task.
7. Explique que el siguiente código crea una instancia de la clase ** Rfc2898DeriveBytes ** mediante el uso de una contraseña (que el usuario proporciona en tiempo de ejecución) y salt (valor codificado en la aplicación).
    `` `cs
    devolver nuevo Rfc2898DeriveBytes (contraseña, this._salt);
    ''
8. Haga doble clic en ** TODO: 04: Generar la clave secreta mediante la tarea del objeto Rfc2898DeriveBytes **.
9. Explique que el siguiente código usa el objeto ** Rfc2898DeriveBytes ** para derivar la clave secreta usando el tamaño de clave del algoritmo en bytes.
    `` `cs
    return passwordHash.GetBytes (this._algorithm.KeySize / 8);
    ''
    > ** Nota: ** La propiedad ** KeySize ** devuelve el tamaño de la clave en bits, por lo que para obtener el valor en bytes, divide el valor entre 8.
10. Haga doble clic en ** TODO: 05: Generar el IV mediante la tarea del objeto Rfc2898DeriveBytes **.
11. Explique que el siguiente código usa el objeto ** Rfc2898DeriveBytes ** para derivar el IV usando el tamaño de bloque del algoritmo en bytes.
    `` `cs
    return passwordHash.GetBytes (this._algorithm.BlockSize / 8);
    ''
    > ** Nota: ** La propiedad ** BlockSize ** devuelve el tamaño del bloque en bits, por lo que para obtener el valor en bytes, divide el valor entre 8.
12. Haga doble clic en la tarea ** TODO: 06: Create a new MemoryStream object **.
13. Explique que el siguiente código crea una instancia de la clase ** MemoryStream **, que se utilizará como búfer para los datos transformados.
    `` `cs
    var bufferStream = new MemoryStream ();
    ''
14. Haga doble clic en la tarea ** TODO: 07: Create a new CryptoStream object **.
15. Explique que el siguiente código crea una instancia de la clase ** CryptoStream **, que transformará los datos y los escribirá en el flujo de memoria subyacente.
    `` `cs
    var cryptoStream = nuevo CryptoStream (bufferStream, transformador, CryptoStreamMode.Write);
    ''
16. Haga doble clic en la tarea ** TODO: 08: Write the bytes to the CryptoStream object **.
17. Explique que el siguiente código escribe los datos transformados en el flujo de memoria subyacente.
    `` `cs
    cryptoStream.Write (bytesToTransform, 0, bytesToTransform.Length);
    cryptoStream.FlushFinalBlock ();
    ''
18. Haga doble clic en ** TODO: 09: Leer los bytes transformados del objeto MemoryStream ** tarea.
19. Explique que el siguiente código usa el método ** ToArray ** para extraer los datos transformados del flujo de memoria como una matriz de bytes.
    `` `cs
    var transformBytes = bufferStream.ToArray ();
    ''
20. Haga doble clic en ** TODO: 10: Cerrar los objetos CryptoStream y MemoryStream ** tarea.
21. Explique que el siguiente código cierra los objetos ** cryptoStream ** y ** bufferStream **.
    `` `cs
    cryptoStream.Close ();
    bufferStream.Close ();
    ''
22. Haga doble clic en ** TODO: 11: Use el objeto _algorithm para crear una tarea de objeto de cifrado ICryptoTransform **.
23. Explique que el siguiente código crea un objeto ** ICryptoTransform ** que cifrará los datos.
    `` `cs
    var transformer = this._algorithm.CreateEncryptor (clave, iv);
    ''
24. Haga doble clic en la tarea ** TODO: 12: Invoke the TransformBytes y devuelva los bytes ** cifrados.
25. Explique que el siguiente código invoca el método auxiliar ** TransformBytes **, que utilizará el objeto ** ICryptoTransform ** para cifrar los datos.
    `` `cs
    return this.TransformBytes (transformador, bytesToEncypt);
    ''
26. Haga doble clic en ** TODO: 13: Use el objeto _algorithm para crear una tarea ** del objeto descifrador ICryptoTransform.
27. Explique que el siguiente código crea un objeto ** ICryptoTransform ** que descifrará los datos.
    `` `cs
    var transformer = this._algorithm.CreateDecryptor (clave, iv);
    ''
28. Haga doble clic en ** TODO: 14: Invoque el método TransformBytes y devuelva la tarea ** de bytes descifrados.
29. Explique que el siguiente código invoca el método auxiliar ** TransformBytes **, que utilizará el objeto ** ICryptoTransform ** para descifrar los datos.
    `` `cs
    return this.TransformBytes (transformador, bytesToDecypt);
    ''
30. En el menú ** Crear **, haga clic en ** Crear solución **.
31. En el menú ** Depurar **, haga clic en ** Iniciar sin depurar **.
32. En la aplicación ** Fourth Coffee Message Safe **, en el cuadro de texto ** Contraseña **, escriba ** Pa $$ w0rd **.
33. En el cuadro de texto ** Mensaje **, escriba ** Este es mi mensaje seguro ** y luego haga clic en ** Guardar **.
34. Cierre la aplicación ** Fourth Coffee Message Safe **.
35. Abra el Explorador de archivos y busque la carpeta ** [Repository Root] \ Allfiles \ Mod13 \ Democode \ Data **.
36. Haga doble clic en ** protected_message.txt ** y luego vea el texto encriptado en el Bloc de notas.
37. Cierre el Bloc de notas y luego cierre el Explorador de archivos.
38. En Visual Studio, en el menú ** Depurar **, haga clic en ** Iniciar sin depurar **.
39. En la aplicación ** Fourth Coffee Message Safe **, en el cuadro de texto ** Contraseña **, escriba ** Pa $$ w0rd ** y luego haga clic en ** Cargar **.
40. Verifique que el cuadro de texto ** Mensaje ** ahora muestre el texto ** Este es mi mensaje seguro **.
41. Cierre la aplicación ** Fourth Coffee Message Safe **.
42. Cierre Visual Studio 2017.

## Lección 2: Implementación del cifrado asimétrico

### Demostración: Laboratorio de cifrado y descifrado de informes de calificaciones

#### Pasos de preparación

1. Asegúrese de haber clonado el directorio 20483C de GitHub. Contiene los segmentos de código para los laboratorios y demostraciones de este curso. (** https: //github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Inicialice la base de datos.
   - En la lista ** Aplicaciones **, haga clic en ** Explorador de archivos **.
   - En el Explorador de archivos, navegue a la carpeta ** [Repository Root] \ Allfiles \ Mod13 \ Labfiles \ Databases ** y luego haga doble clic en ** SetupSchoolGradesDB.cmd **.
    > ** NOTA: ** Si aparece un cuadro de diálogo de Windows protegió su PC, haga clic en ** Más información ** y luego haga clic en ** Ejecutar de todos modos **.
   - Cierre el Explorador de archivos.

#### Pasos de demostración

1. Desde la carpeta ** [Repository Root] \ Allfiles \ Mod13 \ Labfiles \ Solution \ Exercise 1 **, abra la solución ** Grades.sln **.
    > ** Nota: ** Si aparece algún cuadro de diálogo de advertencia de seguridad, desactive la casilla de verificación ** Preguntarme por cada proyecto en esta solución ** y luego haga clic en ** Aceptar **.
2. En ** Explorador de soluciones **, haga clic con el botón derecho en ** "Calificaciones" de la solución ** y, a continuación, haga clic en ** Propiedades **.
3. En la página ** Proyecto de inicio **, haga clic en ** Varios proyectos de inicio **. Establezca ** Grades.Web ** y ** Grades.WPF ** en ** Inicio ** y luego haga clic en ** Aceptar **.
4. Abra ** Menú de Windows ** y escriba ** Símbolo del sistema para desarrolladores para VS 2017 **, haga clic con el botón derecho en la aplicación y luego seleccione ** Ejecutar como administrador **.
5. Pegue el siguiente comando y luego presione ** Enter **:
    `` `cs
    cd "[Raíz del repositorio] \ Allfiles \ Mod13 \ Labfiles \ Solution \ Exercise 1 \ Grades.Utilities"
    ''
6. Pegue el siguiente comando y luego presione ** Enter **:
    `` `cs
    CreateCertificate.cmd
    ''
7. Explique que este archivo de comando crea un nuevo certificado que los estudiantes usarán para encriptar el informe de calificaciones.
8. Señale que los estudiantes deben ejecutar la ventana del símbolo del sistema como administrador para que el comando tenga éxito.
9. En la carpeta ** Grades.Utilities **, abra ** WordWrapper.cs ** y luego busque el método ** EncryptWithX509 **.
10. Explique a los estudiantes que durante el Ejercicio 1, agregarán el código en este método para cifrar el informe de calificaciones.
11. Ejecute la aplicación y luego inicie sesión como ** vallee ** con la contraseña ** contraseña99 **.
12. Genere informes de calificaciones para ** George Li ** y ** Kevin Liu **. Guarde cada informe en la carpeta ** [Repository Root] \ AllFiles \\ Mod13 \ Labfiles \ Reports **.
13. Cierre la aplicación y luego intente abrir uno de los informes que creó en el paso anterior utilizando el Bloc de notas para mostrar los datos cifrados.
14. Desde la carpeta ** [Repository Root] \ Allfiles \ Mod13 \ Labfiles \ Solution \ Exercise 2 **, abra la solución ** Schools-Reports.sln **.
15. Abra ** WordWrapper.cs ** y luego busque el método ** DecryptWithX509 **.
16. Explique a los estudiantes que durante el ejercicio 2, agregarán el código en este método para descifrar los informes.
17. Ejecute la aplicación y luego imprima un informe compuesto que contiene los dos informes que generó anteriormente. Guarde el archivo ** CompositeReport ** en la carpeta ** [Repository Root] \ Allfiles \ Mod13 \ Labfiles \ Reports \ ClassReport **.
18. Cierre la aplicación, haga clic en Detener depuración y luego cierre Visual Studio.
19. Abra el informe compuesto haciendo doble clic en el archivo.
20. Abra el Explorador de archivos y elimine el contenido de las carpetas ** [Repository Root] \ Allfiles \ Mod13 \ Labfiles \ Reports ** y ** [Repository Root] \ Allfiles \ Mod13 \ Labfiles \ Reports \ ClassReport ** y luego cierre Explorador de archivos.

© 2018 Microsoft Corporation. Todos los derechos reservados.

El texto de este documento está disponible bajo la [Licencia Creative Commons Attribution 3.0] (https://creativecommons.org/licenses/by/3.0/legalcode), se pueden aplicar términos adicionales. Todo el resto del contenido de este documento (incluidas, entre otras, marcas comerciales, logotipos, imágenes, etc.) ** no ** está incluido en la concesión de la licencia Creative Commons. Este documento no le proporciona ningún derecho legal sobre la propiedad intelectual de ningún producto de Microsoft. Puede copiar y utilizar este documento para fines internos de referencia.

Este documento se proporciona "tal cual". La información y las opiniones expresadas en este documento, incluidas las URL y otras referencias a sitios web de Internet, pueden cambiar sin previo aviso. Usted asume el riesgo de utilizarlo. Algunos ejemplos son solo ilustrativos y son ficticios. No se pretende ni se infiere ninguna asociación real. Microsoft no ofrece ninguna garantía, expresa o implícita, con respecto a la información proporcionada aquí.