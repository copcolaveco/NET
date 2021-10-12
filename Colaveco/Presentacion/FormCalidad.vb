Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormCalidad
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        calidad()
        ibc()

    End Sub
#End Region

    
    Private Sub calidad()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("C:\calidad")
        For Each file As FileInfo In folder.GetFiles()
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader As New StreamReader("c:\calidad\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()
            Dim arraytext() As String

            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim equipo As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0
            ' *** SI EL ARCHIVO ES CSV **************************************************************************************
            If extension = "csv" Or extension = "CSV" Then
                Dim c As New dCalidad()
                Do
                    sLine = objReader.ReadLine()
                    If linea = 3 Then
                        arraytext = Split(sLine, ";")
                        producto = Trim(arraytext(10))
                    End If
                    If Not sLine Is Nothing Then
                        If linea >= 8 Then
                            'arrText.Add(sLine)
                            arraytext = Split(sLine, ";")

                            matricula = arraytext(5)
                            If Trim(arraytext(13)) <> "" Then
                                grasa = arraytext(13)
                            Else
                                grasa = -1
                            End If
                            If Trim(arraytext(14)) <> "" Then
                                proteina = arraytext(14)
                            Else
                                proteina = -1
                            End If
                            If Trim(arraytext(15)) <> "" Then
                                lactosa = arraytext(15)
                            Else
                                lactosa = -1
                            End If
                            If Trim(arraytext(16)) <> "" Then
                                st = arraytext(16)
                            Else
                                st = -1
                            End If
                            If Trim(arraytext(11)) <> "" Then
                                rc = arraytext(11)
                            Else
                                rc = -1
                            End If
                            If Trim(arraytext(17)) <> "" Then
                                crioscopia = arraytext(17)
                            Else
                                crioscopia = -1
                            End If
                            If Trim(arraytext(18)) <> "" Then
                                urea = arraytext(18)
                            Else
                                urea = -1
                            End If
                            If Trim(arraytext(28)) <> "" Then
                                proteinav = arraytext(28)
                            Else
                                proteinav = -1
                            End If
                            If Trim(arraytext(29)) <> "" Then
                                caseina = arraytext(29)
                            Else
                                caseina = -1
                            End If
                            If Trim(arraytext(30)) <> "" Then
                                densidad = arraytext(30)
                            Else
                                densidad = -1
                            End If
                            If Trim(arraytext(36)) <> "" Then
                                ph = arraytext(36)
                            Else
                                ph = -1
                            End If
                            ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                            If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                                ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                            Else
                                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                            End If
                            Dim fechaoriginal As Date = Now()
                            Dim fecha As String
                            fecha = Format(fechaoriginal, "yyyy-MM-dd")

                            c.FICHA = ficha
                            c.FECHA = fecha
                            c.EQUIPO = "delta"
                            c.PRODUCTO = producto
                            c.MUESTRA = matricula
                            c.RC = rc
                            c.GRASA = grasa
                            c.PROTEINA = proteina
                            c.LACTOSA = lactosa
                            c.ST = st
                            c.CRIOSCOPIA = -1
                            c.UREA = -1
                            c.PROTEINAV = -1
                            c.CASEINA = -1
                            c.DENSIDAD = -1
                            c.PH = -1
                            c.guardar(Usuario)
                        End If
                    End If
                    linea = linea + 1
                Loop Until sLine Is Nothing
                objReader.Close()
            End If
            ' *** SI EL ARCHIVO ES FAT **************************************************************************************
            If extension = "fat" Or extension = "FAT" Then
                Dim c As New dCalidad()
                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        Dim Texto As String
                        Dim id As Integer = 0

                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                        Else
                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                        End If
                        Dim fechaoriginal As Date = Now()
                        Dim fecha As String
                        fecha = Format(fechaoriginal, "yyyy-MM-dd")
                        Texto = sLine
                        id = Trim(Mid(Texto, 1, 8))
                        matricula = Trim(Mid(Texto, 9, 9))
                        If Trim(Mid(Texto, 18, 9)) <> "" Then
                            grasa = Trim(Mid(Texto, 18, 9))
                        Else
                            grasa = -1
                        End If
                        If Trim(Mid(Texto, 27, 9)) <> "" Then
                            proteina = Trim(Mid(Texto, 27, 9))
                        Else
                            proteina = -1
                        End If
                        If Trim(Mid(Texto, 36, 9)) <> "" Then
                            lactosa = Trim(Mid(Texto, 36, 9))
                        Else
                            lactosa = -1
                        End If
                        If Trim(Mid(Texto, 45, 9)) <> "" Then
                            st = Trim(Mid(Texto, 45, 9))
                        Else
                            st = -1
                        End If
                        If Trim(Mid(Texto, 54, 10)) <> "" Then
                            rc = Trim(Mid(Texto, 54, 10))
                        Else
                            rc = -1
                        End If

                        c.FICHA = ficha
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = rc
                        c.GRASA = grasa
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar(Usuario)
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()
            End If
            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim c As New dCalidad()
                Dim Arch As String, CantFilas As Integer
                Arch = "c:\calidad\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count

                ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                    ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                Else
                    ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                End If
                Dim fechaoriginal As Date = Now()
                Dim fecha As String
                fecha = Format(fechaoriginal, "yyyy-MM-dd")

                For i = 1 To CantFilas
                    If Trim(x1hoja.Cells(i, 2).formula) <> "" Then
                        matricula = x1hoja.Cells(i, 2).value
                    Else
                        matricula = -1
                    End If
                    If Trim(x1hoja.Cells(i, 3).formula) <> "" Then
                        grasa = x1hoja.Cells(i, 3).value
                    Else
                        grasa = -1
                    End If
                    If Trim(x1hoja.Cells(i, 4).formula) <> "" Then
                        proteina = x1hoja.Cells(i, 4).value
                        bandera = 1
                    Else
                        proteina = -1
                    End If
                    If Trim(x1hoja.Cells(i, 5).formula) <> "" Then
                        lactosa = x1hoja.Cells(i, 5).value
                    Else
                        lactosa = -1
                    End If
                    If Trim(x1hoja.Cells(i, 6).formula) <> "" Then
                        st = x1hoja.Cells(i, 6).value
                    Else
                        st = -1
                    End If
                    If Trim(x1hoja.Cells(i, 7).formula) <> "" Then
                        rc = x1hoja.Cells(i, 7).value
                    Else
                        rc = -1
                    End If

                    If bandera = 0 Then
                        c.FICHA = ficha
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = grasa
                        c.GRASA = -1
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar(Usuario)
                    ElseIf bandera = 1 Then
                        c.FICHA = ficha
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = rc
                        c.GRASA = grasa
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar(Usuario)
                    End If
                Next

                ' Cierro Excel
                x1libro.Close()
                x1app = Nothing
                x1libro = Nothing
                x1hoja = Nothing
                objReader.Close()

                Dim proceso As System.Diagnostics.Process()
                proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                For Each opro As System.Diagnostics.Process In proceso
                    'antes de iniciar el proceso obtengo la fecha en que inicie el 
                    'proceso para detener todos los procesos que excel que inicio
                    'mi código durante el proceso
                    opro.Kill()

                Next

            End If

            '*** MOVER ARCHIVO ***********************************************************************
            Dim sArchivoOrigen As String = "c:\calidad\" & nombrearchivo
            Dim sRutaDestino As String = "c:\calidad\pasados\" & nombrearchivo

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        Next
    End Sub
    Private Sub ibc()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("C:\ibc")
        For Each file As FileInfo In folder.GetFiles()
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            Dim objReader2 As New StreamReader("c:\ibc\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()
            Dim arraytext() As String

            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim muestra As String = ""
            Dim idibc As Integer = 0
            Dim ibc As Long = 0
            Dim rb As Integer = 0
            
            ' *** SI EL ARCHIVO ES CSV **************************************************************************************
            If extension = "csv" Or extension = "CSV" Then
                Dim c As New dIbc()
                Do
                    sLine = objReader2.ReadLine()
                    
                    If Not sLine Is Nothing Then
                        'arrText.Add(sLine)
                        arraytext = Split(sLine, ",")

                        If Trim(arraytext(1)) <> "" Then
                            muestra = arraytext(1)
                        Else
                            If Trim(arraytext(7)) <> "" Then
                                muestra = arraytext(7)
                            Else
                                muestra = "error"
                            End If
                        End If
                        If Trim(arraytext(2)) <> "" Then
                            idibc = arraytext(2)
                        Else
                            idibc = -1
                        End If
                        If Trim(arraytext(4)) <> "" Then
                            ibc = arraytext(4)
                        Else
                            ibc = -1
                        End If
                        If Trim(arraytext(5)) <> "" Then
                            rb = arraytext(5)
                        Else
                            rb = -1
                        End If

                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                        Else
                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                        End If
                        Dim fechaoriginal As Date = Now()
                        Dim fecha As String
                        fecha = Format(fechaoriginal, "yyyy-MM-dd")

                        c.FICHA = ficha
                        c.MUESTRA = muestra
                        c.IDIBC = idibc
                        c.IBC = ibc
                        c.RB = rb
                        c.FECHA = fecha
                        c.guardar(Usuario)
                    End If
                        linea = linea + 1
                Loop Until sLine Is Nothing
                objReader2.Close()
            End If
            
            '*** MOVER ARCHIVO ***********************************************************************
            Dim sArchivoOrigen As String = "c:\ibc\" & nombrearchivo
            Dim sRutaDestino As String = "c:\ibc\pasados\" & nombrearchivo

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        Next
    End Sub
End Class