Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormControlMuestrasDuplicadas
#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        RadioBentley.Checked = True

    End Sub
#End Region
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        ListBox1.Items.Clear()
        If RadioBentley.Checked = True Then
            Dim fichero As String
            Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
            dlAbrir.Filter = "Todos los archivos (*.*)|*.*"
            dlAbrir.Multiselect = False
            dlAbrir.CheckFileExists = False
            dlAbrir.Title = "Selección de fichero"
            dlAbrir.InitialDirectory = "\\Bentley\results"
            dlAbrir.ShowDialog()
            If dlAbrir.FileName <> "" Then
                fichero = dlAbrir.FileName
                TextArchivo.Text = fichero
            End If
        ElseIf RadioB6.Checked = True Then
            Dim fichero As String
            Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
            dlAbrir.Filter = "Todos los archivos (*.*)|*.*"
            dlAbrir.Multiselect = False
            dlAbrir.CheckFileExists = False
            dlAbrir.Title = "Selección de fichero"
            dlAbrir.InitialDirectory = "\\192.168.1.192\data"
            dlAbrir.ShowDialog()
            If dlAbrir.FileName <> "" Then
                fichero = dlAbrir.FileName
                TextArchivo.Text = fichero
            End If
        ElseIf RadioDelta600.Checked = True Then
            Dim fichero As String
            Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
            dlAbrir.Filter = "Todos los archivos (*.csv)|*.csv"
            dlAbrir.Multiselect = False
            dlAbrir.CheckFileExists = False
            dlAbrir.Title = "Selección de fichero"
            dlAbrir.InitialDirectory = "\\Delta2\Export\CSV"
            dlAbrir.ShowDialog()
            If dlAbrir.FileName <> "" Then
                fichero = dlAbrir.FileName
                TextArchivo.Text = fichero
            End If
        End If

    End Sub

    Private Sub ButtonProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProcesar.Click
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer

        nombrearchivo = TextArchivo.Text.Trim
        linea = 1
        extension = Microsoft.VisualBasic.Right(nombrearchivo, 3)
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim arraytext() As String

        Dim matricula As String = ""
        Dim lista1 As New ArrayList

        ' *** SI EL ARCHIVO ES CSV **************************************************************************************
        If extension = "csv" Or extension = "CSV" Then

            Do
                If RadioB6.Checked = True Then
                    sLine = objReader.ReadLine()
                    If linea = 3 Then
                        arraytext = Split(sLine, ";")
                        If arraytext.Length < 11 Then
                            arraytext = Split(sLine, ";")
                        End If
                    End If
                    If Not sLine Is Nothing Then
                        If linea >= 8 Then
                            arraytext = Split(sLine, ";")
                            If arraytext.Length < 39 Then
                                arraytext = Split(sLine, ";")
                            End If
                            If Trim(arraytext(1)) <> "" Then
                                matricula = Trim(arraytext(1))
                            End If


                        End If
                    End If
                    linea = linea + 1
                    If matricula <> "" Then
                        lista1.Add(matricula)
                    End If
                    matricula = ""
                ElseIf RadioDelta600.Checked = True Then
                    sLine = objReader.ReadLine()
                    If linea = 3 Then
                        arraytext = Split(sLine, ";")
                        If arraytext.Length < 11 Then
                            arraytext = Split(sLine, ";")
                        End If
                    End If
                    If Not sLine Is Nothing Then
                        If linea >= 8 Then
                            arraytext = Split(sLine, ";")
                            If arraytext.Length < 39 Then
                                arraytext = Split(sLine, ";")
                            End If
                            If Trim(arraytext(5)) <> "" Then
                                matricula = Trim(arraytext(5))
                            End If


                        End If
                    End If
                    linea = linea + 1
                    If matricula <> "" Then
                        lista1.Add(matricula)
                    End If
                    matricula = ""
                End If

            Loop Until sLine Is Nothing

            objReader.Close()
        End If
        ' *** SI EL ARCHIVO ES FAT **************************************************************************************
        If extension = "fat" Or extension = "FAT" Then

            Do
                sLine = objReader.ReadLine()


                If Not sLine Is Nothing Then
                    Dim Texto As String
                    Dim id As Integer = 0

                    Texto = sLine
                    id = Trim(Mid(Texto, 1, 8))
                    If Trim(Mid(Texto, 9, 9)) <> "" Then
                        matricula = Trim(Mid(Texto, 9, 9))

                    Else
                        matricula = id

                    End If
                End If
                If matricula <> "" Then
                    lista1.Add(matricula)
                End If
                matricula = ""

            Loop Until sLine Is Nothing
            objReader.Close()
        End If

        ' *** SI EL ARCHIVO ES XLS **************************************************************************************

        If extension = "xls" Or extension = "XLS" Then
            Dim Arch As String, CantFilas As Integer
            Arch = nombrearchivo
            Dim x1app As Microsoft.Office.Interop.Excel.Application
            Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
            Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

            x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
            x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
            x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
            Dim bandera As Integer = 0

            CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count

            For i = 1 To CantFilas
                If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                    matricula = Trim(x1hoja.Cells(i, 1).value)

                Else
                    matricula = -1

                End If
                If matricula <> "" Then
                    lista1.Add(matricula)
                End If
                matricula = ""
            Next

            ' Cierro Excel
            x1libro.Close()
            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
            objReader.Close()

        End If
        '*************************************************************************************************

        Dim ret As ArrayList = New ArrayList()
        Dim elemento As Object
        For Each elemento In lista1
            If Not ret.Contains(elemento) Then
                ret.Add(elemento)
            Else
                ListBox1.Items.Add(elemento)
            End If
        Next
        If ListBox1.Items.Count = 0 Then
            ListBox1.Items.Add("No hay repetidas")
        End If
        lista1 = Nothing
        ret = Nothing
    End Sub
    
End Class