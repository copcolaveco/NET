Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormRgLab51_carga
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarultimos()
        limpiar()
        DateFecha.Value = Now
    End Sub
    Private Sub cargarultimos()
        Dim rglab51b As New dRgLab51
        Dim rglab51d As New dRgLab51
        Dim bentley As String = ""
        Dim delta As String = ""
        rglab51b = rglab51b.buscarultimobentley
        If Not rglab51b Is Nothing Then
            bentley = rglab51b.FECHA
        End If
        rglab51d = rglab51d.buscarultimodelta
        If Not rglab51d Is Nothing Then
            delta = rglab51d.FECHA
        End If

        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(2)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1(columna, fila).Value = "Bentley"
        columna = columna + 1
        DataGridView1(columna, fila).Value = bentley
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = "Delta"
        columna = columna + 1
        DataGridView1(columna, fila).Value = delta
        columna = 0
        fila = fila + 1
    End Sub
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.*)|*.*"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\Bentley\results"
        'dlAbrir.InitialDirectory = "c:\rglab51"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextArchivoBentley.Text = fichero
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.*)|*.*"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\DELTA\Samples"
        'dlAbrir.InitialDirectory = "c:\rglab51"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextArchivoDelta1.Text = fichero
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.*)|*.*"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\DELTA\Samples"
        'dlAbrir.InitialDirectory = "c:\rglab51"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextArchivoDelta2.Text = fichero
        End If
    End Sub
    Private Sub limpiar()
        TextArchivoBentley.Text = ""
        TextArchivoDelta1.Text = ""
        TextArchivoDelta2.Text = ""
    End Sub

    Private Sub ButtonProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProcesar.Click
        If TextArchivoBentley.Text <> "" Then
            procesar_bentley()
            generarinformesbentley()
        End If
        If TextArchivoDelta1.Text <> "" And TextArchivoDelta2.Text <> "" Then
            procesar_delta1()
            procesar_delta2()
            generarinformesdelta()
        End If
        If TextArchivoBentley.Text <> "" And TextArchivoDelta1.Text <> "" And TextArchivoDelta2.Text <> "" Then
            generarrglab58()
        End If
        limpiar()
        Dim v As New FormRgLab51
        v.Show()
        Dim v2 As New FormRgLab58
        v2.Show()
        Me.Close()
    End Sub
    Private Sub procesar_bentley()

        Dim nombrearchivo As String = ""
        nombrearchivo = TextArchivoBentley.Text.Trim
        Dim linea As Integer
        linea = 1
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""

        Dim id As String = 0
      
        Dim fechaoriginal As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecha As String
        fecha = Format(fechaoriginal, "yyyy-MM-dd")
        Dim rc As Integer = 0
        Dim rc2 As String = ""

        Dim rg51 As New dRgLab51
        Dim cuentalinea As Long = 1
        Dim largo As Integer = 0
        Do
            If cuentalinea <= 40 Then
                sLine = objReader.ReadLine()
                largo = sLine.Length
                If Not sLine Is Nothing Then
                    If largo < 40 Then
                        Dim Texto As String
                        Texto = sLine
                        id = Microsoft.VisualBasic.Left(Texto, 2)
                        rc = Microsoft.VisualBasic.Right(Texto, 4)

                    Else
                        Dim Texto As String
                        Texto = sLine
                        id = Microsoft.VisualBasic.Left(Texto, 9)
                        rc = Microsoft.VisualBasic.Right(Texto, 4)
                    End If
                End If
                If cuentalinea <= 40 Then
                    rg51.FECHA = fecha
                    rg51.EQUIPO = "Bentley"
                    rg51.OPERADOR = Usuario.ID
                    rg51.MUESTRA = id
                    rg51.RESULTADO = rc
                    rg51.guardar(Usuario)
                End If
                cuentalinea = cuentalinea + 1
            Else
                objReader.Close()
                Exit Sub
            End If
        Loop Until sLine Is Nothing

       
    End Sub
    Private Sub procesar_delta1()
        Dim nombrearchivo As String = ""
        nombrearchivo = TextArchivoDelta1.Text.Trim
        Dim linea As Integer = 1
      
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim arraytext() As String

        Dim matricula As Integer = 0
        Dim rc As Integer = 0
        Dim fechaoriginal As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecha As String
        fecha = Format(fechaoriginal, "yyyy-MM-dd")
      
        Dim rg51 As New dRgLab51

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then

                If linea >= 8 Then
                    'arrText.Add(sLine)
                    arraytext = Split(sLine, ";")
                    'If arraytext.Length < 39 Then
                    '    arraytext = Split(sLine, ",")
                    'End If
                    If Trim(arraytext(0)) <> "" Then
                        matricula = Trim(arraytext(0))
                        If arraytext.Length <= 13 Then
                            If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                Try
                                    rc = arraytext(11)
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombrearchivo & ", línea: " & linea & ", valor: RC")
                                    Exit Sub
                                End Try
                            Else
                                rc = -1
                            End If
                        Else
                            Dim prueba As String
                            prueba = Trim(arraytext(13))
                            If prueba <> "-" Then
                                If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                    Try
                                        rc = arraytext(11)
                                    Catch ex As Exception
                                        MsgBox("Error en archivo: " & nombrearchivo & ", línea: " & linea & ", valor: RC")
                                        Exit Sub
                                    End Try
                                Else
                                    rc = -1
                                End If
                            Else
                                rc = -1
                            End If
                        End If

                        rg51.FECHA = fecha
                        rg51.EQUIPO = "Delta"
                        rg51.OPERADOR = Usuario.ID
                        rg51.MUESTRA = matricula
                        rg51.RESULTADO = rc
                        rg51.guardar(Usuario)

                    End If
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing

        objReader.Close()


    End Sub
    Private Sub procesar_delta2()
        Dim nombrearchivo As String = ""
        nombrearchivo = TextArchivoDelta2.Text.Trim
        Dim linea As Integer = 1

        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim arraytext() As String

        Dim matricula As Integer = 0
        Dim rc As Integer = 0
        Dim fechaoriginal As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecha As String
        fecha = Format(fechaoriginal, "yyyy-MM-dd")

        Dim rg51 As New dRgLab51

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then

                If linea >= 8 Then
                    'arrText.Add(sLine)
                    arraytext = Split(sLine, ";")
                    'If arraytext.Length < 39 Then
                    '    arraytext = Split(sLine, ",")
                    'End If
                    If Trim(arraytext(0)) <> "" Then
                        matricula = Trim(arraytext(0))
                        If arraytext.Length <= 13 Then
                            If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                Try
                                    rc = arraytext(11)
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & nombrearchivo & ", línea: " & linea & ", valor: RC")
                                    Exit Sub
                                End Try
                            Else
                                rc = -1
                            End If
                        Else
                            Dim prueba As String
                            prueba = Trim(arraytext(13))
                            If prueba <> "-" Then
                                If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                    Try
                                        rc = arraytext(11)
                                    Catch ex As Exception
                                        MsgBox("Error en archivo: " & nombrearchivo & ", línea: " & linea & ", valor: RC")
                                        Exit Sub
                                    End Try
                                Else
                                    rc = -1
                                End If
                            Else
                                rc = -1
                            End If
                        End If
                        matricula = matricula + 20
                        rg51.FECHA = fecha
                        rg51.EQUIPO = "Delta"
                        rg51.OPERADOR = Usuario.ID
                        rg51.MUESTRA = matricula
                        rg51.RESULTADO = rc
                        rg51.guardar(Usuario)

                    End If
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing

        objReader.Close()
    End Sub
    Private Sub generarinformesbentley()
        Dim rg51 As New dRgLab51
        Dim fechaoriginal As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecha As String
        fecha = Format(fechaoriginal, "yyyy-MM-dd")
        Dim equipo As String = "Bentley"
        Dim contador As Integer = 1
        Dim v1 As Integer = 0
        Dim v2 As Integer = 0
        Dim v3 As Integer = 0
        Dim v4 As Integer = 0
        Dim v5 As Integer = 0
        Dim v6 As Integer = 0
        Dim v7 As Integer = 0
        Dim v8 As Integer = 0
        Dim v9 As Integer = 0
        Dim v10 As Integer = 0
        Dim v11 As Integer = 0
        Dim v12 As Integer = 0
        Dim v13 As Integer = 0
        Dim v14 As Integer = 0
        Dim v15 As Integer = 0
        Dim v16 As Integer = 0
        Dim v17 As Integer = 0
        Dim v18 As Integer = 0
        Dim v19 As Integer = 0
        Dim v20 As Integer = 0
        Dim v21 As Integer = 0
        Dim v22 As Integer = 0
        Dim v23 As Integer = 0
        Dim v24 As Integer = 0
        Dim v25 As Integer = 0
        Dim v26 As Integer = 0
        Dim v27 As Integer = 0
        Dim v28 As Integer = 0
        Dim v29 As Integer = 0
        Dim v30 As Integer = 0
        Dim v31 As Integer = 0
        Dim v32 As Integer = 0
        Dim v33 As Integer = 0
        Dim v34 As Integer = 0
        Dim v35 As Integer = 0
        Dim v36 As Integer = 0
        Dim v37 As Integer = 0
        Dim v38 As Integer = 0
        Dim v39 As Integer = 0
        Dim v40 As Integer = 0
        Dim promedio1 As Double = 0
        Dim promedio2 As Double = 0
        Dim promedio3 As Double = 0
        Dim promedio4 As Double = 0
        Dim promedio5 As Double = 0
        Dim promedio6 As Double = 0
        Dim promedio7 As Double = 0
        Dim promedio8 As Double = 0
        Dim promedio9 As Double = 0
        Dim promedio10 As Double = 0
        Dim promedio11 As Double = 0
        Dim promedio12 As Double = 0
        Dim promedio13 As Double = 0
        Dim promedio14 As Double = 0
        Dim promedio15 As Double = 0
        Dim promedio16 As Double = 0
        Dim promedio17 As Double = 0
        Dim promedio18 As Double = 0
        Dim promedio19 As Double = 0
        Dim promedio20 As Double = 0
        Dim difmax1 As Integer = 0
        Dim difmax2 As Integer = 0
        Dim difmax3 As Integer = 0
        Dim difmax4 As Integer = 0
        Dim difmax5 As Integer = 0
        Dim difmax6 As Integer = 0
        Dim difmax7 As Integer = 0
        Dim difmax8 As Integer = 0
        Dim difmax9 As Integer = 0
        Dim difmax10 As Integer = 0
        Dim difmax11 As Integer = 0
        Dim difmax12 As Integer = 0
        Dim difmax13 As Integer = 0
        Dim difmax14 As Integer = 0
        Dim difmax15 As Integer = 0
        Dim difmax16 As Integer = 0
        Dim difmax17 As Integer = 0
        Dim difmax18 As Integer = 0
        Dim difmax19 As Integer = 0
        Dim difmax20 As Integer = 0
        Dim dif1 As Integer = 0
        Dim dif2 As Integer = 0
        Dim dif3 As Integer = 0
        Dim dif4 As Integer = 0
        Dim dif5 As Integer = 0
        Dim dif6 As Integer = 0
        Dim dif7 As Integer = 0
        Dim dif8 As Integer = 0
        Dim dif9 As Integer = 0
        Dim dif10 As Integer = 0
        Dim dif11 As Integer = 0
        Dim dif12 As Integer = 0
        Dim dif13 As Integer = 0
        Dim dif14 As Integer = 0
        Dim dif15 As Integer = 0
        Dim dif16 As Integer = 0
        Dim dif17 As Integer = 0
        Dim dif18 As Integer = 0
        Dim dif19 As Integer = 0
        Dim dif20 As Integer = 0

        Dim alerta1 As Integer = 80
        Dim alerta2 As Integer = 80
        Dim alerta3 As Integer = 80
        Dim alerta4 As Integer = 80
        Dim alerta5 As Integer = 80
        Dim alerta6 As Integer = 80
        Dim alerta7 As Integer = 80
        Dim alerta8 As Integer = 80
        Dim alerta9 As Integer = 80
        Dim alerta10 As Integer = 80
        Dim alerta11 As Integer = 80
        Dim alerta12 As Integer = 80
        Dim alerta13 As Integer = 80
        Dim alerta14 As Integer = 80
        Dim alerta15 As Integer = 80
        Dim alerta16 As Integer = 80
        Dim alerta17 As Integer = 80
        Dim alerta18 As Integer = 80
        Dim alerta19 As Integer = 80
        Dim alerta20 As Integer = 80

        Dim porcentaje1 As Double = 0
        Dim porcentaje2 As Double = 0
        Dim porcentaje3 As Double = 0
        Dim porcentaje4 As Double = 0
        Dim porcentaje5 As Double = 0
        Dim porcentaje6 As Double = 0
        Dim porcentaje7 As Double = 0
        Dim porcentaje8 As Double = 0
        Dim porcentaje9 As Double = 0
        Dim porcentaje10 As Double = 0
        Dim porcentaje11 As Double = 0
        Dim porcentaje12 As Double = 0
        Dim porcentaje13 As Double = 0
        Dim porcentaje14 As Double = 0
        Dim porcentaje15 As Double = 0
        Dim porcentaje16 As Double = 0
        Dim porcentaje17 As Double = 0
        Dim porcentaje18 As Double = 0
        Dim porcentaje19 As Double = 0
        Dim porcentaje20 As Double = 0

        Dim resultado1 As Integer = 0
        Dim resultado2 As Integer = 0
        Dim resultado3 As Integer = 0
        Dim resultado4 As Integer = 0
        Dim resultado5 As Integer = 0
        Dim resultado6 As Integer = 0
        Dim resultado7 As Integer = 0
        Dim resultado8 As Integer = 0
        Dim resultado9 As Integer = 0
        Dim resultado10 As Integer = 0
        Dim resultado11 As Integer = 0
        Dim resultado12 As Integer = 0
        Dim resultado13 As Integer = 0
        Dim resultado14 As Integer = 0
        Dim resultado15 As Integer = 0
        Dim resultado16 As Integer = 0
        Dim resultado17 As Integer = 0
        Dim resultado18 As Integer = 0
        Dim resultado19 As Integer = 0
        Dim resultado20 As Integer = 0

        Dim lista As New ArrayList
        lista = rg51.listarxfechaxequipo(fecha, equipo)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each rg51 In lista
                    If rg51.MUESTRA = 1 Then
                        v1 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 2 Then
                        v2 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 3 Then
                        v3 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 4 Then
                        v4 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 5 Then
                        v5 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 6 Then
                        v6 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 7 Then
                        v7 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 8 Then
                        v8 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 9 Then
                        v9 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 10 Then
                        v10 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 11 Then
                        v11 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 12 Then
                        v12 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 13 Then
                        v13 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 14 Then
                        v14 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 15 Then
                        v15 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 16 Then
                        v16 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 17 Then
                        v17 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 18 Then
                        v18 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 19 Then
                        v19 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 20 Then
                        v20 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 21 Then
                        v21 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 22 Then
                        v22 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 23 Then
                        v23 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 24 Then
                        v24 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 25 Then
                        v25 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 26 Then
                        v26 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 27 Then
                        v27 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 28 Then
                        v28 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 29 Then
                        v29 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 30 Then
                        v30 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 31 Then
                        v31 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 32 Then
                        v32 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 33 Then
                        v33 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 34 Then
                        v34 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 35 Then
                        v35 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 36 Then
                        v36 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 37 Then
                        v37 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 38 Then
                        v38 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 39 Then
                        v39 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 40 Then
                        v40 = rg51.RESULTADO
                    End If
                Next
            End If
        End If

        promedio1 = (v1 + v21) / 2
        promedio2 = (v2 + v22) / 2
        promedio3 = (v3 + v23) / 2
        promedio4 = (v4 + v24) / 2
        promedio5 = (v5 + v25) / 2
        promedio6 = (v6 + v26) / 2
        promedio7 = (v7 + v27) / 2
        promedio8 = (v8 + v28) / 2
        promedio9 = (v9 + v29) / 2
        promedio10 = (v10 + v30) / 2
        promedio11 = (v11 + v31) / 2
        promedio12 = (v12 + v32) / 2
        promedio13 = (v13 + v33) / 2
        promedio14 = (v14 + v34) / 2
        promedio15 = (v15 + v35) / 2
        promedio16 = (v16 + v36) / 2
        promedio17 = (v17 + v37) / 2
        promedio18 = (v18 + v38) / 2
        promedio19 = (v19 + v39) / 2
        promedio20 = (v20 + v40) / 2

        If promedio1 <= 150 Then
            difmax1 = 25
        ElseIf promedio1 <= 300 Then
            difmax1 = 42
        ElseIf promedio1 <= 450 Then
            difmax1 = 50
        ElseIf promedio1 <= 750 Then
            difmax1 = 63
        Else
            difmax1 = 126
        End If

        If promedio2 <= 150 Then
            difmax2 = 25
        ElseIf promedio2 <= 300 Then
            difmax2 = 42
        ElseIf promedio2 <= 450 Then
            difmax2 = 50
        ElseIf promedio2 <= 750 Then
            difmax2 = 63
        Else
            difmax2 = 126
        End If

        If promedio3 <= 150 Then
            difmax3 = 25
        ElseIf promedio3 <= 300 Then
            difmax3 = 42
        ElseIf promedio3 <= 450 Then
            difmax3 = 50
        ElseIf promedio3 <= 750 Then
            difmax3 = 63
        Else
            difmax3 = 126
        End If

        If promedio4 <= 150 Then
            difmax4 = 25
        ElseIf promedio4 <= 300 Then
            difmax4 = 42
        ElseIf promedio4 <= 450 Then
            difmax4 = 50
        ElseIf promedio4 <= 750 Then
            difmax4 = 63
        Else
            difmax4 = 126
        End If

        If promedio5 <= 150 Then
            difmax5 = 25
        ElseIf promedio5 <= 300 Then
            difmax5 = 42
        ElseIf promedio5 <= 450 Then
            difmax5 = 50
        ElseIf promedio5 <= 750 Then
            difmax5 = 63
        Else
            difmax5 = 126
        End If

        If promedio6 <= 150 Then
            difmax6 = 25
        ElseIf promedio6 <= 300 Then
            difmax6 = 42
        ElseIf promedio6 <= 450 Then
            difmax6 = 50
        ElseIf promedio6 <= 750 Then
            difmax6 = 63
        Else
            difmax6 = 126
        End If

        If promedio7 <= 150 Then
            difmax7 = 25
        ElseIf promedio7 <= 300 Then
            difmax7 = 42
        ElseIf promedio7 <= 450 Then
            difmax7 = 50
        ElseIf promedio7 <= 750 Then
            difmax7 = 63
        Else
            difmax7 = 126
        End If

        If promedio8 <= 150 Then
            difmax8 = 25
        ElseIf promedio8 <= 300 Then
            difmax8 = 42
        ElseIf promedio8 <= 450 Then
            difmax8 = 50
        ElseIf promedio8 <= 750 Then
            difmax8 = 63
        Else
            difmax8 = 126
        End If

        If promedio9 <= 150 Then
            difmax9 = 25
        ElseIf promedio9 <= 300 Then
            difmax9 = 42
        ElseIf promedio9 <= 450 Then
            difmax9 = 50
        ElseIf promedio9 <= 750 Then
            difmax9 = 63
        Else
            difmax9 = 126
        End If

        If promedio10 <= 150 Then
            difmax10 = 25
        ElseIf promedio10 <= 300 Then
            difmax10 = 42
        ElseIf promedio10 <= 450 Then
            difmax10 = 50
        ElseIf promedio10 <= 750 Then
            difmax10 = 63
        Else
            difmax10 = 126
        End If

        If promedio11 <= 150 Then
            difmax11 = 25
        ElseIf promedio11 <= 300 Then
            difmax11 = 42
        ElseIf promedio11 <= 450 Then
            difmax11 = 50
        ElseIf promedio11 <= 750 Then
            difmax11 = 63
        Else
            difmax11 = 126
        End If

        If promedio12 <= 150 Then
            difmax12 = 25
        ElseIf promedio12 <= 300 Then
            difmax12 = 42
        ElseIf promedio12 <= 450 Then
            difmax12 = 50
        ElseIf promedio12 <= 750 Then
            difmax12 = 63
        Else
            difmax12 = 126
        End If

        If promedio13 <= 150 Then
            difmax13 = 25
        ElseIf promedio13 <= 300 Then
            difmax13 = 42
        ElseIf promedio13 <= 450 Then
            difmax13 = 50
        ElseIf promedio13 <= 750 Then
            difmax13 = 63
        Else
            difmax13 = 126
        End If

        If promedio14 <= 150 Then
            difmax14 = 25
        ElseIf promedio14 <= 300 Then
            difmax14 = 42
        ElseIf promedio14 <= 450 Then
            difmax14 = 50
        ElseIf promedio14 <= 750 Then
            difmax14 = 63
        Else
            difmax14 = 126
        End If

        If promedio15 <= 150 Then
            difmax15 = 25
        ElseIf promedio15 <= 300 Then
            difmax15 = 42
        ElseIf promedio15 <= 450 Then
            difmax15 = 50
        ElseIf promedio15 <= 750 Then
            difmax15 = 63
        Else
            difmax15 = 126
        End If

        If promedio16 <= 150 Then
            difmax16 = 25
        ElseIf promedio16 <= 300 Then
            difmax16 = 42
        ElseIf promedio16 <= 450 Then
            difmax16 = 50
        ElseIf promedio16 <= 750 Then
            difmax16 = 63
        Else
            difmax16 = 126
        End If

        If promedio17 <= 150 Then
            difmax17 = 25
        ElseIf promedio17 <= 300 Then
            difmax17 = 42
        ElseIf promedio17 <= 450 Then
            difmax17 = 50
        ElseIf promedio17 <= 750 Then
            difmax17 = 63
        Else
            difmax17 = 126
        End If

        If promedio18 <= 150 Then
            difmax18 = 25
        ElseIf promedio18 <= 300 Then
            difmax18 = 42
        ElseIf promedio18 <= 450 Then
            difmax18 = 50
        ElseIf promedio18 <= 750 Then
            difmax18 = 63
        Else
            difmax18 = 126
        End If

        If promedio19 <= 150 Then
            difmax19 = 25
        ElseIf promedio19 <= 300 Then
            difmax19 = 42
        ElseIf promedio19 <= 450 Then
            difmax19 = 50
        ElseIf promedio19 <= 750 Then
            difmax19 = 63
        Else
            difmax19 = 126
        End If

        If promedio20 <= 150 Then
            difmax20 = 25
        ElseIf promedio20 <= 300 Then
            difmax20 = 42
        ElseIf promedio20 <= 450 Then
            difmax20 = 50
        ElseIf promedio20 <= 750 Then
            difmax20 = 63
        Else
            difmax20 = 126
        End If

        If v1 > v21 Then
            dif1 = v1 - v21
        Else
            dif1 = v21 - v1
        End If

        If v2 > v22 Then
            dif2 = v2 - v22
        Else
            dif2 = v22 - v2
        End If

        If v3 > v23 Then
            dif3 = v3 - v23
        Else
            dif3 = v23 - v3
        End If

        If v4 > v24 Then
            dif4 = v4 - v24
        Else
            dif4 = v24 - v4
        End If

        If v5 > v25 Then
            dif5 = v5 - v25
        Else
            dif5 = v25 - v5
        End If

        If v6 > v26 Then
            dif6 = v6 - v26
        Else
            dif6 = v26 - v6
        End If

        If v7 > v27 Then
            dif7 = v7 - v27
        Else
            dif7 = v27 - v7
        End If

        If v8 > v28 Then
            dif8 = v8 - v28
        Else
            dif8 = v28 - v8
        End If

        If v9 > v29 Then
            dif9 = v9 - v29
        Else
            dif9 = v29 - v9
        End If

        If v10 > v30 Then
            dif10 = v10 - v30
        Else
            dif10 = v30 - v10
        End If

        If v11 > v31 Then
            dif11 = v11 - v31
        Else
            dif11 = v31 - v11
        End If

        If v12 > v32 Then
            dif12 = v12 - v32
        Else
            dif12 = v32 - v12
        End If

        If v13 > v33 Then
            dif13 = v13 - v33
        Else
            dif13 = v33 - v13
        End If

        If v14 > v34 Then
            dif14 = v14 - v34
        Else
            dif14 = v34 - v14
        End If

        If v15 > v35 Then
            dif15 = v15 - v35
        Else
            dif15 = v35 - v15
        End If

        If v16 > v36 Then
            dif16 = v16 - v36
        Else
            dif16 = v36 - v16
        End If

        If v17 > v37 Then
            dif17 = v17 - v37
        Else
            dif17 = v37 - v17
        End If

        If v18 > v38 Then
            dif18 = v18 - v38
        Else
            dif18 = v38 - v18
        End If

        If v19 > v39 Then
            dif19 = v19 - v39
        Else
            dif19 = v39 - v19
        End If

        If v20 > v40 Then
            dif20 = v20 - v40
        Else
            dif20 = v40 - v20
        End If

        porcentaje1 = (dif1 * 100) / difmax1
        porcentaje2 = (dif2 * 100) / difmax2
        porcentaje3 = (dif3 * 100) / difmax3
        porcentaje4 = (dif4 * 100) / difmax4
        porcentaje5 = (dif5 * 100) / difmax5
        porcentaje6 = (dif6 * 100) / difmax6
        porcentaje7 = (dif7 * 100) / difmax7
        porcentaje8 = (dif8 * 100) / difmax8
        porcentaje9 = (dif9 * 100) / difmax9
        porcentaje10 = (dif10 * 100) / difmax10
        porcentaje11 = (dif11 * 100) / difmax11
        porcentaje12 = (dif12 * 100) / difmax12
        porcentaje13 = (dif13 * 100) / difmax13
        porcentaje14 = (dif14 * 100) / difmax14
        porcentaje15 = (dif15 * 100) / difmax15
        porcentaje16 = (dif16 * 100) / difmax16
        porcentaje17 = (dif17 * 100) / difmax17
        porcentaje18 = (dif18 * 100) / difmax18
        porcentaje19 = (dif19 * 100) / difmax19
        porcentaje20 = (dif20 * 100) / difmax20

        If porcentaje1 < 80 Then
            resultado1 = 0
        ElseIf porcentaje1 < 101 Then
            resultado1 = 1
        Else
            resultado1 = 2
        End If

        If porcentaje2 < 80 Then
            resultado2 = 0
        ElseIf porcentaje2 < 101 Then
            resultado2 = 1
        Else
            resultado2 = 2
        End If

        If porcentaje3 < 80 Then
            resultado3 = 0
        ElseIf porcentaje3 < 101 Then
            resultado3 = 1
        Else
            resultado3 = 2
        End If

        If porcentaje4 < 80 Then
            resultado4 = 0
        ElseIf porcentaje4 < 101 Then
            resultado4 = 1
        Else
            resultado4 = 2
        End If

        If porcentaje5 < 80 Then
            resultado5 = 0
        ElseIf porcentaje5 < 101 Then
            resultado5 = 1
        Else
            resultado5 = 2
        End If

        If porcentaje6 < 80 Then
            resultado6 = 0
        ElseIf porcentaje6 < 101 Then
            resultado6 = 1
        Else
            resultado6 = 2
        End If

        If porcentaje7 < 80 Then
            resultado7 = 0
        ElseIf porcentaje7 < 101 Then
            resultado7 = 1
        Else
            resultado7 = 2
        End If

        If porcentaje8 < 80 Then
            resultado8 = 0
        ElseIf porcentaje8 < 101 Then
            resultado8 = 1
        Else
            resultado8 = 2
        End If

        If porcentaje9 < 80 Then
            resultado9 = 0
        ElseIf porcentaje9 < 101 Then
            resultado9 = 1
        Else
            resultado9 = 2
        End If

        If porcentaje10 < 80 Then
            resultado10 = 0
        ElseIf porcentaje10 < 101 Then
            resultado10 = 1
        Else
            resultado10 = 2
        End If

        If porcentaje11 < 80 Then
            resultado11 = 0
        ElseIf porcentaje11 < 101 Then
            resultado11 = 1
        Else
            resultado11 = 2
        End If

        If porcentaje12 < 80 Then
            resultado12 = 0
        ElseIf porcentaje12 < 101 Then
            resultado12 = 1
        Else
            resultado12 = 2
        End If

        If porcentaje13 < 80 Then
            resultado13 = 0
        ElseIf porcentaje13 < 101 Then
            resultado13 = 1
        Else
            resultado13 = 2
        End If

        If porcentaje14 < 80 Then
            resultado14 = 0
        ElseIf porcentaje14 < 101 Then
            resultado14 = 1
        Else
            resultado14 = 2
        End If

        If porcentaje15 < 80 Then
            resultado15 = 0
        ElseIf porcentaje15 < 101 Then
            resultado15 = 1
        Else
            resultado15 = 2
        End If

        If porcentaje16 < 80 Then
            resultado16 = 0
        ElseIf porcentaje16 < 101 Then
            resultado16 = 1
        Else
            resultado16 = 2
        End If

        If porcentaje17 < 80 Then
            resultado17 = 0
        ElseIf porcentaje17 < 101 Then
            resultado17 = 1
        Else
            resultado17 = 2
        End If

        If porcentaje18 < 80 Then
            resultado18 = 0
        ElseIf porcentaje18 < 101 Then
            resultado18 = 1
        Else
            resultado18 = 2
        End If

        If porcentaje19 < 80 Then
            resultado19 = 0
        ElseIf porcentaje19 < 101 Then
            resultado19 = 1
        Else
            resultado19 = 2
        End If

        If porcentaje20 < 80 Then
            resultado20 = 0
        ElseIf porcentaje20 < 101 Then
            resultado20 = 1
        Else
            resultado20 = 2
        End If


        Dim rg51inf As New dRgLab51_informes
        For i = 1 To 20
            If i = 1 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v1
                rg51inf.RESULTADO2 = v21
                rg51inf.PROMEDIO = promedio1
                rg51inf.DIFMAX = difmax1
                rg51inf.DIF = dif1
                rg51inf.ALERTA = alerta1
                rg51inf.PORCENTAJE = porcentaje1
                rg51inf.RESULTADO = resultado1
                rg51inf.guardar(Usuario)
            ElseIf i = 2 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v2
                rg51inf.RESULTADO2 = v22
                rg51inf.PROMEDIO = promedio2
                rg51inf.DIFMAX = difmax2
                rg51inf.DIF = dif2
                rg51inf.ALERTA = alerta2
                rg51inf.PORCENTAJE = porcentaje2
                rg51inf.RESULTADO = resultado2
                rg51inf.guardar(Usuario)
            ElseIf i = 3 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v3
                rg51inf.RESULTADO2 = v23
                rg51inf.PROMEDIO = promedio3
                rg51inf.DIFMAX = difmax3
                rg51inf.DIF = dif3
                rg51inf.ALERTA = alerta3
                rg51inf.PORCENTAJE = porcentaje3
                rg51inf.RESULTADO = resultado3
                rg51inf.guardar(Usuario)
            ElseIf i = 4 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v4
                rg51inf.RESULTADO2 = v24
                rg51inf.PROMEDIO = promedio4
                rg51inf.DIFMAX = difmax4
                rg51inf.DIF = dif4
                rg51inf.ALERTA = alerta4
                rg51inf.PORCENTAJE = porcentaje4
                rg51inf.RESULTADO = resultado4
                rg51inf.guardar(Usuario)
            ElseIf i = 5 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v5
                rg51inf.RESULTADO2 = v25
                rg51inf.PROMEDIO = promedio5
                rg51inf.DIFMAX = difmax5
                rg51inf.DIF = dif5
                rg51inf.ALERTA = alerta5
                rg51inf.PORCENTAJE = porcentaje5
                rg51inf.RESULTADO = resultado5
                rg51inf.guardar(Usuario)
            ElseIf i = 6 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v6
                rg51inf.RESULTADO2 = v26
                rg51inf.PROMEDIO = promedio6
                rg51inf.DIFMAX = difmax6
                rg51inf.DIF = dif6
                rg51inf.ALERTA = alerta6
                rg51inf.PORCENTAJE = porcentaje6
                rg51inf.RESULTADO = resultado6
                rg51inf.guardar(Usuario)
            ElseIf i = 7 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v7
                rg51inf.RESULTADO2 = v27
                rg51inf.PROMEDIO = promedio7
                rg51inf.DIFMAX = difmax7
                rg51inf.DIF = dif7
                rg51inf.ALERTA = alerta7
                rg51inf.PORCENTAJE = porcentaje7
                rg51inf.RESULTADO = resultado7
                rg51inf.guardar(Usuario)
            ElseIf i = 8 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v8
                rg51inf.RESULTADO2 = v28
                rg51inf.PROMEDIO = promedio8
                rg51inf.DIFMAX = difmax8
                rg51inf.DIF = dif8
                rg51inf.ALERTA = alerta8
                rg51inf.PORCENTAJE = porcentaje8
                rg51inf.RESULTADO = resultado8
                rg51inf.guardar(Usuario)
            ElseIf i = 9 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v9
                rg51inf.RESULTADO2 = v29
                rg51inf.PROMEDIO = promedio9
                rg51inf.DIFMAX = difmax9
                rg51inf.DIF = dif9
                rg51inf.ALERTA = alerta9
                rg51inf.PORCENTAJE = porcentaje9
                rg51inf.RESULTADO = resultado9
                rg51inf.guardar(Usuario)
            ElseIf i = 10 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v10
                rg51inf.RESULTADO2 = v30
                rg51inf.PROMEDIO = promedio10
                rg51inf.DIFMAX = difmax10
                rg51inf.DIF = dif10
                rg51inf.ALERTA = alerta10
                rg51inf.PORCENTAJE = porcentaje10
                rg51inf.RESULTADO = resultado10
                rg51inf.guardar(Usuario)
            ElseIf i = 11 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v11
                rg51inf.RESULTADO2 = v31
                rg51inf.PROMEDIO = promedio11
                rg51inf.DIFMAX = difmax11
                rg51inf.DIF = dif11
                rg51inf.ALERTA = alerta11
                rg51inf.PORCENTAJE = porcentaje11
                rg51inf.RESULTADO = resultado11
                rg51inf.guardar(Usuario)
            ElseIf i = 12 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v12
                rg51inf.RESULTADO2 = v32
                rg51inf.PROMEDIO = promedio12
                rg51inf.DIFMAX = difmax12
                rg51inf.DIF = dif12
                rg51inf.ALERTA = alerta12
                rg51inf.PORCENTAJE = porcentaje12
                rg51inf.RESULTADO = resultado12
                rg51inf.guardar(Usuario)
            ElseIf i = 13 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v13
                rg51inf.RESULTADO2 = v33
                rg51inf.PROMEDIO = promedio13
                rg51inf.DIFMAX = difmax13
                rg51inf.DIF = dif13
                rg51inf.ALERTA = alerta13
                rg51inf.PORCENTAJE = porcentaje13
                rg51inf.RESULTADO = resultado13
                rg51inf.guardar(Usuario)
            ElseIf i = 14 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v14
                rg51inf.RESULTADO2 = v34
                rg51inf.PROMEDIO = promedio14
                rg51inf.DIFMAX = difmax14
                rg51inf.DIF = dif14
                rg51inf.ALERTA = alerta14
                rg51inf.PORCENTAJE = porcentaje14
                rg51inf.RESULTADO = resultado14
                rg51inf.guardar(Usuario)
            ElseIf i = 15 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v15
                rg51inf.RESULTADO2 = v35
                rg51inf.PROMEDIO = promedio15
                rg51inf.DIFMAX = difmax15
                rg51inf.DIF = dif15
                rg51inf.ALERTA = alerta15
                rg51inf.PORCENTAJE = porcentaje15
                rg51inf.RESULTADO = resultado15
                rg51inf.guardar(Usuario)
            ElseIf i = 16 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v16
                rg51inf.RESULTADO2 = v36
                rg51inf.PROMEDIO = promedio16
                rg51inf.DIFMAX = difmax16
                rg51inf.DIF = dif16
                rg51inf.ALERTA = alerta16
                rg51inf.PORCENTAJE = porcentaje16
                rg51inf.RESULTADO = resultado16
                rg51inf.guardar(Usuario)
            ElseIf i = 17 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v17
                rg51inf.RESULTADO2 = v37
                rg51inf.PROMEDIO = promedio17
                rg51inf.DIFMAX = difmax17
                rg51inf.DIF = dif17
                rg51inf.ALERTA = alerta17
                rg51inf.PORCENTAJE = porcentaje17
                rg51inf.RESULTADO = resultado17
                rg51inf.guardar(Usuario)
            ElseIf i = 18 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v18
                rg51inf.RESULTADO2 = v38
                rg51inf.PROMEDIO = promedio18
                rg51inf.DIFMAX = difmax18
                rg51inf.DIF = dif18
                rg51inf.ALERTA = alerta18
                rg51inf.PORCENTAJE = porcentaje18
                rg51inf.RESULTADO = resultado18
                rg51inf.guardar(Usuario)
            ElseIf i = 19 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v19
                rg51inf.RESULTADO2 = v39
                rg51inf.PROMEDIO = promedio19
                rg51inf.DIFMAX = difmax19
                rg51inf.DIF = dif19
                rg51inf.ALERTA = alerta19
                rg51inf.PORCENTAJE = porcentaje19
                rg51inf.RESULTADO = resultado19
                rg51inf.guardar(Usuario)
            ElseIf i = 20 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v20
                rg51inf.RESULTADO2 = v40
                rg51inf.PROMEDIO = promedio20
                rg51inf.DIFMAX = difmax20
                rg51inf.DIF = dif20
                rg51inf.ALERTA = alerta20
                rg51inf.PORCENTAJE = porcentaje20
                rg51inf.RESULTADO = resultado20
                rg51inf.guardar(Usuario)
            End If
         
        Next i

    End Sub
    Private Sub generarinformesdelta()
        Dim rg51 As New dRgLab51
        Dim fechaoriginal As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecha As String
        fecha = Format(fechaoriginal, "yyyy-MM-dd")
        Dim equipo As String = "Delta"
        Dim contador As Integer = 1
        Dim v1 As Integer = 0
        Dim v2 As Integer = 0
        Dim v3 As Integer = 0
        Dim v4 As Integer = 0
        Dim v5 As Integer = 0
        Dim v6 As Integer = 0
        Dim v7 As Integer = 0
        Dim v8 As Integer = 0
        Dim v9 As Integer = 0
        Dim v10 As Integer = 0
        Dim v11 As Integer = 0
        Dim v12 As Integer = 0
        Dim v13 As Integer = 0
        Dim v14 As Integer = 0
        Dim v15 As Integer = 0
        Dim v16 As Integer = 0
        Dim v17 As Integer = 0
        Dim v18 As Integer = 0
        Dim v19 As Integer = 0
        Dim v20 As Integer = 0
        Dim v21 As Integer = 0
        Dim v22 As Integer = 0
        Dim v23 As Integer = 0
        Dim v24 As Integer = 0
        Dim v25 As Integer = 0
        Dim v26 As Integer = 0
        Dim v27 As Integer = 0
        Dim v28 As Integer = 0
        Dim v29 As Integer = 0
        Dim v30 As Integer = 0
        Dim v31 As Integer = 0
        Dim v32 As Integer = 0
        Dim v33 As Integer = 0
        Dim v34 As Integer = 0
        Dim v35 As Integer = 0
        Dim v36 As Integer = 0
        Dim v37 As Integer = 0
        Dim v38 As Integer = 0
        Dim v39 As Integer = 0
        Dim v40 As Integer = 0
        Dim promedio1 As Double = 0
        Dim promedio2 As Double = 0
        Dim promedio3 As Double = 0
        Dim promedio4 As Double = 0
        Dim promedio5 As Double = 0
        Dim promedio6 As Double = 0
        Dim promedio7 As Double = 0
        Dim promedio8 As Double = 0
        Dim promedio9 As Double = 0
        Dim promedio10 As Double = 0
        Dim promedio11 As Double = 0
        Dim promedio12 As Double = 0
        Dim promedio13 As Double = 0
        Dim promedio14 As Double = 0
        Dim promedio15 As Double = 0
        Dim promedio16 As Double = 0
        Dim promedio17 As Double = 0
        Dim promedio18 As Double = 0
        Dim promedio19 As Double = 0
        Dim promedio20 As Double = 0
        Dim difmax1 As Integer = 0
        Dim difmax2 As Integer = 0
        Dim difmax3 As Integer = 0
        Dim difmax4 As Integer = 0
        Dim difmax5 As Integer = 0
        Dim difmax6 As Integer = 0
        Dim difmax7 As Integer = 0
        Dim difmax8 As Integer = 0
        Dim difmax9 As Integer = 0
        Dim difmax10 As Integer = 0
        Dim difmax11 As Integer = 0
        Dim difmax12 As Integer = 0
        Dim difmax13 As Integer = 0
        Dim difmax14 As Integer = 0
        Dim difmax15 As Integer = 0
        Dim difmax16 As Integer = 0
        Dim difmax17 As Integer = 0
        Dim difmax18 As Integer = 0
        Dim difmax19 As Integer = 0
        Dim difmax20 As Integer = 0
        Dim dif1 As Integer = 0
        Dim dif2 As Integer = 0
        Dim dif3 As Integer = 0
        Dim dif4 As Integer = 0
        Dim dif5 As Integer = 0
        Dim dif6 As Integer = 0
        Dim dif7 As Integer = 0
        Dim dif8 As Integer = 0
        Dim dif9 As Integer = 0
        Dim dif10 As Integer = 0
        Dim dif11 As Integer = 0
        Dim dif12 As Integer = 0
        Dim dif13 As Integer = 0
        Dim dif14 As Integer = 0
        Dim dif15 As Integer = 0
        Dim dif16 As Integer = 0
        Dim dif17 As Integer = 0
        Dim dif18 As Integer = 0
        Dim dif19 As Integer = 0
        Dim dif20 As Integer = 0

        Dim alerta1 As Integer = 80
        Dim alerta2 As Integer = 80
        Dim alerta3 As Integer = 80
        Dim alerta4 As Integer = 80
        Dim alerta5 As Integer = 80
        Dim alerta6 As Integer = 80
        Dim alerta7 As Integer = 80
        Dim alerta8 As Integer = 80
        Dim alerta9 As Integer = 80
        Dim alerta10 As Integer = 80
        Dim alerta11 As Integer = 80
        Dim alerta12 As Integer = 80
        Dim alerta13 As Integer = 80
        Dim alerta14 As Integer = 80
        Dim alerta15 As Integer = 80
        Dim alerta16 As Integer = 80
        Dim alerta17 As Integer = 80
        Dim alerta18 As Integer = 80
        Dim alerta19 As Integer = 80
        Dim alerta20 As Integer = 80

        Dim porcentaje1 As Double = 0
        Dim porcentaje2 As Double = 0
        Dim porcentaje3 As Double = 0
        Dim porcentaje4 As Double = 0
        Dim porcentaje5 As Double = 0
        Dim porcentaje6 As Double = 0
        Dim porcentaje7 As Double = 0
        Dim porcentaje8 As Double = 0
        Dim porcentaje9 As Double = 0
        Dim porcentaje10 As Double = 0
        Dim porcentaje11 As Double = 0
        Dim porcentaje12 As Double = 0
        Dim porcentaje13 As Double = 0
        Dim porcentaje14 As Double = 0
        Dim porcentaje15 As Double = 0
        Dim porcentaje16 As Double = 0
        Dim porcentaje17 As Double = 0
        Dim porcentaje18 As Double = 0
        Dim porcentaje19 As Double = 0
        Dim porcentaje20 As Double = 0

        Dim resultado1 As Integer = 0
        Dim resultado2 As Integer = 0
        Dim resultado3 As Integer = 0
        Dim resultado4 As Integer = 0
        Dim resultado5 As Integer = 0
        Dim resultado6 As Integer = 0
        Dim resultado7 As Integer = 0
        Dim resultado8 As Integer = 0
        Dim resultado9 As Integer = 0
        Dim resultado10 As Integer = 0
        Dim resultado11 As Integer = 0
        Dim resultado12 As Integer = 0
        Dim resultado13 As Integer = 0
        Dim resultado14 As Integer = 0
        Dim resultado15 As Integer = 0
        Dim resultado16 As Integer = 0
        Dim resultado17 As Integer = 0
        Dim resultado18 As Integer = 0
        Dim resultado19 As Integer = 0
        Dim resultado20 As Integer = 0

        Dim lista As New ArrayList
        lista = rg51.listarxfechaxequipo(fecha, equipo)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each rg51 In lista
                    If rg51.MUESTRA = 1 Then
                        v1 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 2 Then
                        v2 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 3 Then
                        v3 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 4 Then
                        v4 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 5 Then
                        v5 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 6 Then
                        v6 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 7 Then
                        v7 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 8 Then
                        v8 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 9 Then
                        v9 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 10 Then
                        v10 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 11 Then
                        v11 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 12 Then
                        v12 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 13 Then
                        v13 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 14 Then
                        v14 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 15 Then
                        v15 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 16 Then
                        v16 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 17 Then
                        v17 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 18 Then
                        v18 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 19 Then
                        v19 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 20 Then
                        v20 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 21 Then
                        v21 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 22 Then
                        v22 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 23 Then
                        v23 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 24 Then
                        v24 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 25 Then
                        v25 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 26 Then
                        v26 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 27 Then
                        v27 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 28 Then
                        v28 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 29 Then
                        v29 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 30 Then
                        v30 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 31 Then
                        v31 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 32 Then
                        v32 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 33 Then
                        v33 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 34 Then
                        v34 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 35 Then
                        v35 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 36 Then
                        v36 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 37 Then
                        v37 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 38 Then
                        v38 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 39 Then
                        v39 = rg51.RESULTADO
                    ElseIf rg51.MUESTRA = 40 Then
                        v40 = rg51.RESULTADO
                    End If
                Next
            End If
        End If

        promedio1 = (v1 + v21) / 2
        promedio2 = (v2 + v22) / 2
        promedio3 = (v3 + v23) / 2
        promedio4 = (v4 + v24) / 2
        promedio5 = (v5 + v25) / 2
        promedio6 = (v6 + v26) / 2
        promedio7 = (v7 + v27) / 2
        promedio8 = (v8 + v28) / 2
        promedio9 = (v9 + v29) / 2
        promedio10 = (v10 + v30) / 2
        promedio11 = (v11 + v31) / 2
        promedio12 = (v12 + v32) / 2
        promedio13 = (v13 + v33) / 2
        promedio14 = (v14 + v34) / 2
        promedio15 = (v15 + v35) / 2
        promedio16 = (v16 + v36) / 2
        promedio17 = (v17 + v37) / 2
        promedio18 = (v18 + v38) / 2
        promedio19 = (v19 + v39) / 2
        promedio20 = (v20 + v40) / 2

        If promedio1 <= 150 Then
            difmax1 = 25
        ElseIf promedio1 <= 300 Then
            difmax1 = 42
        ElseIf promedio1 <= 450 Then
            difmax1 = 50
        ElseIf promedio1 <= 750 Then
            difmax1 = 63
        Else
            difmax1 = 126
        End If

        If promedio2 <= 150 Then
            difmax2 = 25
        ElseIf promedio2 <= 300 Then
            difmax2 = 42
        ElseIf promedio2 <= 450 Then
            difmax2 = 50
        ElseIf promedio2 <= 750 Then
            difmax2 = 63
        Else
            difmax2 = 126
        End If

        If promedio3 <= 150 Then
            difmax3 = 25
        ElseIf promedio3 <= 300 Then
            difmax3 = 42
        ElseIf promedio3 <= 450 Then
            difmax3 = 50
        ElseIf promedio3 <= 750 Then
            difmax3 = 63
        Else
            difmax3 = 126
        End If

        If promedio4 <= 150 Then
            difmax4 = 25
        ElseIf promedio4 <= 300 Then
            difmax4 = 42
        ElseIf promedio4 <= 450 Then
            difmax4 = 50
        ElseIf promedio4 <= 750 Then
            difmax4 = 63
        Else
            difmax4 = 126
        End If

        If promedio5 <= 150 Then
            difmax5 = 25
        ElseIf promedio5 <= 300 Then
            difmax5 = 42
        ElseIf promedio5 <= 450 Then
            difmax5 = 50
        ElseIf promedio5 <= 750 Then
            difmax5 = 63
        Else
            difmax5 = 126
        End If

        If promedio6 <= 150 Then
            difmax6 = 25
        ElseIf promedio6 <= 300 Then
            difmax6 = 42
        ElseIf promedio6 <= 450 Then
            difmax6 = 50
        ElseIf promedio6 <= 750 Then
            difmax6 = 63
        Else
            difmax6 = 126
        End If

        If promedio7 <= 150 Then
            difmax7 = 25
        ElseIf promedio7 <= 300 Then
            difmax7 = 42
        ElseIf promedio7 <= 450 Then
            difmax7 = 50
        ElseIf promedio7 <= 750 Then
            difmax7 = 63
        Else
            difmax7 = 126
        End If

        If promedio8 <= 150 Then
            difmax8 = 25
        ElseIf promedio8 <= 300 Then
            difmax8 = 42
        ElseIf promedio8 <= 450 Then
            difmax8 = 50
        ElseIf promedio8 <= 750 Then
            difmax8 = 63
        Else
            difmax8 = 126
        End If

        If promedio9 <= 150 Then
            difmax9 = 25
        ElseIf promedio9 <= 300 Then
            difmax9 = 42
        ElseIf promedio9 <= 450 Then
            difmax9 = 50
        ElseIf promedio9 <= 750 Then
            difmax9 = 63
        Else
            difmax9 = 126
        End If

        If promedio10 <= 150 Then
            difmax10 = 25
        ElseIf promedio10 <= 300 Then
            difmax10 = 42
        ElseIf promedio10 <= 450 Then
            difmax10 = 50
        ElseIf promedio10 <= 750 Then
            difmax10 = 63
        Else
            difmax10 = 126
        End If

        If promedio11 <= 150 Then
            difmax11 = 25
        ElseIf promedio11 <= 300 Then
            difmax11 = 42
        ElseIf promedio11 <= 450 Then
            difmax11 = 50
        ElseIf promedio11 <= 750 Then
            difmax11 = 63
        Else
            difmax11 = 126
        End If

        If promedio12 <= 150 Then
            difmax12 = 25
        ElseIf promedio12 <= 300 Then
            difmax12 = 42
        ElseIf promedio12 <= 450 Then
            difmax12 = 50
        ElseIf promedio12 <= 750 Then
            difmax12 = 63
        Else
            difmax12 = 126
        End If

        If promedio13 <= 150 Then
            difmax13 = 25
        ElseIf promedio13 <= 300 Then
            difmax13 = 42
        ElseIf promedio13 <= 450 Then
            difmax13 = 50
        ElseIf promedio13 <= 750 Then
            difmax13 = 63
        Else
            difmax13 = 126
        End If

        If promedio14 <= 150 Then
            difmax14 = 25
        ElseIf promedio14 <= 300 Then
            difmax14 = 42
        ElseIf promedio14 <= 450 Then
            difmax14 = 50
        ElseIf promedio14 <= 750 Then
            difmax14 = 63
        Else
            difmax14 = 126
        End If

        If promedio15 <= 150 Then
            difmax15 = 25
        ElseIf promedio15 <= 300 Then
            difmax15 = 42
        ElseIf promedio15 <= 450 Then
            difmax15 = 50
        ElseIf promedio15 <= 750 Then
            difmax15 = 63
        Else
            difmax15 = 126
        End If

        If promedio16 <= 150 Then
            difmax16 = 25
        ElseIf promedio16 <= 300 Then
            difmax16 = 42
        ElseIf promedio16 <= 450 Then
            difmax16 = 50
        ElseIf promedio16 <= 750 Then
            difmax16 = 63
        Else
            difmax16 = 126
        End If

        If promedio17 <= 150 Then
            difmax17 = 25
        ElseIf promedio17 <= 300 Then
            difmax17 = 42
        ElseIf promedio17 <= 450 Then
            difmax17 = 50
        ElseIf promedio17 <= 750 Then
            difmax17 = 63
        Else
            difmax17 = 126
        End If

        If promedio18 <= 150 Then
            difmax18 = 25
        ElseIf promedio18 <= 300 Then
            difmax18 = 42
        ElseIf promedio18 <= 450 Then
            difmax18 = 50
        ElseIf promedio18 <= 750 Then
            difmax18 = 63
        Else
            difmax18 = 126
        End If

        If promedio19 <= 150 Then
            difmax19 = 25
        ElseIf promedio19 <= 300 Then
            difmax19 = 42
        ElseIf promedio19 <= 450 Then
            difmax19 = 50
        ElseIf promedio19 <= 750 Then
            difmax19 = 63
        Else
            difmax19 = 126
        End If

        If promedio20 <= 150 Then
            difmax20 = 25
        ElseIf promedio20 <= 300 Then
            difmax20 = 42
        ElseIf promedio20 <= 450 Then
            difmax20 = 50
        ElseIf promedio20 <= 750 Then
            difmax20 = 63
        Else
            difmax20 = 126
        End If

        If v1 > v21 Then
            dif1 = v1 - v21
        Else
            dif1 = v21 - v1
        End If

        If v2 > v22 Then
            dif2 = v2 - v22
        Else
            dif2 = v22 - v2
        End If

        If v3 > v23 Then
            dif3 = v3 - v23
        Else
            dif3 = v23 - v3
        End If

        If v4 > v24 Then
            dif4 = v4 - v24
        Else
            dif4 = v24 - v4
        End If

        If v5 > v25 Then
            dif5 = v5 - v25
        Else
            dif5 = v25 - v5
        End If

        If v6 > v26 Then
            dif6 = v6 - v26
        Else
            dif6 = v26 - v6
        End If

        If v7 > v27 Then
            dif7 = v7 - v27
        Else
            dif7 = v27 - v7
        End If

        If v8 > v28 Then
            dif8 = v8 - v28
        Else
            dif8 = v28 - v8
        End If

        If v9 > v29 Then
            dif9 = v9 - v29
        Else
            dif9 = v29 - v9
        End If

        If v10 > v30 Then
            dif10 = v10 - v30
        Else
            dif10 = v30 - v10
        End If

        If v11 > v31 Then
            dif11 = v11 - v31
        Else
            dif11 = v31 - v11
        End If

        If v12 > v32 Then
            dif12 = v12 - v32
        Else
            dif12 = v32 - v12
        End If

        If v13 > v33 Then
            dif13 = v13 - v33
        Else
            dif13 = v33 - v13
        End If

        If v14 > v34 Then
            dif14 = v14 - v34
        Else
            dif14 = v34 - v14
        End If

        If v15 > v35 Then
            dif15 = v15 - v35
        Else
            dif15 = v35 - v15
        End If

        If v16 > v36 Then
            dif16 = v16 - v36
        Else
            dif16 = v36 - v16
        End If

        If v17 > v37 Then
            dif17 = v17 - v37
        Else
            dif17 = v37 - v17
        End If

        If v18 > v38 Then
            dif18 = v18 - v38
        Else
            dif18 = v38 - v18
        End If

        If v19 > v39 Then
            dif19 = v19 - v39
        Else
            dif19 = v39 - v19
        End If

        If v20 > v40 Then
            dif20 = v20 - v40
        Else
            dif20 = v40 - v20
        End If

        porcentaje1 = (dif1 * 100) / difmax1
        porcentaje2 = (dif2 * 100) / difmax2
        porcentaje3 = (dif3 * 100) / difmax3
        porcentaje4 = (dif4 * 100) / difmax4
        porcentaje5 = (dif5 * 100) / difmax5
        porcentaje6 = (dif6 * 100) / difmax6
        porcentaje7 = (dif7 * 100) / difmax7
        porcentaje8 = (dif8 * 100) / difmax8
        porcentaje9 = (dif9 * 100) / difmax9
        porcentaje10 = (dif10 * 100) / difmax10
        porcentaje11 = (dif11 * 100) / difmax11
        porcentaje12 = (dif12 * 100) / difmax12
        porcentaje13 = (dif13 * 100) / difmax13
        porcentaje14 = (dif14 * 100) / difmax14
        porcentaje15 = (dif15 * 100) / difmax15
        porcentaje16 = (dif16 * 100) / difmax16
        porcentaje17 = (dif17 * 100) / difmax17
        porcentaje18 = (dif18 * 100) / difmax18
        porcentaje19 = (dif19 * 100) / difmax19
        porcentaje20 = (dif20 * 100) / difmax20

        If porcentaje1 < 80 Then
            resultado1 = 0
        ElseIf porcentaje1 < 101 Then
            resultado1 = 1
        Else
            resultado1 = 2
        End If

        If porcentaje2 < 80 Then
            resultado2 = 0
        ElseIf porcentaje2 < 101 Then
            resultado2 = 1
        Else
            resultado2 = 2
        End If

        If porcentaje3 < 80 Then
            resultado3 = 0
        ElseIf porcentaje3 < 101 Then
            resultado3 = 1
        Else
            resultado3 = 2
        End If

        If porcentaje4 < 80 Then
            resultado4 = 0
        ElseIf porcentaje4 < 101 Then
            resultado4 = 1
        Else
            resultado4 = 2
        End If

        If porcentaje5 < 80 Then
            resultado5 = 0
        ElseIf porcentaje5 < 101 Then
            resultado5 = 1
        Else
            resultado5 = 2
        End If

        If porcentaje6 < 80 Then
            resultado6 = 0
        ElseIf porcentaje6 < 101 Then
            resultado6 = 1
        Else
            resultado6 = 2
        End If

        If porcentaje7 < 80 Then
            resultado7 = 0
        ElseIf porcentaje7 < 101 Then
            resultado7 = 1
        Else
            resultado7 = 2
        End If

        If porcentaje8 < 80 Then
            resultado8 = 0
        ElseIf porcentaje8 < 101 Then
            resultado8 = 1
        Else
            resultado8 = 2
        End If

        If porcentaje9 < 80 Then
            resultado9 = 0
        ElseIf porcentaje9 < 101 Then
            resultado9 = 1
        Else
            resultado9 = 2
        End If

        If porcentaje10 < 80 Then
            resultado10 = 0
        ElseIf porcentaje10 < 101 Then
            resultado10 = 1
        Else
            resultado10 = 2
        End If

        If porcentaje11 < 80 Then
            resultado11 = 0
        ElseIf porcentaje11 < 101 Then
            resultado11 = 1
        Else
            resultado11 = 2
        End If

        If porcentaje12 < 80 Then
            resultado12 = 0
        ElseIf porcentaje12 < 101 Then
            resultado12 = 1
        Else
            resultado12 = 2
        End If

        If porcentaje13 < 80 Then
            resultado13 = 0
        ElseIf porcentaje13 < 101 Then
            resultado13 = 1
        Else
            resultado13 = 2
        End If

        If porcentaje14 < 80 Then
            resultado14 = 0
        ElseIf porcentaje14 < 101 Then
            resultado14 = 1
        Else
            resultado14 = 2
        End If

        If porcentaje15 < 80 Then
            resultado15 = 0
        ElseIf porcentaje15 < 101 Then
            resultado15 = 1
        Else
            resultado15 = 2
        End If

        If porcentaje16 < 80 Then
            resultado16 = 0
        ElseIf porcentaje16 < 101 Then
            resultado16 = 1
        Else
            resultado16 = 2
        End If

        If porcentaje17 < 80 Then
            resultado17 = 0
        ElseIf porcentaje17 < 101 Then
            resultado17 = 1
        Else
            resultado17 = 2
        End If

        If porcentaje18 < 80 Then
            resultado18 = 0
        ElseIf porcentaje18 < 101 Then
            resultado18 = 1
        Else
            resultado18 = 2
        End If

        If porcentaje19 < 80 Then
            resultado19 = 0
        ElseIf porcentaje19 < 101 Then
            resultado19 = 1
        Else
            resultado19 = 2
        End If

        If porcentaje20 < 80 Then
            resultado20 = 0
        ElseIf porcentaje20 < 101 Then
            resultado20 = 1
        Else
            resultado20 = 2
        End If


        Dim rg51inf As New dRgLab51_informes
        For i = 1 To 20
            If i = 1 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v1
                rg51inf.RESULTADO2 = v21
                rg51inf.PROMEDIO = promedio1
                rg51inf.DIFMAX = difmax1
                rg51inf.DIF = dif1
                rg51inf.ALERTA = alerta1
                rg51inf.PORCENTAJE = porcentaje1
                rg51inf.RESULTADO = resultado1
                rg51inf.guardar(Usuario)
            ElseIf i = 2 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v2
                rg51inf.RESULTADO2 = v22
                rg51inf.PROMEDIO = promedio2
                rg51inf.DIFMAX = difmax2
                rg51inf.DIF = dif2
                rg51inf.ALERTA = alerta2
                rg51inf.PORCENTAJE = porcentaje2
                rg51inf.RESULTADO = resultado2
                rg51inf.guardar(Usuario)
            ElseIf i = 3 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v3
                rg51inf.RESULTADO2 = v23
                rg51inf.PROMEDIO = promedio3
                rg51inf.DIFMAX = difmax3
                rg51inf.DIF = dif3
                rg51inf.ALERTA = alerta3
                rg51inf.PORCENTAJE = porcentaje3
                rg51inf.RESULTADO = resultado3
                rg51inf.guardar(Usuario)
            ElseIf i = 4 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v4
                rg51inf.RESULTADO2 = v24
                rg51inf.PROMEDIO = promedio4
                rg51inf.DIFMAX = difmax4
                rg51inf.DIF = dif4
                rg51inf.ALERTA = alerta4
                rg51inf.PORCENTAJE = porcentaje4
                rg51inf.RESULTADO = resultado4
                rg51inf.guardar(Usuario)
            ElseIf i = 5 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v5
                rg51inf.RESULTADO2 = v25
                rg51inf.PROMEDIO = promedio5
                rg51inf.DIFMAX = difmax5
                rg51inf.DIF = dif5
                rg51inf.ALERTA = alerta5
                rg51inf.PORCENTAJE = porcentaje5
                rg51inf.RESULTADO = resultado5
                rg51inf.guardar(Usuario)
            ElseIf i = 6 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v6
                rg51inf.RESULTADO2 = v26
                rg51inf.PROMEDIO = promedio6
                rg51inf.DIFMAX = difmax6
                rg51inf.DIF = dif6
                rg51inf.ALERTA = alerta6
                rg51inf.PORCENTAJE = porcentaje6
                rg51inf.RESULTADO = resultado6
                rg51inf.guardar(Usuario)
            ElseIf i = 7 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v7
                rg51inf.RESULTADO2 = v27
                rg51inf.PROMEDIO = promedio7
                rg51inf.DIFMAX = difmax7
                rg51inf.DIF = dif7
                rg51inf.ALERTA = alerta7
                rg51inf.PORCENTAJE = porcentaje7
                rg51inf.RESULTADO = resultado7
                rg51inf.guardar(Usuario)
            ElseIf i = 8 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v8
                rg51inf.RESULTADO2 = v28
                rg51inf.PROMEDIO = promedio8
                rg51inf.DIFMAX = difmax8
                rg51inf.DIF = dif8
                rg51inf.ALERTA = alerta8
                rg51inf.PORCENTAJE = porcentaje8
                rg51inf.RESULTADO = resultado8
                rg51inf.guardar(Usuario)
            ElseIf i = 9 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v9
                rg51inf.RESULTADO2 = v29
                rg51inf.PROMEDIO = promedio9
                rg51inf.DIFMAX = difmax9
                rg51inf.DIF = dif9
                rg51inf.ALERTA = alerta9
                rg51inf.PORCENTAJE = porcentaje9
                rg51inf.RESULTADO = resultado9
                rg51inf.guardar(Usuario)
            ElseIf i = 10 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v10
                rg51inf.RESULTADO2 = v30
                rg51inf.PROMEDIO = promedio10
                rg51inf.DIFMAX = difmax10
                rg51inf.DIF = dif10
                rg51inf.ALERTA = alerta10
                rg51inf.PORCENTAJE = porcentaje10
                rg51inf.RESULTADO = resultado10
                rg51inf.guardar(Usuario)
            ElseIf i = 11 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v11
                rg51inf.RESULTADO2 = v31
                rg51inf.PROMEDIO = promedio11
                rg51inf.DIFMAX = difmax11
                rg51inf.DIF = dif11
                rg51inf.ALERTA = alerta11
                rg51inf.PORCENTAJE = porcentaje11
                rg51inf.RESULTADO = resultado11
                rg51inf.guardar(Usuario)
            ElseIf i = 12 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v12
                rg51inf.RESULTADO2 = v32
                rg51inf.PROMEDIO = promedio12
                rg51inf.DIFMAX = difmax12
                rg51inf.DIF = dif12
                rg51inf.ALERTA = alerta12
                rg51inf.PORCENTAJE = porcentaje12
                rg51inf.RESULTADO = resultado12
                rg51inf.guardar(Usuario)
            ElseIf i = 13 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v13
                rg51inf.RESULTADO2 = v33
                rg51inf.PROMEDIO = promedio13
                rg51inf.DIFMAX = difmax13
                rg51inf.DIF = dif13
                rg51inf.ALERTA = alerta13
                rg51inf.PORCENTAJE = porcentaje13
                rg51inf.RESULTADO = resultado13
                rg51inf.guardar(Usuario)
            ElseIf i = 14 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v14
                rg51inf.RESULTADO2 = v34
                rg51inf.PROMEDIO = promedio14
                rg51inf.DIFMAX = difmax14
                rg51inf.DIF = dif14
                rg51inf.ALERTA = alerta14
                rg51inf.PORCENTAJE = porcentaje14
                rg51inf.RESULTADO = resultado14
                rg51inf.guardar(Usuario)
            ElseIf i = 15 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v15
                rg51inf.RESULTADO2 = v35
                rg51inf.PROMEDIO = promedio15
                rg51inf.DIFMAX = difmax15
                rg51inf.DIF = dif15
                rg51inf.ALERTA = alerta15
                rg51inf.PORCENTAJE = porcentaje15
                rg51inf.RESULTADO = resultado15
                rg51inf.guardar(Usuario)
            ElseIf i = 16 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v16
                rg51inf.RESULTADO2 = v36
                rg51inf.PROMEDIO = promedio16
                rg51inf.DIFMAX = difmax16
                rg51inf.DIF = dif16
                rg51inf.ALERTA = alerta16
                rg51inf.PORCENTAJE = porcentaje16
                rg51inf.RESULTADO = resultado16
                rg51inf.guardar(Usuario)
            ElseIf i = 17 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v17
                rg51inf.RESULTADO2 = v37
                rg51inf.PROMEDIO = promedio17
                rg51inf.DIFMAX = difmax17
                rg51inf.DIF = dif17
                rg51inf.ALERTA = alerta17
                rg51inf.PORCENTAJE = porcentaje17
                rg51inf.RESULTADO = resultado17
                rg51inf.guardar(Usuario)
            ElseIf i = 18 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v18
                rg51inf.RESULTADO2 = v38
                rg51inf.PROMEDIO = promedio18
                rg51inf.DIFMAX = difmax18
                rg51inf.DIF = dif18
                rg51inf.ALERTA = alerta18
                rg51inf.PORCENTAJE = porcentaje18
                rg51inf.RESULTADO = resultado18
                rg51inf.guardar(Usuario)
            ElseIf i = 19 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v19
                rg51inf.RESULTADO2 = v39
                rg51inf.PROMEDIO = promedio19
                rg51inf.DIFMAX = difmax19
                rg51inf.DIF = dif19
                rg51inf.ALERTA = alerta19
                rg51inf.PORCENTAJE = porcentaje19
                rg51inf.RESULTADO = resultado19
                rg51inf.guardar(Usuario)
            ElseIf i = 20 Then
                rg51inf.FECHA = fecha
                rg51inf.EQUIPO = equipo
                rg51inf.OPERADOR = Usuario.ID
                rg51inf.MUESTRA = i
                rg51inf.RESULTADO1 = v20
                rg51inf.RESULTADO2 = v40
                rg51inf.PROMEDIO = promedio20
                rg51inf.DIFMAX = difmax20
                rg51inf.DIF = dif20
                rg51inf.ALERTA = alerta20
                rg51inf.PORCENTAJE = porcentaje20
                rg51inf.RESULTADO = resultado20
                rg51inf.guardar(Usuario)
            End If

        Next i

    End Sub
    Private Sub generarrglab58()
        Dim rg51 As New dRgLab51_informes
        Dim fechaoriginal As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecha As String
        fecha = Format(fechaoriginal, "yyyy-MM-dd")
        Dim equipo As String = "Bentley"
        Dim contador As Integer = 1

        Dim resb1 As Integer = 0
        Dim resb2 As Integer = 0
        Dim resb3 As Integer = 0
        Dim resb4 As Integer = 0
        Dim resb5 As Integer = 0
        Dim resb6 As Integer = 0
        Dim resb7 As Integer = 0
        Dim resb8 As Integer = 0
        Dim resb9 As Integer = 0
        Dim resb10 As Integer = 0
        Dim resb11 As Integer = 0
        Dim resb12 As Integer = 0
        Dim resb13 As Integer = 0
        Dim resb14 As Integer = 0
        Dim resb15 As Integer = 0
        Dim resb16 As Integer = 0
        Dim resb17 As Integer = 0
        Dim resb18 As Integer = 0
        Dim resb19 As Integer = 0
        Dim resb20 As Integer = 0

        Dim resb1b As Integer = 0
        Dim resb2b As Integer = 0
        Dim resb3b As Integer = 0
        Dim resb4b As Integer = 0
        Dim resb5b As Integer = 0
        Dim resb6b As Integer = 0
        Dim resb7b As Integer = 0
        Dim resb8b As Integer = 0
        Dim resb9b As Integer = 0
        Dim resb10b As Integer = 0
        Dim resb11b As Integer = 0
        Dim resb12b As Integer = 0
        Dim resb13b As Integer = 0
        Dim resb14b As Integer = 0
        Dim resb15b As Integer = 0
        Dim resb16b As Integer = 0
        Dim resb17b As Integer = 0
        Dim resb18b As Integer = 0
        Dim resb19b As Integer = 0
        Dim resb20b As Integer = 0

        Dim promb1 As Integer = 0
        Dim promb2 As Integer = 0
        Dim promb3 As Integer = 0
        Dim promb4 As Integer = 0
        Dim promb5 As Integer = 0
        Dim promb6 As Integer = 0
        Dim promb7 As Integer = 0
        Dim promb8 As Integer = 0
        Dim promb9 As Integer = 0
        Dim promb10 As Integer = 0
        Dim promb11 As Integer = 0
        Dim promb12 As Integer = 0
        Dim promb13 As Integer = 0
        Dim promb14 As Integer = 0
        Dim promb15 As Integer = 0
        Dim promb16 As Integer = 0
        Dim promb17 As Integer = 0
        Dim promb18 As Integer = 0
        Dim promb19 As Integer = 0
        Dim promb20 As Integer = 0

        Dim resd1 As Integer = 0
        Dim resd2 As Integer = 0
        Dim resd3 As Integer = 0
        Dim resd4 As Integer = 0
        Dim resd5 As Integer = 0
        Dim resd6 As Integer = 0
        Dim resd7 As Integer = 0
        Dim resd8 As Integer = 0
        Dim resd9 As Integer = 0
        Dim resd10 As Integer = 0
        Dim resd11 As Integer = 0
        Dim resd12 As Integer = 0
        Dim resd13 As Integer = 0
        Dim resd14 As Integer = 0
        Dim resd15 As Integer = 0
        Dim resd16 As Integer = 0
        Dim resd17 As Integer = 0
        Dim resd18 As Integer = 0
        Dim resd19 As Integer = 0
        Dim resd20 As Integer = 0

        Dim resd1b As Integer = 0
        Dim resd2b As Integer = 0
        Dim resd3b As Integer = 0
        Dim resd4b As Integer = 0
        Dim resd5b As Integer = 0
        Dim resd6b As Integer = 0
        Dim resd7b As Integer = 0
        Dim resd8b As Integer = 0
        Dim resd9b As Integer = 0
        Dim resd10b As Integer = 0
        Dim resd11b As Integer = 0
        Dim resd12b As Integer = 0
        Dim resd13b As Integer = 0
        Dim resd14b As Integer = 0
        Dim resd15b As Integer = 0
        Dim resd16b As Integer = 0
        Dim resd17b As Integer = 0
        Dim resd18b As Integer = 0
        Dim resd19b As Integer = 0
        Dim resd20b As Integer = 0

        Dim promd1 As Integer = 0
        Dim promd2 As Integer = 0
        Dim promd3 As Integer = 0
        Dim promd4 As Integer = 0
        Dim promd5 As Integer = 0
        Dim promd6 As Integer = 0
        Dim promd7 As Integer = 0
        Dim promd8 As Integer = 0
        Dim promd9 As Integer = 0
        Dim promd10 As Integer = 0
        Dim promd11 As Integer = 0
        Dim promd12 As Integer = 0
        Dim promd13 As Integer = 0
        Dim promd14 As Integer = 0
        Dim promd15 As Integer = 0
        Dim promd16 As Integer = 0
        Dim promd17 As Integer = 0
        Dim promd18 As Integer = 0
        Dim promd19 As Integer = 0
        Dim promd20 As Integer = 0

        Dim promedio1 As Double = 0
        Dim promedio2 As Double = 0
        Dim promedio3 As Double = 0
        Dim promedio4 As Double = 0
        Dim promedio5 As Double = 0
        Dim promedio6 As Double = 0
        Dim promedio7 As Double = 0
        Dim promedio8 As Double = 0
        Dim promedio9 As Double = 0
        Dim promedio10 As Double = 0
        Dim promedio11 As Double = 0
        Dim promedio12 As Double = 0
        Dim promedio13 As Double = 0
        Dim promedio14 As Double = 0
        Dim promedio15 As Double = 0
        Dim promedio16 As Double = 0
        Dim promedio17 As Double = 0
        Dim promedio18 As Double = 0
        Dim promedio19 As Double = 0
        Dim promedio20 As Double = 0
        Dim difmax1 As Integer = 0
        Dim difmax2 As Integer = 0
        Dim difmax3 As Integer = 0
        Dim difmax4 As Integer = 0
        Dim difmax5 As Integer = 0
        Dim difmax6 As Integer = 0
        Dim difmax7 As Integer = 0
        Dim difmax8 As Integer = 0
        Dim difmax9 As Integer = 0
        Dim difmax10 As Integer = 0
        Dim difmax11 As Integer = 0
        Dim difmax12 As Integer = 0
        Dim difmax13 As Integer = 0
        Dim difmax14 As Integer = 0
        Dim difmax15 As Integer = 0
        Dim difmax16 As Integer = 0
        Dim difmax17 As Integer = 0
        Dim difmax18 As Integer = 0
        Dim difmax19 As Integer = 0
        Dim difmax20 As Integer = 0
        Dim dif1 As Integer = 0
        Dim dif2 As Integer = 0
        Dim dif3 As Integer = 0
        Dim dif4 As Integer = 0
        Dim dif5 As Integer = 0
        Dim dif6 As Integer = 0
        Dim dif7 As Integer = 0
        Dim dif8 As Integer = 0
        Dim dif9 As Integer = 0
        Dim dif10 As Integer = 0
        Dim dif11 As Integer = 0
        Dim dif12 As Integer = 0
        Dim dif13 As Integer = 0
        Dim dif14 As Integer = 0
        Dim dif15 As Integer = 0
        Dim dif16 As Integer = 0
        Dim dif17 As Integer = 0
        Dim dif18 As Integer = 0
        Dim dif19 As Integer = 0
        Dim dif20 As Integer = 0

        Dim alerta1 As Integer = 80
        Dim alerta2 As Integer = 80
        Dim alerta3 As Integer = 80
        Dim alerta4 As Integer = 80
        Dim alerta5 As Integer = 80
        Dim alerta6 As Integer = 80
        Dim alerta7 As Integer = 80
        Dim alerta8 As Integer = 80
        Dim alerta9 As Integer = 80
        Dim alerta10 As Integer = 80
        Dim alerta11 As Integer = 80
        Dim alerta12 As Integer = 80
        Dim alerta13 As Integer = 80
        Dim alerta14 As Integer = 80
        Dim alerta15 As Integer = 80
        Dim alerta16 As Integer = 80
        Dim alerta17 As Integer = 80
        Dim alerta18 As Integer = 80
        Dim alerta19 As Integer = 80
        Dim alerta20 As Integer = 80

        Dim porcentaje1 As Double = 0
        Dim porcentaje2 As Double = 0
        Dim porcentaje3 As Double = 0
        Dim porcentaje4 As Double = 0
        Dim porcentaje5 As Double = 0
        Dim porcentaje6 As Double = 0
        Dim porcentaje7 As Double = 0
        Dim porcentaje8 As Double = 0
        Dim porcentaje9 As Double = 0
        Dim porcentaje10 As Double = 0
        Dim porcentaje11 As Double = 0
        Dim porcentaje12 As Double = 0
        Dim porcentaje13 As Double = 0
        Dim porcentaje14 As Double = 0
        Dim porcentaje15 As Double = 0
        Dim porcentaje16 As Double = 0
        Dim porcentaje17 As Double = 0
        Dim porcentaje18 As Double = 0
        Dim porcentaje19 As Double = 0
        Dim porcentaje20 As Double = 0

        Dim resultado1 As Integer = 0
        Dim resultado2 As Integer = 0
        Dim resultado3 As Integer = 0
        Dim resultado4 As Integer = 0
        Dim resultado5 As Integer = 0
        Dim resultado6 As Integer = 0
        Dim resultado7 As Integer = 0
        Dim resultado8 As Integer = 0
        Dim resultado9 As Integer = 0
        Dim resultado10 As Integer = 0
        Dim resultado11 As Integer = 0
        Dim resultado12 As Integer = 0
        Dim resultado13 As Integer = 0
        Dim resultado14 As Integer = 0
        Dim resultado15 As Integer = 0
        Dim resultado16 As Integer = 0
        Dim resultado17 As Integer = 0
        Dim resultado18 As Integer = 0
        Dim resultado19 As Integer = 0
        Dim resultado20 As Integer = 0

        Dim lista As New ArrayList
        lista = rg51.listarxfecha(fecha)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each rg51 In lista
                    If rg51.MUESTRA = 1 And rg51.EQUIPO = "Bentley" Then
                        resb1 = rg51.RESULTADO1
                        resb1b = rg51.RESULTADO2
                        promb1 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 2 And rg51.EQUIPO = "Bentley" Then
                        resb2 = rg51.RESULTADO1
                        resb2b = rg51.RESULTADO2
                        promb2 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 3 And rg51.EQUIPO = "Bentley" Then
                        resb3 = rg51.RESULTADO1
                        resb3b = rg51.RESULTADO2
                        promb3 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 4 And rg51.EQUIPO = "Bentley" Then
                        resb4 = rg51.RESULTADO1
                        resb4b = rg51.RESULTADO2
                        promb4 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 5 And rg51.EQUIPO = "Bentley" Then
                        resb5 = rg51.RESULTADO1
                        resb5b = rg51.RESULTADO2
                        promb5 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 6 And rg51.EQUIPO = "Bentley" Then
                        resb6 = rg51.RESULTADO1
                        resb6b = rg51.RESULTADO2
                        promb6 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 7 And rg51.EQUIPO = "Bentley" Then
                        resb7 = rg51.RESULTADO1
                        resb7b = rg51.RESULTADO2
                        promb7 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 8 And rg51.EQUIPO = "Bentley" Then
                        resb8 = rg51.RESULTADO1
                        resb8b = rg51.RESULTADO2
                        promb8 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 9 And rg51.EQUIPO = "Bentley" Then
                        resb9 = rg51.RESULTADO1
                        resb9b = rg51.RESULTADO2
                        promb9 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 10 And rg51.EQUIPO = "Bentley" Then
                        resb10 = rg51.RESULTADO1
                        resb10b = rg51.RESULTADO2
                        promb10 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 11 And rg51.EQUIPO = "Bentley" Then
                        resb11 = rg51.RESULTADO1
                        resb11b = rg51.RESULTADO2
                        promb11 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 12 And rg51.EQUIPO = "Bentley" Then
                        resb12 = rg51.RESULTADO1
                        resb12b = rg51.RESULTADO2
                        promb12 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 13 And rg51.EQUIPO = "Bentley" Then
                        resb13 = rg51.RESULTADO1
                        resb13b = rg51.RESULTADO2
                        promb13 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 14 And rg51.EQUIPO = "Bentley" Then
                        resb14 = rg51.RESULTADO1
                        resb14b = rg51.RESULTADO2
                        promb14 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 15 And rg51.EQUIPO = "Bentley" Then
                        resb15 = rg51.RESULTADO1
                        resb15b = rg51.RESULTADO2
                        promb15 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 16 And rg51.EQUIPO = "Bentley" Then
                        resb16 = rg51.RESULTADO1
                        resb16b = rg51.RESULTADO2
                        promb16 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 17 And rg51.EQUIPO = "Bentley" Then
                        resb17 = rg51.RESULTADO1
                        resb17b = rg51.RESULTADO2
                        promb17 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 18 And rg51.EQUIPO = "Bentley" Then
                        resb18 = rg51.RESULTADO1
                        resb18b = rg51.RESULTADO2
                        promb18 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 19 And rg51.EQUIPO = "Bentley" Then
                        resb19 = rg51.RESULTADO1
                        resb19b = rg51.RESULTADO2
                        promb19 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 20 And rg51.EQUIPO = "Bentley" Then
                        resb20 = rg51.RESULTADO1
                        resb20b = rg51.RESULTADO2
                        promb20 = rg51.PROMEDIO


                    ElseIf rg51.MUESTRA = 1 And rg51.EQUIPO = "Delta" Then
                        resd1 = rg51.RESULTADO1
                        resd1b = rg51.RESULTADO2
                        promd1 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 2 And rg51.EQUIPO = "Delta" Then
                        resd2 = rg51.RESULTADO1
                        resd2b = rg51.RESULTADO2
                        promd2 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 3 And rg51.EQUIPO = "Delta" Then
                        resd3 = rg51.RESULTADO1
                        resd3b = rg51.RESULTADO2
                        promd3 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 4 And rg51.EQUIPO = "Delta" Then
                        resd4 = rg51.RESULTADO1
                        resd4b = rg51.RESULTADO2
                        promd4 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 5 And rg51.EQUIPO = "Delta" Then
                        resd5 = rg51.RESULTADO1
                        resd5b = rg51.RESULTADO2
                        promd5 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 6 And rg51.EQUIPO = "Delta" Then
                        resd6 = rg51.RESULTADO1
                        resd6b = rg51.RESULTADO2
                        promd6 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 7 And rg51.EQUIPO = "Delta" Then
                        resd7 = rg51.RESULTADO1
                        resd7b = rg51.RESULTADO2
                        promd7 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 8 And rg51.EQUIPO = "Delta" Then
                        resd8 = rg51.RESULTADO1
                        resd8b = rg51.RESULTADO2
                        promd8 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 9 And rg51.EQUIPO = "Delta" Then
                        resd9 = rg51.RESULTADO1
                        resd9b = rg51.RESULTADO2
                        promd9 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 10 And rg51.EQUIPO = "Delta" Then
                        resd10 = rg51.RESULTADO1
                        resd10b = rg51.RESULTADO2
                        promd10 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 11 And rg51.EQUIPO = "Delta" Then
                        resd11 = rg51.RESULTADO1
                        resd11b = rg51.RESULTADO2
                        promd11 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 12 And rg51.EQUIPO = "Delta" Then
                        resd12 = rg51.RESULTADO1
                        resd12b = rg51.RESULTADO2
                        promd12 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 13 And rg51.EQUIPO = "Delta" Then
                        resd13 = rg51.RESULTADO1
                        resd13b = rg51.RESULTADO2
                        promd13 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 14 And rg51.EQUIPO = "Delta" Then
                        resd14 = rg51.RESULTADO1
                        resd14b = rg51.RESULTADO2
                        promd14 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 15 And rg51.EQUIPO = "Delta" Then
                        resd15 = rg51.RESULTADO1
                        resd15b = rg51.RESULTADO2
                        promd15 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 16 And rg51.EQUIPO = "Delta" Then
                        resd16 = rg51.RESULTADO1
                        resd16b = rg51.RESULTADO2
                        promd16 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 17 And rg51.EQUIPO = "Delta" Then
                        resd17 = rg51.RESULTADO1
                        resd17b = rg51.RESULTADO2
                        promd17 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 18 And rg51.EQUIPO = "Delta" Then
                        resd18 = rg51.RESULTADO1
                        resd18b = rg51.RESULTADO2
                        promd18 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 19 And rg51.EQUIPO = "Delta" Then
                        resd19 = rg51.RESULTADO1
                        resd19b = rg51.RESULTADO2
                        promd19 = rg51.PROMEDIO
                    ElseIf rg51.MUESTRA = 20 And rg51.EQUIPO = "Delta" Then
                        resd20 = rg51.RESULTADO1
                        resd20b = rg51.RESULTADO2
                        promd20 = rg51.PROMEDIO
                    End If

                Next
            End If
        End If

        promedio1 = (promb1 + promd1) / 2
        promedio2 = (promb2 + promd2) / 2
        promedio3 = (promb3 + promd3) / 2
        promedio4 = (promb4 + promd4) / 2
        promedio5 = (promb5 + promd5) / 2
        promedio6 = (promb6 + promd6) / 2
        promedio7 = (promb7 + promd7) / 2
        promedio8 = (promb8 + promd8) / 2
        promedio9 = (promb9 + promd9) / 2
        promedio10 = (promb10 + promd10) / 2
        promedio11 = (promb11 + promd11) / 2
        promedio12 = (promb12 + promd12) / 2
        promedio13 = (promb13 + promd13) / 2
        promedio14 = (promb14 + promd14) / 2
        promedio15 = (promb15 + promd15) / 2
        promedio16 = (promb16 + promd16) / 2
        promedio17 = (promb17 + promd17) / 2
        promedio18 = (promb18 + promd18) / 2
        promedio19 = (promb19 + promd19) / 2
        promedio20 = (promb20 + promd20) / 2

        If promedio1 <= 150 Then
            difmax1 = 29
        ElseIf promedio1 <= 300 Then
            difmax1 = 50
        ElseIf promedio1 <= 450 Then
            difmax1 = 63
        ElseIf promedio1 <= 750 Then
            difmax1 = 84
        Else
            difmax1 = 168
        End If

        If promedio2 <= 150 Then
            difmax2 = 29
        ElseIf promedio2 <= 300 Then
            difmax2 = 50
        ElseIf promedio2 <= 450 Then
            difmax2 = 63
        ElseIf promedio2 <= 750 Then
            difmax2 = 84
        Else
            difmax2 = 168
        End If

        If promedio3 <= 150 Then
            difmax3 = 29
        ElseIf promedio3 <= 300 Then
            difmax3 = 50
        ElseIf promedio3 <= 450 Then
            difmax3 = 63
        ElseIf promedio3 <= 750 Then
            difmax3 = 84
        Else
            difmax3 = 168
        End If

        If promedio4 <= 150 Then
            difmax4 = 29
        ElseIf promedio4 <= 300 Then
            difmax4 = 50
        ElseIf promedio4 <= 450 Then
            difmax4 = 63
        ElseIf promedio4 <= 750 Then
            difmax4 = 84
        Else
            difmax4 = 168
        End If

        If promedio5 <= 150 Then
            difmax5 = 29
        ElseIf promedio5 <= 300 Then
            difmax5 = 50
        ElseIf promedio5 <= 450 Then
            difmax5 = 63
        ElseIf promedio5 <= 750 Then
            difmax5 = 84
        Else
            difmax5 = 168
        End If

        If promedio6 <= 150 Then
            difmax6 = 29
        ElseIf promedio6 <= 300 Then
            difmax6 = 50
        ElseIf promedio6 <= 450 Then
            difmax6 = 63
        ElseIf promedio6 <= 750 Then
            difmax6 = 84
        Else
            difmax6 = 168
        End If

        If promedio7 <= 150 Then
            difmax7 = 29
        ElseIf promedio7 <= 300 Then
            difmax7 = 50
        ElseIf promedio7 <= 450 Then
            difmax7 = 63
        ElseIf promedio7 <= 750 Then
            difmax7 = 84
        Else
            difmax7 = 168
        End If

        If promedio8 <= 150 Then
            difmax8 = 29
        ElseIf promedio8 <= 300 Then
            difmax8 = 50
        ElseIf promedio8 <= 450 Then
            difmax8 = 63
        ElseIf promedio8 <= 750 Then
            difmax8 = 84
        Else
            difmax8 = 168
        End If

        If promedio9 <= 150 Then
            difmax9 = 29
        ElseIf promedio9 <= 300 Then
            difmax9 = 50
        ElseIf promedio9 <= 450 Then
            difmax9 = 63
        ElseIf promedio9 <= 750 Then
            difmax9 = 84
        Else
            difmax9 = 168
        End If

        If promedio10 <= 150 Then
            difmax10 = 29
        ElseIf promedio10 <= 300 Then
            difmax10 = 50
        ElseIf promedio10 <= 450 Then
            difmax10 = 63
        ElseIf promedio10 <= 750 Then
            difmax10 = 84
        Else
            difmax10 = 168
        End If

        If promedio11 <= 150 Then
            difmax11 = 29
        ElseIf promedio11 <= 300 Then
            difmax11 = 50
        ElseIf promedio11 <= 450 Then
            difmax11 = 63
        ElseIf promedio11 <= 750 Then
            difmax11 = 84
        Else
            difmax11 = 168
        End If

        If promedio12 <= 150 Then
            difmax12 = 29
        ElseIf promedio12 <= 300 Then
            difmax12 = 50
        ElseIf promedio12 <= 450 Then
            difmax12 = 63
        ElseIf promedio12 <= 750 Then
            difmax12 = 84
        Else
            difmax12 = 168
        End If

        If promedio13 <= 150 Then
            difmax13 = 29
        ElseIf promedio13 <= 300 Then
            difmax13 = 50
        ElseIf promedio13 <= 450 Then
            difmax13 = 63
        ElseIf promedio13 <= 750 Then
            difmax13 = 84
        Else
            difmax13 = 168
        End If

        If promedio14 <= 150 Then
            difmax14 = 29
        ElseIf promedio14 <= 300 Then
            difmax14 = 50
        ElseIf promedio14 <= 450 Then
            difmax14 = 63
        ElseIf promedio14 <= 750 Then
            difmax14 = 84
        Else
            difmax14 = 168
        End If

        If promedio15 <= 150 Then
            difmax15 = 29
        ElseIf promedio15 <= 300 Then
            difmax15 = 50
        ElseIf promedio15 <= 450 Then
            difmax15 = 63
        ElseIf promedio15 <= 750 Then
            difmax15 = 84
        Else
            difmax15 = 168
        End If

        If promedio16 <= 150 Then
            difmax16 = 29
        ElseIf promedio16 <= 300 Then
            difmax16 = 50
        ElseIf promedio16 <= 450 Then
            difmax16 = 63
        ElseIf promedio16 <= 750 Then
            difmax16 = 84
        Else
            difmax16 = 168
        End If

        If promedio17 <= 150 Then
            difmax17 = 29
        ElseIf promedio17 <= 300 Then
            difmax17 = 50
        ElseIf promedio17 <= 450 Then
            difmax17 = 63
        ElseIf promedio17 <= 750 Then
            difmax17 = 84
        Else
            difmax17 = 168
        End If

        If promedio18 <= 150 Then
            difmax18 = 29
        ElseIf promedio18 <= 300 Then
            difmax18 = 50
        ElseIf promedio18 <= 450 Then
            difmax18 = 63
        ElseIf promedio18 <= 750 Then
            difmax18 = 84
        Else
            difmax18 = 168
        End If

        If promedio19 <= 150 Then
            difmax19 = 29
        ElseIf promedio19 <= 300 Then
            difmax19 = 50
        ElseIf promedio19 <= 450 Then
            difmax19 = 63
        ElseIf promedio19 <= 750 Then
            difmax19 = 84
        Else
            difmax19 = 168
        End If

        If promedio20 <= 150 Then
            difmax20 = 29
        ElseIf promedio20 <= 300 Then
            difmax20 = 50
        ElseIf promedio20 <= 450 Then
            difmax20 = 63
        ElseIf promedio20 <= 750 Then
            difmax20 = 84
        Else
            difmax20 = 168
        End If


        If promb1 > promd1 Then
            dif1 = promb1 - promd1
        Else
            dif1 = promd1 - promb1
        End If

        If promb2 > promd2 Then
            dif2 = promb2 - promd2
        Else
            dif2 = promd2 - promb2
        End If

        If promb3 > promd3 Then
            dif3 = promb3 - promd3
        Else
            dif3 = promd3 - promb3
        End If

        If promb4 > promd4 Then
            dif4 = promb4 - promd4
        Else
            dif4 = promd4 - promb4
        End If

        If promb5 > promd5 Then
            dif5 = promb5 - promd5
        Else
            dif5 = promd5 - promb5
        End If

        If promb6 > promd6 Then
            dif6 = promb6 - promd6
        Else
            dif6 = promd6 - promb6
        End If

        If promb7 > promd7 Then
            dif7 = promb7 - promd7
        Else
            dif7 = promd7 - promb7
        End If

        If promb8 > promd8 Then
            dif8 = promb8 - promd8
        Else
            dif8 = promd8 - promb8
        End If

        If promb9 > promd9 Then
            dif9 = promb9 - promd9
        Else
            dif9 = promd9 - promb9
        End If

        If promb10 > promd10 Then
            dif10 = promb10 - promd10
        Else
            dif10 = promd10 - promb10
        End If

        If promb11 > promd11 Then
            dif11 = promb11 - promd11
        Else
            dif11 = promd11 - promb11
        End If

        If promb12 > promd12 Then
            dif12 = promb12 - promd12
        Else
            dif12 = promd12 - promb12
        End If

        If promb13 > promd13 Then
            dif13 = promb13 - promd13
        Else
            dif13 = promd13 - promb13
        End If

        If promb14 > promd14 Then
            dif14 = promb14 - promd14
        Else
            dif14 = promd14 - promb14
        End If

        If promb15 > promd15 Then
            dif15 = promb15 - promd15
        Else
            dif15 = promd15 - promb15
        End If

        If promb16 > promd16 Then
            dif16 = promb16 - promd16
        Else
            dif16 = promd16 - promb16
        End If

        If promb17 > promd17 Then
            dif17 = promb17 - promd17
        Else
            dif17 = promd17 - promb17
        End If

        If promb18 > promd18 Then
            dif18 = promb18 - promd18
        Else
            dif18 = promd18 - promb18
        End If

        If promb19 > promd19 Then
            dif19 = promb19 - promd19
        Else
            dif19 = promd19 - promb19
        End If

        If promb20 > promd20 Then
            dif20 = promb20 - promd20
        Else
            dif20 = promd20 - promb20
        End If

        

        porcentaje1 = (dif1 * 100) / difmax1
        porcentaje2 = (dif2 * 100) / difmax2
        porcentaje3 = (dif3 * 100) / difmax3
        porcentaje4 = (dif4 * 100) / difmax4
        porcentaje5 = (dif5 * 100) / difmax5
        porcentaje6 = (dif6 * 100) / difmax6
        porcentaje7 = (dif7 * 100) / difmax7
        porcentaje8 = (dif8 * 100) / difmax8
        porcentaje9 = (dif9 * 100) / difmax9
        porcentaje10 = (dif10 * 100) / difmax10
        porcentaje11 = (dif11 * 100) / difmax11
        porcentaje12 = (dif12 * 100) / difmax12
        porcentaje13 = (dif13 * 100) / difmax13
        porcentaje14 = (dif14 * 100) / difmax14
        porcentaje15 = (dif15 * 100) / difmax15
        porcentaje16 = (dif16 * 100) / difmax16
        porcentaje17 = (dif17 * 100) / difmax17
        porcentaje18 = (dif18 * 100) / difmax18
        porcentaje19 = (dif19 * 100) / difmax19
        porcentaje20 = (dif20 * 100) / difmax20

        If porcentaje1 < 80 Then
            resultado1 = 0
        ElseIf porcentaje1 < 101 Then
            resultado1 = 1
        Else
            resultado1 = 2
        End If

        If porcentaje2 < 80 Then
            resultado2 = 0
        ElseIf porcentaje2 < 101 Then
            resultado2 = 1
        Else
            resultado2 = 2
        End If

        If porcentaje3 < 80 Then
            resultado3 = 0
        ElseIf porcentaje3 < 101 Then
            resultado3 = 1
        Else
            resultado3 = 2
        End If

        If porcentaje4 < 80 Then
            resultado4 = 0
        ElseIf porcentaje4 < 101 Then
            resultado4 = 1
        Else
            resultado4 = 2
        End If

        If porcentaje5 < 80 Then
            resultado5 = 0
        ElseIf porcentaje5 < 101 Then
            resultado5 = 1
        Else
            resultado5 = 2
        End If

        If porcentaje6 < 80 Then
            resultado6 = 0
        ElseIf porcentaje6 < 101 Then
            resultado6 = 1
        Else
            resultado6 = 2
        End If

        If porcentaje7 < 80 Then
            resultado7 = 0
        ElseIf porcentaje7 < 101 Then
            resultado7 = 1
        Else
            resultado7 = 2
        End If

        If porcentaje8 < 80 Then
            resultado8 = 0
        ElseIf porcentaje8 < 101 Then
            resultado8 = 1
        Else
            resultado8 = 2
        End If

        If porcentaje9 < 80 Then
            resultado9 = 0
        ElseIf porcentaje9 < 101 Then
            resultado9 = 1
        Else
            resultado9 = 2
        End If

        If porcentaje10 < 80 Then
            resultado10 = 0
        ElseIf porcentaje10 < 101 Then
            resultado10 = 1
        Else
            resultado10 = 2
        End If

        If porcentaje11 < 80 Then
            resultado11 = 0
        ElseIf porcentaje11 < 101 Then
            resultado11 = 1
        Else
            resultado11 = 2
        End If

        If porcentaje12 < 80 Then
            resultado12 = 0
        ElseIf porcentaje12 < 101 Then
            resultado12 = 1
        Else
            resultado12 = 2
        End If

        If porcentaje13 < 80 Then
            resultado13 = 0
        ElseIf porcentaje13 < 101 Then
            resultado13 = 1
        Else
            resultado13 = 2
        End If

        If porcentaje14 < 80 Then
            resultado14 = 0
        ElseIf porcentaje14 < 101 Then
            resultado14 = 1
        Else
            resultado14 = 2
        End If

        If porcentaje15 < 80 Then
            resultado15 = 0
        ElseIf porcentaje15 < 101 Then
            resultado15 = 1
        Else
            resultado15 = 2
        End If

        If porcentaje16 < 80 Then
            resultado16 = 0
        ElseIf porcentaje16 < 101 Then
            resultado16 = 1
        Else
            resultado16 = 2
        End If

        If porcentaje17 < 80 Then
            resultado17 = 0
        ElseIf porcentaje17 < 101 Then
            resultado17 = 1
        Else
            resultado17 = 2
        End If

        If porcentaje18 < 80 Then
            resultado18 = 0
        ElseIf porcentaje18 < 101 Then
            resultado18 = 1
        Else
            resultado18 = 2
        End If

        If porcentaje19 < 80 Then
            resultado19 = 0
        ElseIf porcentaje19 < 101 Then
            resultado19 = 1
        Else
            resultado19 = 2
        End If

        If porcentaje20 < 80 Then
            resultado20 = 0
        ElseIf porcentaje20 < 101 Then
            resultado20 = 1
        Else
            resultado20 = 2
        End If


        Dim rg58inf As New dRgLab58_informes
        For i = 1 To 20
            If i = 1 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb1
                rg58inf.RESB2 = resb1b
                rg58inf.PROMB = promb1
                rg58inf.RESD1 = resd1
                rg58inf.RESD2 = resd1b
                rg58inf.PROMD = promd1
                rg58inf.PROMEDIO = promedio1
                rg58inf.DIFMAX = difmax1
                rg58inf.DIF = dif1
                rg58inf.ALERTA = alerta1
                rg58inf.PORCENTAJE = porcentaje1
                rg58inf.RESULTADO = resultado1
                rg58inf.guardar(Usuario)
            ElseIf i = 2 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb2
                rg58inf.RESB2 = resb2b
                rg58inf.PROMB = promb2
                rg58inf.RESD1 = resd2
                rg58inf.RESD2 = resd2b
                rg58inf.PROMD = promd2
                rg58inf.PROMEDIO = promedio2
                rg58inf.DIFMAX = difmax2
                rg58inf.DIF = dif2
                rg58inf.ALERTA = alerta2
                rg58inf.PORCENTAJE = porcentaje2
                rg58inf.RESULTADO = resultado2
                rg58inf.guardar(Usuario)
            ElseIf i = 3 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb3
                rg58inf.RESB2 = resb3b
                rg58inf.PROMB = promb3
                rg58inf.RESD1 = resd3
                rg58inf.RESD2 = resd3b
                rg58inf.PROMD = promd3
                rg58inf.PROMEDIO = promedio3
                rg58inf.DIFMAX = difmax3
                rg58inf.DIF = dif3
                rg58inf.ALERTA = alerta3
                rg58inf.PORCENTAJE = porcentaje3
                rg58inf.RESULTADO = resultado3
                rg58inf.guardar(Usuario)
            ElseIf i = 4 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb4
                rg58inf.RESB2 = resb4b
                rg58inf.PROMB = promb4
                rg58inf.RESD1 = resd4
                rg58inf.RESD2 = resd4b
                rg58inf.PROMD = promd4
                rg58inf.PROMEDIO = promedio4
                rg58inf.DIFMAX = difmax4
                rg58inf.DIF = dif4
                rg58inf.ALERTA = alerta4
                rg58inf.PORCENTAJE = porcentaje4
                rg58inf.RESULTADO = resultado4
                rg58inf.guardar(Usuario)
            ElseIf i = 5 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb5
                rg58inf.RESB2 = resb5b
                rg58inf.PROMB = promb5
                rg58inf.RESD1 = resd5
                rg58inf.RESD2 = resd5b
                rg58inf.PROMD = promd5
                rg58inf.PROMEDIO = promedio5
                rg58inf.DIFMAX = difmax5
                rg58inf.DIF = dif5
                rg58inf.ALERTA = alerta5
                rg58inf.PORCENTAJE = porcentaje5
                rg58inf.RESULTADO = resultado5
                rg58inf.guardar(Usuario)
            ElseIf i = 6 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb6
                rg58inf.RESB2 = resb6b
                rg58inf.PROMB = promb6
                rg58inf.RESD1 = resd6
                rg58inf.RESD2 = resd6b
                rg58inf.PROMD = promd6
                rg58inf.PROMEDIO = promedio6
                rg58inf.DIFMAX = difmax6
                rg58inf.DIF = dif6
                rg58inf.ALERTA = alerta6
                rg58inf.PORCENTAJE = porcentaje6
                rg58inf.RESULTADO = resultado6
                rg58inf.guardar(Usuario)
            ElseIf i = 7 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb7
                rg58inf.RESB2 = resb7b
                rg58inf.PROMB = promb7
                rg58inf.RESD1 = resd7
                rg58inf.RESD2 = resd7b
                rg58inf.PROMD = promd7
                rg58inf.PROMEDIO = promedio7
                rg58inf.DIFMAX = difmax7
                rg58inf.DIF = dif7
                rg58inf.ALERTA = alerta7
                rg58inf.PORCENTAJE = porcentaje7
                rg58inf.RESULTADO = resultado7
                rg58inf.guardar(Usuario)
            ElseIf i = 8 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb8
                rg58inf.RESB2 = resb8b
                rg58inf.PROMB = promb8
                rg58inf.RESD1 = resd8
                rg58inf.RESD2 = resd8b
                rg58inf.PROMD = promd8
                rg58inf.PROMEDIO = promedio8
                rg58inf.DIFMAX = difmax8
                rg58inf.DIF = dif8
                rg58inf.ALERTA = alerta8
                rg58inf.PORCENTAJE = porcentaje8
                rg58inf.RESULTADO = resultado8
                rg58inf.guardar(Usuario)
            ElseIf i = 9 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb9
                rg58inf.RESB2 = resb9b
                rg58inf.PROMB = promb9
                rg58inf.RESD1 = resd9
                rg58inf.RESD2 = resd9b
                rg58inf.PROMD = promd9
                rg58inf.PROMEDIO = promedio9
                rg58inf.DIFMAX = difmax9
                rg58inf.DIF = dif9
                rg58inf.ALERTA = alerta9
                rg58inf.PORCENTAJE = porcentaje9
                rg58inf.RESULTADO = resultado9
                rg58inf.guardar(Usuario)
            ElseIf i = 10 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb10
                rg58inf.RESB2 = resb10b
                rg58inf.PROMB = promb10
                rg58inf.RESD1 = resd10
                rg58inf.RESD2 = resd10b
                rg58inf.PROMD = promd10
                rg58inf.PROMEDIO = promedio10
                rg58inf.DIFMAX = difmax10
                rg58inf.DIF = dif10
                rg58inf.ALERTA = alerta10
                rg58inf.PORCENTAJE = porcentaje10
                rg58inf.RESULTADO = resultado10
                rg58inf.guardar(Usuario)
            ElseIf i = 11 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb11
                rg58inf.RESB2 = resb11b
                rg58inf.PROMB = promb11
                rg58inf.RESD1 = resd11
                rg58inf.RESD2 = resd11b
                rg58inf.PROMD = promd11
                rg58inf.PROMEDIO = promedio11
                rg58inf.DIFMAX = difmax11
                rg58inf.DIF = dif11
                rg58inf.ALERTA = alerta11
                rg58inf.PORCENTAJE = porcentaje11
                rg58inf.RESULTADO = resultado11
                rg58inf.guardar(Usuario)
            ElseIf i = 12 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb12
                rg58inf.RESB2 = resb12b
                rg58inf.PROMB = promb12
                rg58inf.RESD1 = resd12
                rg58inf.RESD2 = resd12b
                rg58inf.PROMD = promd12
                rg58inf.PROMEDIO = promedio12
                rg58inf.DIFMAX = difmax12
                rg58inf.DIF = dif12
                rg58inf.ALERTA = alerta12
                rg58inf.PORCENTAJE = porcentaje12
                rg58inf.RESULTADO = resultado12
                rg58inf.guardar(Usuario)
            ElseIf i = 13 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb13
                rg58inf.RESB2 = resb13b
                rg58inf.PROMB = promb13
                rg58inf.RESD1 = resd13
                rg58inf.RESD2 = resd13b
                rg58inf.PROMD = promd13
                rg58inf.PROMEDIO = promedio13
                rg58inf.DIFMAX = difmax13
                rg58inf.DIF = dif13
                rg58inf.ALERTA = alerta13
                rg58inf.PORCENTAJE = porcentaje13
                rg58inf.RESULTADO = resultado13
                rg58inf.guardar(Usuario)
            ElseIf i = 14 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb14
                rg58inf.RESB2 = resb14b
                rg58inf.PROMB = promb14
                rg58inf.RESD1 = resd14
                rg58inf.RESD2 = resd14b
                rg58inf.PROMD = promd14
                rg58inf.PROMEDIO = promedio14
                rg58inf.DIFMAX = difmax14
                rg58inf.DIF = dif14
                rg58inf.ALERTA = alerta14
                rg58inf.PORCENTAJE = porcentaje14
                rg58inf.RESULTADO = resultado14
                rg58inf.guardar(Usuario)
            ElseIf i = 15 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb15
                rg58inf.RESB2 = resb15b
                rg58inf.PROMB = promb15
                rg58inf.RESD1 = resd15
                rg58inf.RESD2 = resd15b
                rg58inf.PROMD = promd15
                rg58inf.PROMEDIO = promedio15
                rg58inf.DIFMAX = difmax15
                rg58inf.DIF = dif15
                rg58inf.ALERTA = alerta15
                rg58inf.PORCENTAJE = porcentaje15
                rg58inf.RESULTADO = resultado15
                rg58inf.guardar(Usuario)
            ElseIf i = 16 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb16
                rg58inf.RESB2 = resb16b
                rg58inf.PROMB = promb16
                rg58inf.RESD1 = resd16
                rg58inf.RESD2 = resd16b
                rg58inf.PROMD = promd16
                rg58inf.PROMEDIO = promedio16
                rg58inf.DIFMAX = difmax16
                rg58inf.DIF = dif16
                rg58inf.ALERTA = alerta16
                rg58inf.PORCENTAJE = porcentaje16
                rg58inf.RESULTADO = resultado16
                rg58inf.guardar(Usuario)
            ElseIf i = 17 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb17
                rg58inf.RESB2 = resb17b
                rg58inf.PROMB = promb17
                rg58inf.RESD1 = resd17
                rg58inf.RESD2 = resd17b
                rg58inf.PROMD = promd17
                rg58inf.PROMEDIO = promedio17
                rg58inf.DIFMAX = difmax17
                rg58inf.DIF = dif17
                rg58inf.ALERTA = alerta17
                rg58inf.PORCENTAJE = porcentaje17
                rg58inf.RESULTADO = resultado17
                rg58inf.guardar(Usuario)
            ElseIf i = 18 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb18
                rg58inf.RESB2 = resb18b
                rg58inf.PROMB = promb18
                rg58inf.RESD1 = resd18
                rg58inf.RESD2 = resd18b
                rg58inf.PROMD = promd18
                rg58inf.PROMEDIO = promedio18
                rg58inf.DIFMAX = difmax18
                rg58inf.DIF = dif18
                rg58inf.ALERTA = alerta18
                rg58inf.PORCENTAJE = porcentaje18
                rg58inf.RESULTADO = resultado18
                rg58inf.guardar(Usuario)
            ElseIf i = 19 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb19
                rg58inf.RESB2 = resb19b
                rg58inf.PROMB = promb19
                rg58inf.RESD1 = resd19
                rg58inf.RESD2 = resd19b
                rg58inf.PROMD = promd19
                rg58inf.PROMEDIO = promedio19
                rg58inf.DIFMAX = difmax19
                rg58inf.DIF = dif19
                rg58inf.ALERTA = alerta19
                rg58inf.PORCENTAJE = porcentaje19
                rg58inf.RESULTADO = resultado19
                rg58inf.guardar(Usuario)
            ElseIf i = 20 Then
                rg58inf.FECHA = fecha
                rg58inf.OPERADOR = Usuario.ID
                rg58inf.MUESTRA = i
                rg58inf.RESB1 = resb20
                rg58inf.RESB2 = resb20b
                rg58inf.PROMB = promb20
                rg58inf.RESD1 = resd20
                rg58inf.RESD2 = resd20b
                rg58inf.PROMD = promd20
                rg58inf.PROMEDIO = promedio20
                rg58inf.DIFMAX = difmax20
                rg58inf.DIF = dif20
                rg58inf.ALERTA = alerta20
                rg58inf.PORCENTAJE = porcentaje20
                rg58inf.RESULTADO = resultado20
                rg58inf.guardar(Usuario)
            End If

        Next i
    End Sub
End Class