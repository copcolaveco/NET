Imports System
Imports System.IO
Imports System.Collections
Public Class FormValoresMediosBD
    Private _usuario As dUsuario
    Private vmgrasa1 As Double
    Private vmgrasa2 As Double
    Private vmprot1 As Double
    Private vmprot2 As Double
    Private vmlact1 As Double
    Private vmlact2 As Double
    Private vmst1 As Double
    Private vmst2 As Double
    Private vmcel1 As Long
    Private vmcel2 As Long
    Private vmurea1 As Long
    Private vmurea2 As Long
    Private vmcrio1 As Long
    Private vmcrio2 As Long
    Private archivo1 As Boolean
    Private archivo2 As Boolean
    Private archivo3 As Boolean
    Private contadorfilas As Integer

    ''***Bentley *********************
    Private a1sumagrasa1 As Double
    Private a1sumagrasa2 As Double
    Private a1sumaprot1 As Double
    Private a1sumaprot2 As Double
    Private a1sumalact1 As Double
    Private a1sumalact2 As Double
    Private a1sumast1 As Double
    Private a1sumast2 As Double
    Private a1sumacel1 As Long
    Private a1sumacel2 As Long

    Private a1vmgrasa1 As Double
    Private a1vmgrasa2 As Double
    Private a1vmprot1 As Double
    Private a1vmprot2 As Double
    Private a1vmlact1 As Double
    Private a1vmlact2 As Double
    Private a1vmst1 As Double
    Private a1vmst2 As Double
    Private a1vmcel1 As Long
    Private a1vmcel2 As Long

    ''** Delta 400 ************************
    Private a2sumagrasa1 As Double
    Private a2sumagrasa2 As Double
    Private a2sumaprot1 As Double
    Private a2sumaprot2 As Double
    Private a2sumalact1 As Double
    Private a2sumalact2 As Double
    Private a2sumast1 As Double
    Private a2sumast2 As Double
    Private a2sumacel1 As Long
    Private a2sumacel2 As Long
    Private a2sumaurea1 As Long
    Private a2sumaurea2 As Long
    Private a2sumacrio1 As Long
    Private a2sumacrio2 As Long

    Private a2vmgrasa1 As Double
    Private a2vmgrasa2 As Double
    Private a2vmprot1 As Double
    Private a2vmprot2 As Double
    Private a2vmlact1 As Double
    Private a2vmlact2 As Double
    Private a2vmst1 As Double
    Private a2vmst2 As Double
    Private a2vmcel1 As Long
    Private a2vmcel2 As Long
    Private a2vmurea1 As Long
    Private a2vmurea2 As Long
    Private a2vmcrio1 As Long
    Private a2vmcrio2 As Long

    ''** Delta 600 ************************
    Private a3sumagrasa1 As Double
    Private a3sumagrasa2 As Double
    Private a3sumaprot1 As Double
    Private a3sumaprot2 As Double
    Private a3sumalact1 As Double
    Private a3sumalact2 As Double
    Private a3sumast1 As Double
    Private a3sumast2 As Double
    Private a3sumacel1 As Long
    Private a3sumacel2 As Long
    Private a3sumaurea1 As Long
    Private a3sumaurea2 As Long
    Private a3sumacrio1 As Long
    Private a3sumacrio2 As Long

    Private a3vmgrasa1 As Double
    Private a3vmgrasa2 As Double
    Private a3vmprot1 As Double
    Private a3vmprot2 As Double
    Private a3vmlact1 As Double
    Private a3vmlact2 As Double
    Private a3vmst1 As Double
    Private a3vmst2 As Double
    Private a3vmcel1 As Long
    Private a3vmcel2 As Long
    Private a3vmurea1 As Long
    Private a3vmurea2 As Long
    Private a3vmcrio1 As Long
    Private a3vmcrio2 As Long
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
        limpiar()

    End Sub
#End Region
    Private Sub limpiar()
        DateFecha.Value = Now
        TextBentley.Text = ""
        TextDelta400.Text = ""
        TextDelta600.Text = ""
    End Sub

    Private Sub ButtonBentley_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBentley.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.fat)|*.fat"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\Bentley\results"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextBentley.Text = fichero
        End If

        cargobentley()
    End Sub

    Private Sub ButtonDelta400_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelta400.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.csv)|*.csv"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\DELTA400\Samples\"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextDelta400.Text = fichero
        End If

        cargodelta400()
    End Sub
    Private Sub ButtonDelta600_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelta600.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.csv)|*.csv"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\DELTA2\Export\CSV"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextDelta600.Text = fichero
        End If

        cargodelta600()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProcesar.Click
        If TextBentley.Text <> "" And TextDelta400.Text <> "" And TextDelta600.Text <> "" Then
            archivo_1_2_3()
        ElseIf TextBentley.Text <> "" And TextDelta400.Text <> "" And TextDelta600.Text = "" Then
            archivo_1_2()
        ElseIf TextBentley.Text <> "" And TextDelta600.Text <> "" And TextDelta400.Text = "" Then
            archivo_1_3()
        ElseIf TextDelta400.Text <> "" And TextDelta600.Text <> "" And TextBentley.Text = "" Then
            archivo_2_3()
        ElseIf TextDelta400.Text <> "" And TextDelta600.Text = "" And TextBentley.Text = "" Then
            archivo_2()
        ElseIf TextDelta400.Text = "" And TextDelta600.Text <> "" And TextBentley.Text = "" Then
            archivo_3()
        ElseIf TextDelta400.Text = "" And TextDelta600.Text = "" And TextBentley.Text <> "" Then
            archivo_1()
        End If
    End Sub
    Private Sub archivo_1()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim vm As New dVMediosBD
        vmgrasa1 = Math.Round(a1vmgrasa1, 2)
        vmgrasa2 = Math.Round(a1vmgrasa2, 2)
        vmprot1 = Math.Round(a1vmprot1, 2)
        vmprot2 = Math.Round(a1vmprot2, 2)
        vmlact1 = Math.Round(a1vmlact1, 2)
        vmlact2 = Math.Round(a1vmlact2, 2)
        vmst1 = Math.Round(a1vmst1, 2)
        vmst2 = Math.Round(a1vmst2, 2)
        vmcel1 = Math.Round(a1vmcel1, 0)
        vmcel2 = Math.Round(a1vmcel2, 0)
        vmurea1 = -1000
        vmurea2 = -1000
        vmcrio1 = -1000
        vmcrio2 = -1000

        vm.FECHA = fec
        vm.GRASA = vmgrasa1
        vm.GRASA2 = vmgrasa2
        vm.PROTEINA = vmprot1
        vm.PROTEINA2 = vmprot2
        vm.LACTOSA = vmlact1
        vm.LACTOSA2 = vmlact2
        vm.SOLTOTALES = vmst1
        vm.SOLTOTALES2 = vmst2
        vm.CELULAS = vmcel1
        vm.CELULAS2 = vmcel2
        vm.UREA = vmurea1
        vm.UREA2 = vmurea2
        vm.CRIOSCOPIA = vmcrio1
        vm.CRIOSCOPIA2 = vmcrio2
        If (vm.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'listaragua()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        vm = Nothing
    End Sub
    Private Sub archivo_2()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim vm As New dVMediosBD
        vmgrasa1 = Math.Round(a2vmgrasa1, 2)
        vmgrasa2 = Math.Round(a2vmgrasa2, 2)
        vmprot1 = Math.Round(a2vmprot1, 2)
        vmprot2 = Math.Round(a2vmprot2, 2)
        vmlact1 = Math.Round(a2vmlact1, 2)
        vmlact2 = Math.Round(a2vmlact2, 2)
        vmst1 = Math.Round(a2vmst1, 2)
        vmst2 = Math.Round(a2vmst2, 2)
        vmcel1 = Math.Round(a2vmcel1, 0)
        vmcel2 = Math.Round(a2vmcel2, 0)
        vmurea1 = Math.Round(a2vmurea1, 0)
        vmurea2 = Math.Round(a2vmurea2, 0)
        vmcrio1 = Math.Round(a2vmcrio1, 0)
        vmcrio2 = Math.Round(a2vmcrio2, 0)

        vm.FECHA = fec
        vm.GRASA = vmgrasa1
        vm.GRASA2 = vmgrasa2
        vm.PROTEINA = vmprot1
        vm.PROTEINA2 = vmprot2
        vm.LACTOSA = vmlact1
        vm.LACTOSA2 = vmlact2
        vm.SOLTOTALES = vmst1
        vm.SOLTOTALES2 = vmst2
        vm.CELULAS = vmcel1
        vm.CELULAS2 = vmcel2
        vm.UREA = vmurea1
        vm.UREA2 = vmurea2
        vm.CRIOSCOPIA = vmcrio1
        vm.CRIOSCOPIA2 = vmcrio2
        If (vm.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'listaragua()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        vm = Nothing
    End Sub
    Private Sub archivo_3()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim vm As New dVMediosBD
        vmgrasa1 = Math.Round(a3vmgrasa1, 2)
        vmgrasa2 = Math.Round(a3vmgrasa2, 2)
        vmprot1 = Math.Round(a3vmprot1, 2)
        vmprot2 = Math.Round(a3vmprot2, 2)
        vmlact1 = Math.Round(a3vmlact1, 2)
        vmlact2 = Math.Round(a3vmlact2, 2)
        vmst1 = Math.Round(a3vmst1, 2)
        vmst2 = Math.Round(a3vmst2, 2)
        vmcel1 = Math.Round(a3vmcel1, 0)
        vmcel2 = Math.Round(a3vmcel2, 0)
        vmurea1 = Math.Round(a3vmurea1, 0)
        vmurea2 = Math.Round(a3vmurea2, 0)
        vmcrio1 = Math.Round(a3vmcrio1, 0)
        vmcrio2 = Math.Round(a3vmcrio2, 0)

        vm.FECHA = fec
        vm.GRASA = vmgrasa1
        vm.GRASA2 = vmgrasa2
        vm.PROTEINA = vmprot1
        vm.PROTEINA2 = vmprot2
        vm.LACTOSA = vmlact1
        vm.LACTOSA2 = vmlact2
        vm.SOLTOTALES = vmst1
        vm.SOLTOTALES2 = vmst2
        vm.CELULAS = vmcel1
        vm.CELULAS2 = vmcel2
        vm.UREA = vmurea1
        vm.UREA2 = vmurea2
        vm.CRIOSCOPIA = vmcrio1
        vm.CRIOSCOPIA2 = vmcrio2
        If (vm.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'listaragua()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        vm = Nothing
    End Sub
    Private Sub archivo_1_2_3()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim vm As New dVMediosBD
        vmgrasa1 = Math.Round((a1vmgrasa1 + a2vmgrasa1 + a3vmgrasa1) / 3, 2)
        vmgrasa2 = Math.Round((a1vmgrasa2 + a2vmgrasa2 + a3vmgrasa2) / 3, 2)
        vmprot1 = Math.Round((a1vmprot1 + a2vmprot1 + a3vmprot1) / 3, 2)
        vmprot2 = Math.Round((a1vmprot2 + a2vmprot2 + a3vmprot2) / 3, 2)
        vmlact1 = Math.Round((a1vmlact1 + a2vmlact1 + a3vmlact1) / 3, 2)
        vmlact2 = Math.Round((a1vmlact2 + a2vmlact2 + a3vmlact2) / 3, 2)
        vmst1 = Math.Round((a1vmst1 + a2vmst1 + a3vmst1) / 3, 2)
        vmst2 = Math.Round((a1vmst2 + a2vmst2 + a3vmst2) / 3, 2)
        vmcel1 = Math.Round((a1vmcel1 + a2vmcel1 + a3vmcel1) / 3, 0)
        vmcel2 = Math.Round((a1vmcel2 + a2vmcel2 + a3vmcel2) / 3, 0)
        vmurea1 = Math.Round((a2vmurea1 + a3vmurea1) / 2, 0)
        vmurea2 = Math.Round((a2vmurea2 + a3vmurea2) / 2, 0)
        vmcrio1 = Math.Round((a2vmcrio1 + a3vmcrio1) / 2, 0)
        vmcrio2 = Math.Round((a2vmcrio2 + a3vmcrio2) / 2, 0)

        vm.FECHA = fec
        vm.GRASA = vmgrasa1
        vm.GRASA2 = vmgrasa2
        vm.PROTEINA = vmprot1
        vm.PROTEINA2 = vmprot2
        vm.LACTOSA = vmlact1
        vm.LACTOSA2 = vmlact2
        vm.SOLTOTALES = vmst1
        vm.SOLTOTALES2 = vmst2
        vm.CELULAS = vmcel1
        vm.CELULAS2 = vmcel2
        vm.UREA = vmurea1
        vm.UREA2 = vmurea2
        vm.CRIOSCOPIA = vmcrio1
        vm.CRIOSCOPIA2 = vmcrio2
        If (vm.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'listaragua()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        vm = Nothing
    End Sub
    Private Sub archivo_1_2()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim vm As New dVMediosBD
        vmgrasa1 = Math.Round((a1vmgrasa1 + a2vmgrasa1) / 2, 2)
        vmgrasa2 = Math.Round((a1vmgrasa2 + a2vmgrasa2) / 2, 2)
        vmprot1 = Math.Round((a1vmprot1 + a2vmprot1) / 2, 2)
        vmprot2 = Math.Round((a1vmprot2 + a2vmprot2) / 2, 2)
        vmlact1 = Math.Round((a1vmlact1 + a2vmlact1) / 2, 2)
        vmlact2 = Math.Round((a1vmlact2 + a2vmlact2) / 2, 2)
        vmst1 = Math.Round((a1vmst1 + a2vmst1) / 2, 2)
        vmst2 = Math.Round((a1vmst2 + a2vmst2) / 2, 2)
        vmcel1 = Math.Round((a1vmcel1 + a2vmcel1) / 2, 0)
        vmcel2 = Math.Round((a1vmcel2 + a2vmcel2) / 2, 0)
        vmurea1 = Math.Round(a2vmurea1, 0)
        vmurea2 = Math.Round(a2vmurea2, 0)
        vmcrio1 = Math.Round(a2vmcrio1, 0)
        vmcrio2 = Math.Round(a2vmcrio2, 0)

        vm.FECHA = fec
        vm.GRASA = vmgrasa1
        vm.GRASA2 = vmgrasa2
        vm.PROTEINA = vmprot1
        vm.PROTEINA2 = vmprot2
        vm.LACTOSA = vmlact1
        vm.LACTOSA2 = vmlact2
        vm.SOLTOTALES = vmst1
        vm.SOLTOTALES2 = vmst2
        vm.CELULAS = vmcel1
        vm.CELULAS2 = vmcel2
        vm.UREA = vmurea1
        vm.UREA2 = vmurea2
        vm.CRIOSCOPIA = vmcrio1
        vm.CRIOSCOPIA2 = vmcrio2
        If (vm.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'listaragua()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        vm = Nothing
    End Sub
    Private Sub archivo_1_3()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim vm As New dVMediosBD
        vmgrasa1 = Math.Round((a1vmgrasa1 + a3vmgrasa1) / 2, 2)
        vmgrasa2 = Math.Round((a1vmgrasa2 + a3vmgrasa2) / 2, 2)
        vmprot1 = Math.Round((a1vmprot1 + a3vmprot1) / 2, 2)
        vmprot2 = Math.Round((a1vmprot2 + a3vmprot2) / 2, 2)
        vmlact1 = Math.Round((a1vmlact1 + a3vmlact1) / 2, 2)
        vmlact2 = Math.Round((a1vmlact2 + a3vmlact2) / 2, 2)
        vmst1 = Math.Round((a1vmst1 + a3vmst1) / 2, 2)
        vmst2 = Math.Round((a1vmst2 + a3vmst2) / 2, 2)
        vmcel1 = Math.Round((a1vmcel1 + a3vmcel1) / 2, 0)
        vmcel2 = Math.Round((a1vmcel2 + a3vmcel2) / 2, 0)
        vmurea1 = Math.Round(a3vmurea1, 0)
        vmurea2 = Math.Round(a3vmurea2, 0)
        vmcrio1 = Math.Round(a3vmcrio1, 0)
        vmcrio2 = Math.Round(a3vmcrio2, 0)

        vm.FECHA = fec
        vm.GRASA = vmgrasa1
        vm.GRASA2 = vmgrasa2
        vm.PROTEINA = vmprot1
        vm.PROTEINA2 = vmprot2
        vm.LACTOSA = vmlact1
        vm.LACTOSA2 = vmlact2
        vm.SOLTOTALES = vmst1
        vm.SOLTOTALES2 = vmst2
        vm.CELULAS = vmcel1
        vm.CELULAS2 = vmcel2
        vm.UREA = vmurea1
        vm.UREA2 = vmurea2
        vm.CRIOSCOPIA = vmcrio1
        vm.CRIOSCOPIA2 = vmcrio2
        If (vm.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'listaragua()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        vm = Nothing
    End Sub
    Private Sub archivo_2_3()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim vm As New dVMediosBD
        vmgrasa1 = Math.Round((a2vmgrasa1 + a3vmgrasa1) / 2, 2)
        vmgrasa2 = Math.Round((a2vmgrasa2 + a3vmgrasa2) / 2, 2)
        vmprot1 = Math.Round((a2vmprot1 + a3vmprot1) / 2, 2)
        vmprot2 = Math.Round((a2vmprot2 + a3vmprot2) / 2, 2)
        vmlact1 = Math.Round((a2vmlact1 + a3vmlact1) / 2, 2)
        vmlact2 = Math.Round((a2vmlact2 + a3vmlact2) / 2, 2)
        vmst1 = Math.Round((a2vmst1 + a3vmst1) / 2, 2)
        vmst2 = Math.Round((a2vmst2 + a3vmst2) / 2, 2)
        vmcel1 = Math.Round((a2vmcel1 + a3vmcel1) / 2, 0)
        vmcel2 = Math.Round((a2vmcel2 + a3vmcel2) / 2, 0)
        vmurea1 = Math.Round((a2vmurea1 + a3vmurea1) / 2, 0)
        vmurea2 = Math.Round((a2vmurea2 + a3vmurea2) / 2, 0)
        vmcrio1 = Math.Round((a2vmcrio1 + a3vmcrio1) / 2, 0)
        vmcrio2 = Math.Round((a2vmcrio2 + a3vmcrio2) / 2, 0)

        vm.FECHA = fec
        vm.GRASA = vmgrasa1
        vm.GRASA2 = vmgrasa2
        vm.PROTEINA = vmprot1
        vm.PROTEINA2 = vmprot2
        vm.LACTOSA = vmlact1
        vm.LACTOSA2 = vmlact2
        vm.SOLTOTALES = vmst1
        vm.SOLTOTALES2 = vmst2
        vm.CELULAS = vmcel1
        vm.CELULAS2 = vmcel2
        vm.UREA = vmurea1
        vm.UREA2 = vmurea2
        vm.CRIOSCOPIA = vmcrio1
        vm.CRIOSCOPIA2 = vmcrio2
        If (vm.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            'listaragua()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        vm = Nothing
    End Sub

    Private Sub cargodelta400()
        Dim nombrearchivo As String = ""
        nombrearchivo = TextDelta400.Text.Trim
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim linea As Integer = 1
        Dim Texto() As String
        Dim arraytext() As String
        Do
            sLine = objReader.ReadLine()
            If sLine <> " " Then
                arraytext = Split(sLine, ";")
                If linea > 7 And linea < 18 Then
                    'Grasa**********************************
                    If Trim(arraytext(5)) <> "" Then
                        a2sumagrasa1 = a2sumagrasa1 + Trim(arraytext(5))
                    End If
                    'Proteina*******************************
                    If Trim(arraytext(6)) <> "" Then
                        a2sumaprot1 = a2sumaprot1 + Trim(arraytext(6))
                    End If
                    'Lactosa********************************
                    If Trim(arraytext(7)) <> "" Then
                        a2sumalact1 = a2sumalact1 + Trim(arraytext(7))
                    End If
                    'Sólidos totales************************
                    If Trim(arraytext(8)) <> "" Then
                        a2sumast1 = a2sumast1 + Trim(arraytext(8))
                    End If
                    'Células********************************
                    If Trim(arraytext(3)) <> "" Then
                        a2sumacel1 = a2sumacel1 + Trim(arraytext(3))
                    End If
                    'Crioscopía********************************
                    If Trim(arraytext(9)) <> "" Then
                        a2sumacrio1 = a2sumacrio1 + Trim(arraytext(9))
                    End If
                    'Urea********************************
                    If Trim(arraytext(10)) <> "" Then
                        a2sumaurea1 = a2sumaurea1 + Trim(arraytext(10))
                    End If
                ElseIf linea > 17 And linea < 28 Then
                    'Grasa**********************************
                    If Trim(arraytext(5)) <> "" Then
                        a2sumagrasa2 = a2sumagrasa2 + Trim(arraytext(5))
                    End If
                    'Proteina*******************************
                    If Trim(arraytext(6)) <> "" Then
                        a2sumaprot2 = a2sumaprot2 + Trim(arraytext(6))
                    End If
                    'Lactosa********************************
                    If Trim(arraytext(7)) <> "" Then
                        a2sumalact2 = a2sumalact2 + Trim(arraytext(7))
                    End If
                    'Sólidos totales************************
                    If Trim(arraytext(8)) <> "" Then
                        a2sumast2 = a2sumast2 + Trim(arraytext(8))
                    End If
                    'Células********************************
                    If Trim(arraytext(3)) <> "" Then
                        a2sumacel2 = a2sumacel2 + Trim(arraytext(3))
                    End If
                    'Crioscopía********************************
                    If Trim(arraytext(9)) <> "" Then
                        a2sumacrio2 = a2sumacrio2 + Trim(arraytext(9))
                    End If
                    'Urea********************************
                    If Trim(arraytext(10)) <> "" Then
                        a2sumaurea2 = a2sumaurea2 + Trim(arraytext(10))
                    End If
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing

        a2vmgrasa1 = a2sumagrasa1 / 10
        a2vmgrasa2 = a2sumagrasa2 / 10
        a2vmprot1 = a2sumaprot1 / 10
        a2vmprot2 = a2sumaprot2 / 10
        a2vmlact1 = a2sumalact1 / 10
        a2vmlact2 = a2sumalact2 / 10
        a2vmst1 = a2sumast1 / 10
        a2vmst2 = a2sumast2 / 10
        a2vmcel1 = a2sumacel1 / 10
        a2vmcel2 = a2sumacel2 / 10
        a2vmcrio1 = a2sumacrio1 / 10
        a2vmcrio2 = a2sumacrio2 / 10
        a2vmurea1 = a2sumaurea1 / 10
        a2vmurea2 = a2sumaurea2 / 10
    End Sub
    Private Sub cargodelta600()
        Dim nombrearchivo As String = ""
        nombrearchivo = TextDelta600.Text.Trim
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim linea As Integer = 1
        Dim Texto() As String
        Do
            sLine = objReader.ReadLine()
            If sLine <> " " Then
                Texto = Split(sLine, ";")
                If linea > 7 And linea < 18 Then
                    'Grasa**********************************
                    If Trim(Texto(11)) <> "" Then
                        a3sumagrasa1 = a3sumagrasa1 + Trim(Texto(11))
                    End If
                    'Proteina*******************************
                    If Trim(Texto(12)) <> "" Then
                        a3sumaprot1 = a3sumaprot1 + Trim(Texto(12))
                    End If
                    'Lactosa********************************
                    If Trim(Texto(13)) <> "" Then
                        a3sumalact1 = a3sumalact1 + Trim(Texto(13))
                    End If
                    'Sólidos totales************************
                    If Trim(Texto(14)) <> "" Then
                        a3sumast1 = a3sumast1 + Trim(Texto(14))
                    End If
                    'Células********************************
                    If Trim(Texto(9)) <> "" Then
                        a3sumacel1 = a3sumacel1 + Trim(Texto(9))
                    End If
                    'Crioscopía********************************
                    If Trim(Texto(15)) <> "" Then
                        a3sumacrio1 = a3sumacrio1 + Trim(Texto(15))
                    End If
                    'Urea********************************
                    If Trim(Texto(16)) <> "" Then
                        a3sumaurea1 = a3sumaurea1 + Trim(Texto(16))
                    End If
                ElseIf linea > 17 And linea < 28 Then
                    'Grasa**********************************
                    If Trim(Texto(11)) <> "" Then
                        a3sumagrasa2 = a3sumagrasa2 + Trim(Texto(11))
                    End If
                    'Proteina*******************************
                    If Trim(Texto(12)) <> "" Then
                        a3sumaprot2 = a3sumaprot2 + Trim(Texto(12))
                    End If
                    'Lactosa********************************
                    If Trim(Texto(13)) <> "" Then
                        a3sumalact2 = a3sumalact2 + Trim(Texto(13))
                    End If
                    'Sólidos totales************************
                    If Trim(Texto(14)) <> "" Then
                        a3sumast2 = a3sumast2 + Trim(Texto(14))
                    End If
                    'Células********************************
                    If Trim(Texto(9)) <> "" Then
                        a3sumacel2 = a3sumacel2 + Trim(Texto(9))
                    End If
                    'Crioscopía********************************
                    If Trim(Texto(15)) <> "" Then
                        a3sumacrio2 = a3sumacrio2 + Trim(Texto(15))
                    End If
                    'Urea********************************
                    If Trim(Texto(16)) <> "" Then
                        a3sumaurea2 = a3sumaurea2 + Trim(Texto(16))
                    End If
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing

        a3vmgrasa1 = a3sumagrasa1 / 10
        a3vmgrasa2 = a3sumagrasa2 / 10
        a3vmprot1 = a3sumaprot1 / 10
        a3vmprot2 = a3sumaprot2 / 10
        a3vmlact1 = a3sumalact1 / 10
        a3vmlact2 = a3sumalact2 / 10
        a3vmst1 = a3sumast1 / 10
        a3vmst2 = a3sumast2 / 10
        a3vmcel1 = a3sumacel1 / 10
        a3vmcel2 = a3sumacel2 / 10
        a3vmcrio1 = a3sumacrio1 / 10
        a3vmcrio2 = a3sumacrio2 / 10
        a3vmurea1 = a3sumaurea1 / 10
        a3vmurea2 = a3sumaurea2 / 10
    End Sub
    Private Sub cargobentley()
        Dim nombrearchivo As String = ""
        nombrearchivo = TextBentley.Text.Trim
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim linea As Integer = 1
        Dim Texto As String
        Do
            sLine = objReader.ReadLine()
            If sLine <> " " Then
                Texto = sLine
                If linea < 11 Then
                    'Grasa**********************************
                    If Trim(Mid(Texto, 18, 9)) <> "" Then
                        a1sumagrasa1 = a1sumagrasa1 + Trim(Mid(Texto, 18, 9))
                    End If
                    'Proteina*******************************
                    If Trim(Mid(Texto, 27, 9)) <> "" Then
                        a1sumaprot1 = a1sumaprot1 + Trim(Mid(Texto, 27, 9))
                    End If
                    'Lactosa********************************
                    If Trim(Mid(Texto, 36, 9)) <> "" Then
                        a1sumalact1 = a1sumalact1 + Trim(Mid(Texto, 36, 9))
                    End If
                    'Sólidos totales************************
                    If Trim(Mid(Texto, 45, 9)) <> "" Then
                        a1sumast1 = a1sumast1 + Trim(Mid(Texto, 45, 9))
                    End If
                    'Células********************************
                    If Trim(Mid(Texto, 54, 9)) <> "" Then
                        a1sumacel1 = a1sumacel1 + Trim(Mid(Texto, 54, 10))
                    End If
                ElseIf linea > 10 And linea < 21 Then
                    'Grasa**********************************
                    If Trim(Mid(Texto, 18, 9)) <> "" Then
                        a1sumagrasa2 = a1sumagrasa2 + Trim(Mid(Texto, 18, 9))
                    End If
                    'Proteina*******************************
                    If Trim(Mid(Texto, 27, 9)) <> "" Then
                        a1sumaprot2 = a1sumaprot2 + Trim(Mid(Texto, 27, 9))
                    End If
                    'Lactosa********************************
                    If Trim(Mid(Texto, 36, 9)) <> "" Then
                        a1sumalact2 = a1sumalact2 + Trim(Mid(Texto, 36, 9))
                    End If
                    'Sólidos totales************************
                    If Trim(Mid(Texto, 45, 9)) <> "" Then
                        a1sumast2 = a1sumast2 + Trim(Mid(Texto, 45, 9))
                    End If
                    'Células********************************
                    If Trim(Mid(Texto, 54, 9)) <> "" Then
                        a1sumacel2 = a1sumacel2 + Trim(Mid(Texto, 54, 10))
                    End If
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing

        a1vmgrasa1 = a1sumagrasa1 / 10
        a1vmgrasa2 = a1sumagrasa2 / 10
        a1vmprot1 = a1sumaprot1 / 10
        a1vmprot2 = a1sumaprot2 / 10
        a1vmlact1 = a1sumalact1 / 10
        a1vmlact2 = a1sumalact2 / 10
        a1vmst1 = a1sumast1 / 10
        a1vmst2 = a1sumast2 / 10
        a1vmcel1 = a1sumacel1 / 10
        a1vmcel2 = a1sumacel2 / 10
    End Sub

End Class