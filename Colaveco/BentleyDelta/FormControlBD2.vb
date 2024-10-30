Imports System
Imports System.IO
Imports System.Collections

Public Class FormControlBD2
    Private _usuario As dUsuario
    Private arch1 As Integer = 0
    Private arch2 As Integer = 0
    Private arch3 As Integer = 0
    Private fecha_fat As Date = Now
    Private fec_fat As String = ""
    Private hora_fat As String = ""
    Private _fecha As Date
    Private _fec As String = ""
    Dim archivox As String = ""
    'Definimos las variables q' necesitaremos
  
    Dim contador As Integer
    Dim ruta As String
    Dim archivo As String
    Dim fila As Long
    Dim columna As Long
    Dim posicion As Long
    Dim posicion2 As Long
    Dim uno As Integer
    Dim largo As Integer

    Private analisis As New dAnalisisBD
    Private vmedios As dVMediosBD
    Private ccresultados As dResultadosBD
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
        cargarultimoVM()

    End Sub
#End Region
   
    Private Sub ButtonResultados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResultados.Click
        'Dim v As New FormResultadosBD
        'v.Show()
        Dim v As New FormBentleyDeltaHistorial
        v.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCargarVM.Click
        Dim v As New FormValoresMediosBD(Usuario)
        v.Show()
        cargarultimoVM()
    End Sub
    Private Sub cargarultimoVM()
        Dim vm As New dVMediosBD
        Dim lista As New ArrayList
        lista = vm.listarultimo
        If Not lista Is Nothing Then
            For Each vm In lista
                DateFecha.Value = vm.FECHA
                TextGrasa1.Text = vm.GRASA
                TextGrasa2.Text = vm.GRASA2
                TextProteina1.Text = vm.PROTEINA
                TextProteina2.Text = vm.PROTEINA2
                TextLactosa1.Text = vm.LACTOSA
                TextLactosa2.Text = vm.LACTOSA2
                TextSTotales1.Text = vm.SOLTOTALES
                TextSTotales2.Text = vm.SOLTOTALES2
                TextCelulas1.Text = vm.CELULAS
                TextCelulas2.Text = vm.CELULAS2
                TextCrioscopia1.Text = vm.CRIOSCOPIA
                TextCrioscopia2.Text = vm.CRIOSCOPIA2
                TextUrea1.Text = vm.UREA
                TextUrea2.Text = vm.UREA2
            Next
        End If
        vm = Nothing
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
            Dim Archivo As New FileInfo(fichero)
            fecha_fat = Archivo.LastWriteTime.ToShortDateString
            fec_fat = Format(fecha_fat, "yyyy-MM-dd")
            hora_fat = Archivo.LastWriteTime.ToShortTimeString
            archivox = Archivo.Name
            TextArchivo.Text = fichero
            arch1 = 1
            arch2 = 0
            arch3 = 0
        End If
        If TextArchivo.Text <> "" Then
            proceso_bentley()
        End If
    End Sub
   
    Private Sub ButtonDelta400_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.man)|*.man"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\DELTA400\Samples\"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            Dim Archivo As New FileInfo(fichero)
            fecha_fat = Archivo.LastWriteTime.ToShortDateString
            fec_fat = Format(fecha_fat, "yyyy-MM-dd")
            hora_fat = Archivo.LastWriteTime.ToShortTimeString
            archivox = Archivo.Name
            TextArchivo.Text = fichero
        End If
        If TextArchivo.Text <> "" Then
            proceso_delta400()
        End If
    End Sub

    Private Sub ButtonProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProcesar.Click
        grabo_resultados()
    End Sub

    Private Sub ButtonDelta600_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelta600.Click
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
            Dim Archivo As New FileInfo(fichero)
            fecha_fat = Archivo.LastWriteTime.ToShortDateString
            fec_fat = Format(fecha_fat, "yyyy-MM-dd")
            hora_fat = Archivo.LastWriteTime.ToShortTimeString
            archivox = Archivo.Name
            TextArchivo.Text = fichero
        End If
        If TextArchivo.Text <> "" Then
            proceso_delta600("D6")
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormBuscarVM
        v.ShowDialog()
        If Not v.VM Is Nothing Then
            Dim vm As dVMediosBD = v.VM
            DateFecha.Value = vm.FECHA
            TextGrasa1.Text = vm.GRASA
            TextGrasa2.Text = vm.GRASA2
            TextProteina1.Text = vm.PROTEINA
            TextProteina2.Text = vm.PROTEINA2
            TextLactosa1.Text = vm.LACTOSA
            TextLactosa2.Text = vm.LACTOSA2
            TextSTotales1.Text = vm.SOLTOTALES
            TextSTotales2.Text = vm.SOLTOTALES2
            TextCelulas1.Text = vm.CELULAS
            TextCelulas2.Text = vm.CELULAS2
            TextCrioscopia1.Text = vm.CRIOSCOPIA
            TextCrioscopia2.Text = vm.CRIOSCOPIA2
            TextUrea1.Text = vm.UREA
            TextUrea2.Text = vm.UREA2
        End If
    End Sub
    Private Sub proceso_bentley()
        Dim nombrearchivo As String = ""
        nombrearchivo = TextArchivo.Text.Trim
        '********************************************************
        Dim linea As Integer = 1
        Dim linea_ As Integer = 0
        Dim ident As Long = 0
        Dim fecha As String = ""
        Dim hora As String = ""
        Dim id As Integer = 0
        Dim grasa As Double = 0
        Dim proteina As Double = 0
        Dim lactosa As Double = 0
        Dim soltotales As Double = 0
        Dim celulas As Integer = 0
        Dim crioscopia As Integer = 0
        Dim urea As Integer = 0
        Dim equipo As String = ""
        Dim vmgrasa As Double = 0
        Dim vmproteina As Double = 0
        Dim vmlactosa As Double = 0
        Dim vmstotales As Double = 0
        Dim vmcelulas As Integer = 0
        Dim vmcrioscopia As Integer = 0
        Dim vmurea As Integer = 0
        Dim archivo As String = ""
        Dim fila As Integer = 0

        '********************************************************
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim a As New dAnalisisBD
        Dim a2 As New dAnalisisBD2
        Dim ax As New dAnalisisBD2
        Dim lista As New ArrayList
        lista = ax.listarxarchivo(archivox)
        If Not lista Is Nothing Then
            For Each ax In lista
                linea_ = ax.FILA
            Next
        End If

        Dim Texto As String

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                Texto = sLine
                If linea > linea_ Then
                    'id**********************************
                    If Trim(Mid(Texto, 8, 1)) <> "" Then
                        id = Trim(Mid(Texto, 8, 1))
                    End If
                    'ident**********************************
                    If Trim(Mid(Texto, 17, 1)) <> "" Then
                        ident = Trim(Mid(Texto, 17, 1))
                    End If
                    'Grasa**********************************
                    If Trim(Mid(Texto, 18, 9)) <> "" Then
                        grasa = Trim(Mid(Texto, 18, 9))
                    End If
                    'Proteina*******************************
                    If Trim(Mid(Texto, 27, 9)) <> "" Then
                        proteina = Trim(Mid(Texto, 27, 9))
                    End If
                    'Lactosa********************************
                    If Trim(Mid(Texto, 36, 9)) <> "" Then
                        lactosa = Trim(Mid(Texto, 36, 9))
                    End If
                    'Sólidos totales************************
                    If Trim(Mid(Texto, 45, 9)) <> "" Then
                        soltotales = Trim(Mid(Texto, 45, 9))
                    End If
                    'Células********************************
                    If Trim(Mid(Texto, 54, 9)) <> "" Then
                        celulas = Trim(Mid(Texto, 54, 10))
                    End If
                End If
                crioscopia = 0
                urea = 0
                equipo = "B"
                If ident = 1 Then
                    vmgrasa = TextGrasa1.Text.Trim
                    vmproteina = TextProteina1.Text.Trim
                    vmlactosa = TextLactosa1.Text.Trim
                    vmstotales = TextSTotales1.Text.Trim
                    vmcelulas = TextCelulas1.Text.Trim
                    vmcrioscopia = TextCrioscopia1.Text.Trim
                    vmurea = TextUrea1.Text.Trim
                ElseIf ident = 2 Then
                    vmgrasa = TextGrasa2.Text.Trim
                    vmproteina = TextProteina2.Text.Trim
                    vmlactosa = TextLactosa2.Text.Trim
                    vmstotales = TextSTotales2.Text.Trim
                    vmcelulas = TextCelulas2.Text.Trim
                    vmcrioscopia = TextCrioscopia2.Text.Trim
                    vmurea = TextUrea2.Text.Trim
                End If
                archivo = archivox
                fila = linea
                a.IDENT = ident
                a.FECHA = fec_fat
                a.HORA = hora_fat
                a.ID = id
                a.GRASA = grasa
                a.PROTEINA = proteina
                a.LACTOSA = lactosa
                a.SOLTOTALES = soltotales
                a.CELULAS = celulas
                a.CRIOSCOPIA = crioscopia
                a.UREA = urea
                a.EQUIPO = equipo
                a.VMGRASA = vmgrasa
                a.VMPROTEINA = vmproteina
                a.VMLACTOSA = vmlactosa
                a.VMSTOTALES = vmstotales
                a.VMCELULAS = vmcelulas
                a.VMCRIOSCOPIA = vmcrioscopia
                a.VMUREA = vmurea
                a.ARCHIVO = archivo
                a.FILA = fila

                a2.IDENT = ident
                a2.FECHA = fec_fat
                a2.HORA = hora_fat
                a2.ID = id
                a2.GRASA = grasa
                a2.PROTEINA = proteina
                a2.LACTOSA = lactosa
                a2.SOLTOTALES = soltotales
                a2.CELULAS = celulas
                a2.CRIOSCOPIA = crioscopia
                a2.UREA = urea
                a2.EQUIPO = equipo
                a2.VMGRASA = vmgrasa
                a2.VMPROTEINA = vmproteina
                a2.VMLACTOSA = vmlactosa
                a2.VMSTOTALES = vmstotales
                a2.VMCELULAS = vmcelulas
                a2.VMCRIOSCOPIA = vmcrioscopia
                a2.VMUREA = vmurea
                a2.ARCHIVO = archivo
                a2.FILA = fila
                If linea > linea_ Then
                    a.guardar(Usuario)
                    a2.guardar(Usuario)
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing
        a = Nothing
        a2 = Nothing

    End Sub
    Private Sub proceso_delta400()
        Dim arraytext() As String
        Dim nombrearchivo As String = ""
        nombrearchivo = TextArchivo.Text.Trim
        '********************************************************
        Dim linea As Integer = 1
        Dim linea_ As Integer = 0
        Dim ident As Long = 0
        Dim fecha As String = ""
        Dim hora As String = ""
        Dim id As Integer = 0
        Dim grasa As Double = 0
        Dim proteina As Double = 0
        Dim lactosa As Double = 0
        Dim soltotales As Double = 0
        Dim celulas As Integer = 0
        Dim crioscopia As Integer = 0
        Dim urea As Integer = 0
        Dim equipo As String = ""
        Dim vmgrasa As Double = 0
        Dim vmproteina As Double = 0
        Dim vmlactosa As Double = 0
        Dim vmstotales As Double = 0
        Dim vmcelulas As Integer = 0
        Dim vmcrioscopia As Integer = 0
        Dim vmurea As Integer = 0
        Dim archivo As String = ""
        Dim fila As Integer = 0

        '********************************************************
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim a As New dAnalisisBD
        Dim a2 As New dAnalisisBD2
        Dim ax As New dAnalisisBD2
        Dim lista As New ArrayList
        lista = ax.listarxarchivo(archivox)
        If Not lista Is Nothing Then
            For Each ax In lista
                linea_ = ax.FILA
            Next
        End If

        Dim Texto() As String
        Dim textoblanco As String = "blanco"
        Dim blanco As Integer = 0
        Do
            sLine = objReader.ReadLine()
            'CONTROLO QUE NO HAYA BLANCOS**************************************************************
            If Not sLine Is Nothing Then
                If sLine.ToUpper().Contains(textoblanco.ToUpper()) Then
                    blanco = 1
                Else
                    blanco = 0
                End If
            End If
            '**************************************************************
            If Not sLine Is Nothing Then
                arraytext = Split(sLine, ";")
                'Texto = Split(sLine, ";")
                If linea > linea_ Then
                    If linea > 2 Then
                        If blanco = 0 Then
                            'id**********************************
                            If Trim(arraytext(1)) <> "" Then
                                id = Trim(arraytext(1))
                            End If
                            'ident**********************************
                            If Trim(arraytext(1)) <> "" Then
                                'ident = Trim(Texto(2))
                                Try
                                    ident = arraytext(1)
                                Catch ex As Exception
                                    MsgBox("Error en archivo: " & archivox & ", línea: " & linea)
                                End Try

                            End If
                            'Grasa**********************************
                            If Trim(arraytext(5)) <> "" Then
                                grasa = Trim(arraytext(5))
                            End If
                            'Proteina*******************************
                            If Trim(arraytext(6)) <> "" Then
                                proteina = Trim(arraytext(6))
                            End If
                            'Lactosa********************************
                            If Trim(arraytext(7)) <> "" Then
                                lactosa = Trim(arraytext(7))
                            End If
                            'Sólidos totales************************
                            If Trim(arraytext(8)) <> "" Then
                                soltotales = Trim(arraytext(8))
                            End If
                            'Células********************************
                            If Trim(arraytext(3)) <> "" Then
                                celulas = Trim(arraytext(3))
                            End If
                            'Crioscopía********************************
                            If Trim(arraytext(9)) <> "" Then
                                crioscopia = Trim(arraytext(9))
                            End If
                            'Urea********************************
                            If Trim(arraytext(10)) <> "" Then
                                urea = Trim(arraytext(10))
                            End If
                        End If
                    End If
                End If
                'crioscopia = 0
                'urea = 0
                equipo = "D4"
                If ident = 1 Then
                    vmgrasa = TextGrasa1.Text.Trim
                    vmproteina = TextProteina1.Text.Trim
                    vmlactosa = TextLactosa1.Text.Trim
                    vmstotales = TextSTotales1.Text.Trim
                    vmcelulas = TextCelulas1.Text.Trim
                    vmcrioscopia = TextCrioscopia1.Text.Trim
                    vmurea = TextUrea1.Text.Trim
                ElseIf ident = 2 Then
                    vmgrasa = TextGrasa2.Text.Trim
                    vmproteina = TextProteina2.Text.Trim
                    vmlactosa = TextLactosa2.Text.Trim
                    vmstotales = TextSTotales2.Text.Trim
                    vmcelulas = TextCelulas2.Text.Trim
                    vmcrioscopia = TextCrioscopia2.Text.Trim
                    vmurea = TextUrea2.Text.Trim
                End If
                archivo = archivox
                fila = linea
                _fecha = fecha_fat
                _fec = Format(_fecha, "yyyy-MM-dd")
                a.IDENT = ident
                a.FECHA = _fec
                a.HORA = hora_fat
                a.ID = id
                a.GRASA = grasa
                a.PROTEINA = proteina
                a.LACTOSA = lactosa
                a.SOLTOTALES = soltotales
                a.CELULAS = celulas
                a.CRIOSCOPIA = crioscopia
                a.UREA = urea
                a.EQUIPO = equipo
                a.VMGRASA = vmgrasa
                a.VMPROTEINA = vmproteina
                a.VMLACTOSA = vmlactosa
                a.VMSTOTALES = vmstotales
                a.VMCELULAS = vmcelulas
                a.VMCRIOSCOPIA = vmcrioscopia
                a.VMUREA = vmurea
                a.ARCHIVO = archivo
                a.FILA = fila

                a2.IDENT = ident
                a2.FECHA = _fec
                a2.HORA = hora_fat
                a2.ID = id
                a2.GRASA = grasa
                a2.PROTEINA = proteina
                a2.LACTOSA = lactosa
                a2.SOLTOTALES = soltotales
                a2.CELULAS = celulas
                a2.CRIOSCOPIA = crioscopia
                a2.UREA = urea
                a2.EQUIPO = equipo
                a2.VMGRASA = vmgrasa
                a2.VMPROTEINA = vmproteina
                a2.VMLACTOSA = vmlactosa
                a2.VMSTOTALES = vmstotales
                a2.VMCELULAS = vmcelulas
                a2.VMCRIOSCOPIA = vmcrioscopia
                a2.VMUREA = vmurea
                a2.ARCHIVO = archivo
                a2.FILA = fila
                If linea > linea_ Then
                    If linea > 2 Then
                        If blanco = 0 Then
                            a.guardar(Usuario)
                            a2.guardar(Usuario)
                        End If
                    End If
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing
        a = Nothing
        a2 = Nothing


    End Sub
    Private Sub proceso_delta600(ByVal pequipo As String)
        Dim nombrearchivo As String = ""
        nombrearchivo = TextArchivo.Text.Trim
        '********************************************************
        Dim linea As Integer = 1
        Dim linea_ As Integer = 0
        Dim ident As Long = 0
        Dim fecha As String = ""
        Dim hora As String = ""
        Dim id As Integer = 0
        Dim grasa As Double = 0
        Dim proteina As Double = 0
        Dim lactosa As Double = 0
        Dim soltotales As Double = 0
        Dim celulas As Integer = 0
        Dim crioscopia As Integer = 0
        Dim urea As Integer = 0
        Dim equipo As String = ""
        Dim vmgrasa As Double = 0
        Dim vmproteina As Double = 0
        Dim vmlactosa As Double = 0
        Dim vmstotales As Double = 0
        Dim vmcelulas As Integer = 0
        Dim vmcrioscopia As Integer = 0
        Dim vmurea As Integer = 0
        Dim archivo As String = ""
        Dim fila As Integer = 0

        '********************************************************
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim a As New dAnalisisBD
        Dim a2 As New dAnalisisBD2
        Dim lista As New ArrayList
        lista = a.listarxarchivo(archivox)
        If Not lista Is Nothing Then
            For Each a In lista
                linea_ = a.FILA
            Next
        End If

        Dim Texto() As String

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                'Texto = sLine
                Texto = Split(sLine, ";")
                'If linea > linea_ Then
                If linea >= 7 Then
                    'id**********************************
                    If Trim(Texto(5)) <> "" Then
                        id = Trim(Texto(5))
                    End If
                    'ident**********************************
                    If Trim(Texto(5)) <> "" Then
                        ident = Trim(Texto(0))
                    End If
                    'Grasa**********************************
                    If Trim(Texto(11)) <> "" Then
                        grasa = Trim(Texto(11))
                    End If
                    'Proteina*******************************
                    If Trim(Texto(12)) <> "" Then
                        proteina = Trim(Texto(12))
                    End If
                    'Lactosa********************************
                    If Trim(Texto(13)) <> "" Then
                        lactosa = Trim(Texto(13))
                    End If
                    'Sólidos totales************************
                    If Trim(Texto(14)) <> "" Then
                        soltotales = Trim(Texto(14))
                    End If
                    'Células********************************
                    If Trim(Texto(9)) <> "" Then
                        celulas = Trim(Texto(9))
                    End If
                    'Crioscopía********************************
                    If Trim(Texto(15)) <> "" Then
                        crioscopia = Trim(Texto(15))
                    End If
                    'Urea********************************
                    If Trim(Texto(16)) <> "" Then
                        urea = Trim(Texto(16))
                    End If
                End If
                'crioscopia = 0
                'urea = 0
                equipo = pequipo
                If ident = 1 Then
                    vmgrasa = TextGrasa1.Text.Trim
                    vmproteina = TextProteina1.Text.Trim
                    vmlactosa = TextLactosa1.Text.Trim
                    vmstotales = TextSTotales1.Text.Trim
                    vmcelulas = TextCelulas1.Text.Trim
                    vmcrioscopia = TextCrioscopia1.Text.Trim
                    vmurea = TextUrea1.Text.Trim
                ElseIf ident = 2 Then
                    vmgrasa = TextGrasa2.Text.Trim
                    vmproteina = TextProteina2.Text.Trim
                    vmlactosa = TextLactosa2.Text.Trim
                    vmstotales = TextSTotales2.Text.Trim
                    vmcelulas = TextCelulas2.Text.Trim
                    vmcrioscopia = TextCrioscopia2.Text.Trim
                    vmurea = TextUrea2.Text.Trim
                End If
                archivo = archivox
                fila = linea
                _fecha = fecha_fat
                _fec = Format(_fecha, "yyyy-MM-dd")
                a.IDENT = ident
                a.FECHA = _fec
                a.HORA = hora_fat
                a.ID = id
                a.GRASA = grasa
                a.PROTEINA = proteina
                a.LACTOSA = lactosa
                a.SOLTOTALES = soltotales
                a.CELULAS = celulas
                a.CRIOSCOPIA = crioscopia
                a.UREA = urea
                a.EQUIPO = equipo
                a.VMGRASA = vmgrasa
                a.VMPROTEINA = vmproteina
                a.VMLACTOSA = vmlactosa
                a.VMSTOTALES = vmstotales
                a.VMCELULAS = vmcelulas
                a.VMCRIOSCOPIA = vmcrioscopia
                a.VMUREA = vmurea
                a.ARCHIVO = archivo
                a.FILA = fila

                a2.IDENT = ident
                a2.FECHA = _fec
                a2.HORA = hora_fat
                a2.ID = id
                a2.GRASA = grasa
                a2.PROTEINA = proteina
                a2.LACTOSA = lactosa
                a2.SOLTOTALES = soltotales
                a2.CELULAS = celulas
                a2.CRIOSCOPIA = crioscopia
                a2.UREA = urea
                a2.EQUIPO = equipo
                a2.VMGRASA = vmgrasa
                a2.VMPROTEINA = vmproteina
                a2.VMLACTOSA = vmlactosa
                a2.VMSTOTALES = vmstotales
                a2.VMCELULAS = vmcelulas
                a2.VMCRIOSCOPIA = vmcrioscopia
                a2.VMUREA = vmurea
                a2.ARCHIVO = archivo
                a2.FILA = fila
                If pequipo = "B6" Then
                    If linea >= 7 Then
                        a.guardar(Usuario)
                        a2.guardar(Usuario)
                    End If
                Else
                    If linea > 7 Then
                        a.guardar(Usuario)
                        a2.guardar(Usuario)
                    End If
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing
        a = Nothing
        a2 = Nothing
    End Sub
    Private Sub proceso_B6()
        Dim nombrearchivo As String = ""
        nombrearchivo = TextArchivo.Text.Trim
        '********************************************************
        Dim linea As Integer = 1
        Dim linea_ As Integer = 0
        Dim ident As Long = 0
        Dim fecha As String = ""
        Dim hora As String = ""
        Dim id As Integer = 0
        Dim grasa As Double = 0
        Dim proteina As Double = 0
        Dim lactosa As Double = 0
        Dim soltotales As Double = 0
        Dim celulas As Integer = 0
        Dim crioscopia As Integer = 0
        Dim urea As Integer = 0
        Dim equipo As String = ""
        Dim vmgrasa As Double = 0
        Dim vmproteina As Double = 0
        Dim vmlactosa As Double = 0
        Dim vmstotales As Double = 0
        Dim vmcelulas As Integer = 0
        Dim vmcrioscopia As Integer = 0
        Dim vmurea As Integer = 0
        Dim archivo As String = ""
        Dim fila As Integer = 0

        '********************************************************
        Dim objReader As New StreamReader(nombrearchivo)
        Dim sLine As String = ""
        Dim a As New dAnalisisBD
        Dim a2 As New dAnalisisBD2
        Dim lista As New ArrayList
        lista = a.listarxarchivo(archivox)
        If Not lista Is Nothing Then
            For Each a In lista
                linea_ = a.FILA
            Next
        End If

        Dim Texto() As String

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                'Texto = sLine
                Texto = Split(sLine, ";")
                'If linea > linea_ Then
                If linea > 7 Then
                    'id**********************************
                    If Trim(Texto(5)) <> "" Then
                        id = Trim(Texto(5))
                    End If
                    'ident**********************************
                    If Trim(Texto(5)) <> "" Then
                        ident = Trim(Texto(0))
                    End If
                    'Grasa**********************************
                    If Trim(Texto(11)) <> "" Then
                        grasa = Trim(Texto(11))
                    End If
                    'Proteina*******************************
                    If Trim(Texto(12)) <> "" Then
                        proteina = Trim(Texto(12))
                    End If
                    'Lactosa********************************
                    If Trim(Texto(13)) <> "" Then
                        lactosa = Trim(Texto(13))
                    End If
                    'Sólidos totales************************
                    If Trim(Texto(14)) <> "" Then
                        soltotales = Trim(Texto(14))
                    End If
                    'Células********************************
                    If Trim(Texto(9)) <> "" Then
                        celulas = Trim(Texto(9))
                    End If
                    'Crioscopía********************************
                    If Trim(Texto(15)) <> "" Then
                        crioscopia = Trim(Texto(15))
                    End If
                    'Urea********************************
                    If Trim(Texto(16)) <> "" Then
                        urea = Trim(Texto(16))
                    End If
                End If
                'crioscopia = 0
                'urea = 0
                equipo = "B6"
                If ident = 1 Then
                    vmgrasa = TextGrasa1.Text.Trim
                    vmproteina = TextProteina1.Text.Trim
                    vmlactosa = TextLactosa1.Text.Trim
                    vmstotales = TextSTotales1.Text.Trim
                    vmcelulas = TextCelulas1.Text.Trim
                    vmcrioscopia = TextCrioscopia1.Text.Trim
                    vmurea = TextUrea1.Text.Trim
                ElseIf ident = 2 Then
                    vmgrasa = TextGrasa2.Text.Trim
                    vmproteina = TextProteina2.Text.Trim
                    vmlactosa = TextLactosa2.Text.Trim
                    vmstotales = TextSTotales2.Text.Trim
                    vmcelulas = TextCelulas2.Text.Trim
                    vmcrioscopia = TextCrioscopia2.Text.Trim
                    vmurea = TextUrea2.Text.Trim
                End If
                archivo = archivox
                fila = linea
                _fecha = fecha_fat
                _fec = Format(_fecha, "yyyy-MM-dd")
                a.IDENT = ident
                a.FECHA = _fec
                a.HORA = hora_fat
                a.ID = id
                a.GRASA = grasa
                a.PROTEINA = proteina
                a.LACTOSA = lactosa
                a.SOLTOTALES = soltotales
                a.CELULAS = celulas
                a.CRIOSCOPIA = crioscopia
                a.UREA = urea
                a.EQUIPO = equipo
                a.VMGRASA = vmgrasa
                a.VMPROTEINA = vmproteina
                a.VMLACTOSA = vmlactosa
                a.VMSTOTALES = vmstotales
                a.VMCELULAS = vmcelulas
                a.VMCRIOSCOPIA = vmcrioscopia
                a.VMUREA = vmurea
                a.ARCHIVO = archivo
                a.FILA = fila

                a2.IDENT = ident
                a2.FECHA = _fec
                a2.HORA = hora_fat
                a2.ID = id
                a2.GRASA = grasa
                a2.PROTEINA = proteina
                a2.LACTOSA = lactosa
                a2.SOLTOTALES = soltotales
                a2.CELULAS = celulas
                a2.CRIOSCOPIA = crioscopia
                a2.UREA = urea
                a2.EQUIPO = equipo
                a2.VMGRASA = vmgrasa
                a2.VMPROTEINA = vmproteina
                a2.VMLACTOSA = vmlactosa
                a2.VMSTOTALES = vmstotales
                a2.VMCELULAS = vmcelulas
                a2.VMCRIOSCOPIA = vmcrioscopia
                a2.VMUREA = vmurea
                a2.ARCHIVO = archivo
                a2.FILA = fila
                If linea > 7 Then
                    a.guardar(Usuario)
                    a2.guardar(Usuario)
                End If
            End If
            linea = linea + 1
        Loop Until sLine Is Nothing
        a = Nothing
        a2 = Nothing
    End Sub
    Private Sub grabo_resultados()
        Dim a1 As New dAnalisisBD_
        Dim a2 As New dAnalisisBD_
        Dim lista1 As New ArrayList
        Dim lista2 As New ArrayList
        Dim contador1 As Integer = 0
        Dim contador2 As Integer = 0
        lista1 = a1.listar1(archivox)
        lista2 = a2.listar2(archivox)
        If Not lista1 Is Nothing Then
            contador1 = lista1.Count
        End If
        If Not lista2 Is Nothing Then
            contador2 = lista2.Count
        End If

        Dim contador As Integer = 1
        Dim grasauno As Double = 0
        Dim grasados As Double = 0
        Dim gruno As Double = 0
        Dim grdos As Double = 0
        Dim grasa1 As Double = 0
        Dim grasa2 As Double = 0
        Dim grasa3 As Double = 0
        Dim grasa4 As Double = 0
        Dim grasa5 As Double = 0
        Dim gr1 As Double = 0
        Dim gr2 As Double = 0
        Dim gr3 As Double = 0
        Dim gr4 As Double = 0
        Dim gr5 As Double = 0
        Dim grasapromedio As Double = 0
        Dim proteinauno As Double = 0
        Dim proteinados As Double = 0
        Dim pruno As Double = 0
        Dim prdos As Double = 0
        Dim proteina1 As Double = 0
        Dim proteina2 As Double = 0
        Dim proteina3 As Double = 0
        Dim proteina4 As Double = 0
        Dim proteina5 As Double = 0
        Dim pr1 As Double = 0
        Dim pr2 As Double = 0
        Dim pr3 As Double = 0
        Dim pr4 As Double = 0
        Dim pr5 As Double = 0
        Dim proteinapromedio As Double = 0
        Dim launo As Double = 0
        Dim lados As Double = 0
        Dim lactosauno As Double = 0
        Dim lactosados As Double = 0
        Dim lactosa1 As Double = 0
        Dim lactosa2 As Double = 0
        Dim lactosa3 As Double = 0
        Dim lactosa4 As Double = 0
        Dim lactosa5 As Double = 0
        Dim la1 As Double = 0
        Dim la2 As Double = 0
        Dim la3 As Double = 0
        Dim la4 As Double = 0
        Dim la5 As Double = 0
        Dim lactosapromedio As Double = 0
        Dim stotalesuno As Double = 0
        Dim stotalesdos As Double = 0
        Dim stuno As Double = 0
        Dim stdos As Double = 0
        Dim stotales1 As Double = 0
        Dim stotales2 As Double = 0
        Dim stotales3 As Double = 0
        Dim stotales4 As Double = 0
        Dim stotales5 As Double = 0
        Dim st1 As Double = 0
        Dim st2 As Double = 0
        Dim st3 As Double = 0
        Dim st4 As Double = 0
        Dim st5 As Double = 0
        Dim stotalespromedio As Double = 0
        Dim celulasuno As Integer = 0
        Dim celulasdos As Integer = 0
        Dim ceuno As Integer = 0
        Dim cedos As Integer = 0
        Dim celulas1 As Integer = 0
        Dim celulas2 As Integer = 0
        Dim celulas3 As Integer = 0
        Dim celulas4 As Integer = 0
        Dim celulas5 As Integer = 0
        Dim ce1 As Integer = 0
        Dim ce2 As Integer = 0
        Dim ce3 As Integer = 0
        Dim ce4 As Integer = 0
        Dim ce5 As Integer = 0
        Dim celulaspromedio As Integer = 0
        Dim porcentajecelulas As Double = 0
        Dim porcentajecelulas2 As Double = 0
        Dim porcentajecelulas3 As Double = 0
        Dim crioscopiauno As Integer = 0
        Dim crioscopiados As Integer = 0
        Dim cruno As Integer = 0
        Dim crdos As Integer = 0
        Dim crioscopia1 As Integer = 0
        Dim crioscopia2 As Integer = 0
        Dim crioscopia3 As Integer = 0
        Dim crioscopia4 As Integer = 0
        Dim crioscopia5 As Integer = 0
        Dim cr1 As Integer = 0
        Dim cr2 As Integer = 0
        Dim cr3 As Integer = 0
        Dim cr4 As Integer = 0
        Dim cr5 As Integer = 0
        Dim crioscopiapromedio As Integer = 0
        Dim ureauno As Integer = 0
        Dim ureados As Integer = 0
        Dim uruno As Integer = 0
        Dim urdos As Integer = 0
        Dim urea1 As Integer = 0
        Dim urea2 As Integer = 0
        Dim urea3 As Integer = 0
        Dim urea4 As Integer = 0
        Dim urea5 As Integer = 0
        Dim ur1 As Integer = 0
        Dim ur2 As Integer = 0
        Dim ur3 As Integer = 0
        Dim ur4 As Integer = 0
        Dim ur5 As Integer = 0
        Dim ureapromedio As Integer = 0
        Dim valor1 As Double = 0
        Dim valor2 As Double = 0
        Dim valor As Double = 0
        Dim _gr1 As Double = 0
        Dim _gr2 As Double = 0
        Dim _pr1 As Double = 0
        Dim _pr2 As Double = 0
        Dim _la1 As Double = 0
        Dim _la2 As Double = 0
        Dim _st1 As Double = 0
        Dim _st2 As Double = 0
        Dim _ce1 As Double = 0
        Dim _ce2 As Double = 0
        Dim _cr1 As Double = 0
        Dim _cr2 As Double = 0
        Dim _ur1 As Double = 0
        Dim _ur2 As Double = 0
        If contador1 = 1 Then 'SI HAY 1 REGISTROS CON LA IDENTIFICACION 1
            lista1 = a1.listar1(archivox)
            If Not lista1 Is Nothing Then
                For Each a1 In lista1
                    grasa1 = a1.GRASA
                    grasa2 = a1.GRASA
                    proteina1 = a1.PROTEINA
                    proteina2 = a1.PROTEINA
                    lactosa1 = a1.LACTOSA
                    lactosa2 = a1.LACTOSA
                    stotales1 = a1.SOLTOTALES
                    stotales2 = a1.SOLTOTALES
                    celulas1 = a1.CELULAS
                    celulas2 = a1.CELULAS
                    crioscopia1 = a1.CRIOSCOPIA
                    crioscopia2 = a1.CRIOSCOPIA
                    urea1 = a1.UREA
                    urea2 = a1.UREA
                    grasapromedio = a1.VMGRASA
                    proteinapromedio = a1.VMPROTEINA
                    lactosapromedio = a1.VMLACTOSA
                    stotalespromedio = a1.VMSTOTALES
                    celulaspromedio = a1.VMCELULAS
                    crioscopiapromedio = a1.VMCRIOSCOPIA
                    ureapromedio = a1.VMUREA
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                _gr1 = grasa1
                _gr2 = grasa2
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                gruno = (_gr1 + _gr2) / 2
                grasauno = gruno - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                _pr1 = proteina1
                _pr2 = proteina2
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                pruno = (_pr1 + _pr2) / 2
                proteinauno = pruno - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                _la1 = lactosa1
                _la2 = lactosa2
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                launo = (_la1 + _la2) / 2
                lactosauno = launo - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                _st1 = stotales1
                _st2 = stotales2
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                stuno = (_st1 + _st2) / 2
                stotalesuno = stuno - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                _ce1 = celulas1
                _ce2 = celulas2
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                ceuno = (_ce1 + _ce2) / 2
                celulasuno = ceuno - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                _cr1 = crioscopia1
                _cr2 = crioscopia2
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cruno = (_cr1 + _cr2) / 2
                crioscopiauno = cruno - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                _ur1 = urea1
                _ur2 = urea2
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                uruno = (_ur1 + _ur2) / 2
                ureauno = uruno - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r As New dResultadosBD
            _fecha = a1.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r.FECHA = _fec
            r.HORA = a1.HORA
            r.ID = a1.IDENT
            r.EQUIPO = a1.EQUIPO
            r.MGR = grasapromedio
            r.GR1 = _gr1
            r.GR2 = _gr2
            r.GRASA = grasauno
            r.MPR = proteinapromedio
            r.PR1 = _pr1
            r.PR2 = _pr2
            r.PROTEINA = proteinauno
            r.MLA = lactosapromedio
            r.LA1 = _la1
            r.LA2 = _la2
            r.LACTOSA = lactosauno
            r.MST = stotalespromedio
            r.ST1 = _st1
            r.ST2 = _st2
            r.SOLTOTALES = stotalesuno
            r.MCE = celulaspromedio
            r.CE1 = _ce1
            r.CE2 = _ce2
            r.CELULAS = celulasuno
            r.MCR = crioscopiapromedio
            r.CR1 = _cr1
            r.CR2 = _cr2
            r.CRIOSCOPIA = crioscopiauno
            r.MUR = ureapromedio
            r.UR1 = _ur1
            r.UR2 = _ur2
            r.UREA = ureauno
            r.VALIDO = "n"
            r.guardar(Usuario)
        ElseIf contador1 = 2 Then 'SI HAY 2 REGISTROS CON LA IDENTIFICACION 1
            lista1 = a1.listar1(archivox)
            If Not lista1 Is Nothing Then
                For Each a1 In lista1
                    If contador = 1 Then
                        grasa1 = a1.GRASA
                        proteina1 = a1.PROTEINA
                        lactosa1 = a1.LACTOSA
                        stotales1 = a1.SOLTOTALES
                        celulas1 = a1.CELULAS
                        crioscopia1 = a1.CRIOSCOPIA
                        urea1 = a1.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a1.GRASA
                        proteina2 = a1.PROTEINA
                        lactosa2 = a1.LACTOSA
                        stotales2 = a1.SOLTOTALES
                        celulas2 = a1.CELULAS
                        crioscopia2 = a1.CRIOSCOPIA
                        urea2 = a1.UREA
                        grasapromedio = a1.VMGRASA
                        proteinapromedio = a1.VMPROTEINA
                        lactosapromedio = a1.VMLACTOSA
                        stotalespromedio = a1.VMSTOTALES
                        celulaspromedio = a1.VMCELULAS
                        crioscopiapromedio = a1.VMCRIOSCOPIA
                        ureapromedio = a1.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                _gr1 = grasa1
                _gr2 = grasa2
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                gruno = (_gr1 + _gr2) / 2
                grasauno = gruno - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                _pr1 = proteina1
                _pr2 = proteina2
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                pruno = (_pr1 + _pr2) / 2
                proteinauno = pruno - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                _la1 = lactosa1
                _la2 = lactosa2
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                launo = (_la1 + _la2) / 2
                lactosauno = launo - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                _st1 = stotales1
                _st2 = stotales2
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                stuno = (_st1 + _st2) / 2
                stotalesuno = stuno - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                _ce1 = celulas1
                _ce2 = celulas2
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                ceuno = (_ce1 + _ce2) / 2
                celulasuno = ceuno - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                _cr1 = crioscopia1
                _cr2 = crioscopia2
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cruno = (_cr1 + _cr2) / 2
                crioscopiauno = cruno - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                _ur1 = urea1
                _ur2 = urea2
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                uruno = (_ur1 + _ur2) / 2
                ureauno = uruno - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r As New dResultadosBD
            _fecha = a1.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r.FECHA = _fec
            r.HORA = a1.HORA
            r.ID = a1.IDENT
            r.EQUIPO = a1.EQUIPO
            r.MGR = grasapromedio
            r.GR1 = _gr1
            r.GR2 = _gr2
            r.GRASA = grasauno
            r.MPR = proteinapromedio
            r.PR1 = _pr1
            r.PR2 = _pr2
            r.PROTEINA = proteinauno
            r.MLA = lactosapromedio
            r.LA1 = _la1
            r.LA2 = _la2
            r.LACTOSA = lactosauno
            r.MST = stotalespromedio
            r.ST1 = _st1
            r.ST2 = _st2
            r.SOLTOTALES = stotalesuno
            r.MCE = celulaspromedio
            r.CE1 = _ce1
            r.CE2 = _ce2
            r.CELULAS = celulasuno
            r.MCR = crioscopiapromedio
            r.CR1 = _cr1
            r.CR2 = _cr2
            r.CRIOSCOPIA = crioscopiauno
            r.MUR = ureapromedio
            r.UR1 = _ur1
            r.UR2 = _ur2
            r.UREA = ureauno
            r.VALIDO = "n"
            r.guardar(Usuario)

        ElseIf contador1 = 3 Then 'SI HAY 3 REGISTROS CON LA IDENTIFICACION 1
            lista1 = a1.listar1(archivox)
            If Not lista1 Is Nothing Then
                For Each a1 In lista1
                    If contador = 1 Then
                        grasa1 = a1.GRASA
                        proteina1 = a1.PROTEINA
                        lactosa1 = a1.LACTOSA
                        stotales1 = a1.SOLTOTALES
                        celulas1 = a1.CELULAS
                        crioscopia1 = a1.CRIOSCOPIA
                        urea1 = a1.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a1.GRASA
                        proteina2 = a1.PROTEINA
                        lactosa2 = a1.LACTOSA
                        stotales2 = a1.SOLTOTALES
                        celulas2 = a1.CELULAS
                        crioscopia2 = a1.CRIOSCOPIA
                        urea2 = a1.UREA
                    ElseIf contador = 3 Then
                        grasa3 = a1.GRASA
                        proteina3 = a1.PROTEINA
                        lactosa3 = a1.LACTOSA
                        stotales3 = a1.SOLTOTALES
                        celulas3 = a1.CELULAS
                        crioscopia3 = a1.CRIOSCOPIA
                        urea3 = a1.UREA
                        grasapromedio = a1.VMGRASA
                        proteinapromedio = a1.VMPROTEINA
                        lactosapromedio = a1.VMLACTOSA
                        stotalespromedio = a1.VMSTOTALES
                        celulaspromedio = a1.VMCELULAS
                        crioscopiapromedio = a1.VMCRIOSCOPIA
                        ureapromedio = a1.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                gr3 = grasapromedio - grasa3
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                If gr3 < 0 Then
                    gr3 = gr3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If gr1 < gr2 Then
                    valor1 = gr1
                    _gr1 = grasa1
                    If gr2 < gr3 Then
                        valor2 = gr2
                        _gr2 = grasa2
                    Else
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                Else
                    valor1 = gr2
                    _gr1 = grasa2
                    If gr1 < gr3 Then
                        valor2 = gr1
                        _gr2 = grasa1
                    Else
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                End If
                gr1 = valor1
                gr2 = valor2
                gruno = (_gr1 + _gr2) / 2
                grasauno = gruno - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                pr3 = proteinapromedio - proteina3
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                If pr3 < 0 Then
                    pr3 = pr3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If pr1 < pr2 Then
                    valor1 = pr1
                    _pr1 = proteina1
                    If pr2 < pr3 Then
                        valor2 = pr2
                        _pr2 = proteina2
                    Else
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                Else
                    valor1 = pr2
                    _pr1 = proteina2
                    If pr1 < pr3 Then
                        valor2 = pr1
                        _pr2 = proteina1
                    Else
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                End If
                pr1 = valor1
                pr2 = valor2
                pruno = (_pr1 + _pr2) / 2
                proteinauno = pruno - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                la3 = lactosapromedio - lactosa3
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                If la3 < 0 Then
                    la3 = la3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If la1 < la2 Then
                    valor1 = la1
                    _la1 = lactosa1
                    If la2 < la3 Then
                        valor2 = la2
                        _la2 = lactosa2
                    Else
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                Else
                    valor1 = la2
                    _la1 = lactosa2
                    If la1 < la3 Then
                        valor2 = la1
                        _la2 = lactosa1
                    Else
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                End If
                la1 = valor1
                la2 = valor2
                launo = (_la1 + _la2) / 2
                lactosauno = launo - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                st3 = stotalespromedio - stotales3
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                If st3 < 0 Then
                    st3 = st3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If st1 < st2 Then
                    valor1 = st1
                    _st1 = stotales1
                    If st2 < st3 Then
                        valor2 = st2
                        _st2 = stotales2
                    Else
                        valor2 = st3
                        _st2 = stotales3
                    End If
                Else
                    valor1 = st2
                    _st1 = stotales2
                    If st1 < st3 Then
                        valor2 = st1
                        _st2 = stotales1
                    Else
                        valor2 = st3
                        _st2 = stotales3
                    End If
                End If
                st1 = valor1
                st2 = valor2
                stuno = (_st1 + _st2) / 2
                stotalesuno = stuno - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                ce3 = celulaspromedio - celulas3
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                If ce3 < 0 Then
                    ce3 = ce3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ce1 < ce2 Then
                    valor1 = ce1
                    _ce1 = celulas1
                    If ce2 < ce3 Then
                        valor2 = ce2
                        _ce2 = celulas2
                    Else
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                Else
                    valor1 = ce2
                    _ce1 = celulas2
                    If ce1 < ce3 Then
                        valor2 = ce1
                        _ce2 = celulas1
                    Else
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                End If
                ce1 = valor1
                ce2 = valor2
                ceuno = (_ce1 + _ce2) / 2
                celulasuno = ceuno - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                cr3 = crioscopiapromedio - crioscopia3
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If cr3 < 0 Then
                    cr3 = cr3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If cr1 < cr2 Then
                    valor1 = cr1
                    _cr1 = crioscopia1
                    If cr2 < cr3 Then
                        valor2 = cr2
                        _cr2 = crioscopia2
                    Else
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                Else
                    valor1 = cr2
                    _cr1 = crioscopia2
                    If cr1 < cr3 Then
                        valor2 = cr1
                        _cr2 = crioscopia1
                    Else
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cr1 = valor1
                cr2 = valor2
                cruno = (_cr1 + _cr2) / 2
                crioscopiauno = cruno - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                ur3 = ureapromedio - urea3
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If ur3 < 0 Then
                    ur3 = ur3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ur1 < ur2 Then
                    valor1 = ur1
                    _ur1 = urea1
                    If ur2 < ur3 Then
                        valor2 = ur2
                        _ur2 = urea2
                    Else
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                Else
                    valor1 = ur2
                    _ur1 = urea2
                    If ur1 < ur3 Then
                        valor2 = ur1
                        _ur2 = urea1
                    Else
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                ur1 = valor1
                ur2 = valor2
                uruno = (_ur1 + _ur2) / 2
                ureauno = uruno - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r As New dResultadosBD
            _fecha = a1.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r.FECHA = _fec
            r.HORA = a1.HORA
            r.ID = a1.IDENT
            r.EQUIPO = a1.EQUIPO
            r.MGR = grasapromedio
            r.GR1 = _gr1
            r.GR2 = _gr2
            r.GRASA = grasauno
            r.MPR = proteinapromedio
            r.PR1 = _pr1
            r.PR2 = _pr2
            r.PROTEINA = proteinauno
            r.MLA = lactosapromedio
            r.LA1 = _la1
            r.LA2 = _la2
            r.LACTOSA = lactosauno
            r.MST = stotalespromedio
            r.ST1 = _st1
            r.ST2 = _st2
            r.SOLTOTALES = stotalesuno
            r.MCE = celulaspromedio
            r.CE1 = _ce1
            r.CE2 = _ce2
            r.CELULAS = celulasuno
            r.MCR = crioscopiapromedio
            r.CR1 = _cr1
            r.CR2 = _cr2
            r.CRIOSCOPIA = crioscopiauno
            r.MUR = ureapromedio
            r.UR1 = _ur1
            r.UR2 = _ur2
            r.UREA = ureauno
            r.VALIDO = "n"
            r.guardar(Usuario)

        ElseIf contador1 = 4 Then 'SI HAY 4 REGISTROS CON LA IDENTIFICACION 1
            lista1 = a1.listar1(archivox)
            If Not lista1 Is Nothing Then
                For Each a1 In lista1
                    If contador = 1 Then
                        grasa1 = a1.GRASA
                        proteina1 = a1.PROTEINA
                        lactosa1 = a1.LACTOSA
                        stotales1 = a1.SOLTOTALES
                        celulas1 = a1.CELULAS
                        crioscopia1 = a1.CRIOSCOPIA
                        urea1 = a1.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a1.GRASA
                        proteina2 = a1.PROTEINA
                        lactosa2 = a1.LACTOSA
                        stotales2 = a1.SOLTOTALES
                        celulas2 = a1.CELULAS
                        crioscopia2 = a1.CRIOSCOPIA
                        urea2 = a1.UREA
                    ElseIf contador = 3 Then
                        grasa3 = a1.GRASA
                        proteina3 = a1.PROTEINA
                        lactosa3 = a1.LACTOSA
                        stotales3 = a1.SOLTOTALES
                        celulas3 = a1.CELULAS
                        crioscopia3 = a1.CRIOSCOPIA
                        urea3 = a1.UREA
                    ElseIf contador = 4 Then
                        grasa4 = a1.GRASA
                        proteina4 = a1.PROTEINA
                        lactosa4 = a1.LACTOSA
                        stotales4 = a1.SOLTOTALES
                        celulas4 = a1.CELULAS
                        crioscopia4 = a1.CRIOSCOPIA
                        urea4 = a1.UREA
                        grasapromedio = a1.VMGRASA
                        proteinapromedio = a1.VMPROTEINA
                        lactosapromedio = a1.VMLACTOSA
                        stotalespromedio = a1.VMSTOTALES
                        celulaspromedio = a1.VMCELULAS
                        crioscopiapromedio = a1.VMCRIOSCOPIA
                        ureapromedio = a1.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                gr3 = grasapromedio - grasa3
                gr4 = grasapromedio - grasa4
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                If gr3 < 0 Then
                    gr3 = gr3 * -1
                End If
                If gr4 < 0 Then
                    gr4 = gr4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If gr1 < gr2 Then
                    valor1 = gr1
                    valor2 = gr2
                    _gr1 = grasa1
                    _gr2 = grasa2
                Else
                    valor1 = gr2
                    valor2 = gr1
                    _gr1 = grasa2
                    _gr2 = grasa1
                End If
                If valor1 > gr3 Then
                    valor2 = valor1
                    valor1 = gr3
                    _gr2 = _gr1
                    _gr1 = grasa3
                Else
                    If valor2 > gr3 Then
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                End If
                If valor1 > gr4 Then
                    valor2 = valor1
                    valor1 = gr4
                    _gr2 = _gr1
                    _gr1 = grasa4
                Else
                    If valor2 > gr4 Then
                        valor2 = gr4
                        _gr2 = grasa4
                    End If
                End If
                gr1 = valor1
                gr2 = valor2
                gruno = (_gr1 + _gr2) / 2
                grasauno = gruno - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                pr3 = proteinapromedio - proteina3
                pr4 = proteinapromedio - proteina4
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                If pr3 < 0 Then
                    pr3 = pr3 * -1
                End If
                If pr4 < 0 Then
                    pr4 = pr4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If pr1 < pr2 Then
                    valor1 = pr1
                    valor2 = pr2
                    _pr1 = proteina1
                    _pr2 = proteina2
                Else
                    valor1 = pr2
                    valor2 = pr1
                    _pr1 = proteina2
                    _pr2 = proteina1
                End If
                If valor1 > pr3 Then
                    valor2 = valor1
                    valor1 = pr3
                    _pr2 = _pr1
                    _pr1 = proteina3
                Else
                    If valor2 > pr3 Then
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                End If
                If valor1 > pr4 Then
                    valor2 = valor1
                    valor1 = pr4
                    _pr2 = _pr1
                    _pr1 = proteina4
                Else
                    If valor2 > pr4 Then
                        valor2 = pr4
                        _pr2 = proteina4
                    End If
                End If
                pr1 = valor1
                pr2 = valor2
                pruno = (_pr1 + _pr2) / 2
                proteinauno = pruno - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                la3 = lactosapromedio - lactosa3
                la4 = lactosapromedio - lactosa4
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                If la3 < 0 Then
                    la3 = la3 * -1
                End If
                If la4 < 0 Then
                    la4 = la4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If la1 < la2 Then
                    valor1 = la1
                    valor2 = la2
                    _la1 = lactosa1
                    _la2 = lactosa2
                Else
                    valor1 = la2
                    valor2 = la1
                    _la1 = lactosa2
                    _la2 = lactosa1
                End If
                If valor1 > la3 Then
                    valor2 = valor1
                    valor1 = la3
                    _la2 = _la1
                    _la1 = lactosa3
                Else
                    If valor2 > la3 Then
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                End If
                If valor1 > la4 Then
                    valor2 = valor1
                    valor1 = la4
                    _la2 = _la1
                    _la1 = lactosa4
                Else
                    If valor2 > la4 Then
                        valor2 = la4
                        _la2 = lactosa4
                    End If
                End If
                la1 = valor1
                la2 = valor2
                launo = (_la1 + _la2) / 2
                lactosauno = launo - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                st3 = stotalespromedio - stotales3
                st4 = stotalespromedio - stotales4
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                If st3 < 0 Then
                    st3 = st3 * -1
                End If
                If st4 < 0 Then
                    st4 = st4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If st1 < st2 Then
                    valor1 = st1
                    valor2 = st2
                    _st1 = stotales1
                    _st2 = stotales2
                Else
                    valor1 = st2
                    valor2 = st1
                    _st1 = stotales2
                    _st2 = stotales1
                End If
                If valor1 > st3 Then
                    valor2 = valor1
                    valor1 = st3
                    _st2 = _st1
                    _st1 = stotales3
                Else
                    If valor2 > st3 Then
                        valor2 = st3
                        _st2 = stotales3
                    End If
                End If
                If valor1 > st4 Then
                    valor2 = valor1
                    valor1 = st4
                    _st2 = _st1
                    _st1 = stotales4
                Else
                    If valor2 > st4 Then
                        valor2 = st4
                        _st2 = stotales4
                    End If
                End If
                st1 = valor1
                st2 = valor2
                stuno = (_st1 + _st2) / 2
                stotalesuno = stuno - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                ce3 = celulaspromedio - celulas3
                ce4 = celulaspromedio - celulas4
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                If ce3 < 0 Then
                    ce3 = ce3 * -1
                End If
                If ce4 < 0 Then
                    ce4 = ce4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ce1 < ce2 Then
                    valor1 = ce1
                    valor2 = ce2
                    _ce1 = celulas1
                    _ce2 = celulas2
                Else
                    valor1 = ce2
                    valor2 = ce1
                    _ce1 = celulas2
                    _ce2 = celulas1
                End If
                If valor1 > ce3 Then
                    valor2 = valor1
                    valor1 = ce3
                    _ce2 = _ce1
                    _ce1 = celulas3
                Else
                    If valor2 > ce3 Then
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                End If
                If valor1 > ce4 Then
                    valor2 = valor1
                    valor1 = ce4
                    _ce2 = _ce1
                    _ce1 = celulas4
                Else
                    If valor2 > ce4 Then
                        valor2 = ce4
                        _ce2 = celulas4
                    End If
                End If
                ce1 = valor1
                ce2 = valor2
                ceuno = (_ce1 + _ce2) / 2
                celulasuno = ceuno - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                cr3 = crioscopiapromedio - crioscopia3
                cr4 = crioscopiapromedio - crioscopia4
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If cr3 < 0 Then
                    cr3 = cr3 * -1
                End If
                If cr4 < 0 Then
                    cr4 = cr4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If cr1 < cr2 Then
                    valor1 = cr1
                    valor2 = cr2
                    _cr1 = crioscopia1
                    _cr2 = crioscopia2
                Else
                    valor1 = cr2
                    valor2 = cr1
                    _cr1 = crioscopia2
                    _cr2 = crioscopia1
                End If
                If valor1 > cr3 Then
                    valor2 = valor1
                    valor1 = cr3
                    _cr2 = _cr1
                    _cr1 = crioscopia3
                Else
                    If valor2 > cr3 Then
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                End If
                If valor1 > cr4 Then
                    valor2 = valor1
                    valor1 = cr4
                    _cr2 = _cr1
                    _cr1 = crioscopia4
                Else
                    If valor2 > cr4 Then
                        valor2 = cr4
                        _cr2 = crioscopia4
                    End If
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cr1 = valor1
                cr2 = valor2
                cruno = (_cr1 + _cr2) / 2
                crioscopiauno = cruno - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                ur3 = ureapromedio - urea3
                ur4 = ureapromedio - urea4
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If ur3 < 0 Then
                    ur3 = ur3 * -1
                End If
                If ur4 < 0 Then
                    ur4 = ur4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ur1 < ur2 Then
                    valor1 = ur1
                    valor2 = ur2
                    _ur1 = urea1
                    _ur2 = urea2
                Else
                    valor1 = ur2
                    valor2 = ur1
                    _ur1 = urea2
                    _ur2 = urea1
                End If
                If valor1 > ur3 Then
                    valor2 = valor1
                    valor1 = ur3
                    _ur2 = _ur1
                    _ur1 = urea3
                Else
                    If valor2 > ur3 Then
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                End If
                If valor1 > ur4 Then
                    valor2 = valor1
                    valor1 = ur4
                    _ur2 = _ur1
                    _ur1 = urea4
                Else
                    If valor2 > ur4 Then
                        valor2 = ur4
                        _ur2 = urea4
                    End If
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                ur1 = valor1
                ur2 = valor2
                uruno = (_ur1 + _ur2) / 2
                ureauno = uruno - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r As New dResultadosBD
            _fecha = a1.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r.FECHA = _fec
            r.HORA = a1.HORA
            r.ID = a1.IDENT
            r.EQUIPO = a1.EQUIPO
            r.MGR = grasapromedio
            r.GR1 = _gr1
            r.GR2 = _gr2
            r.GRASA = grasauno
            r.MPR = proteinapromedio
            r.PR1 = _pr1
            r.PR2 = _pr2
            r.PROTEINA = proteinauno
            r.MLA = lactosapromedio
            r.LA1 = _la1
            r.LA2 = _la2
            r.LACTOSA = lactosauno
            r.MST = stotalespromedio
            r.ST1 = _st1
            r.ST2 = _st2
            r.SOLTOTALES = stotalesuno
            r.MCE = celulaspromedio
            r.CE1 = _ce1
            r.CE2 = _ce2
            r.CELULAS = celulasuno
            r.MCR = crioscopiapromedio
            r.CR1 = _cr1
            r.CR2 = _cr2
            r.CRIOSCOPIA = crioscopiauno
            r.MUR = ureapromedio
            r.UR1 = _ur1
            r.UR2 = _ur2
            r.UREA = ureauno
            r.VALIDO = "n"
            r.guardar(Usuario)
        ElseIf contador1 = 5 Then 'SI HAY 5 REGISTROS CON LA IDENTIFICACION 1
            lista1 = a1.listar1(archivox)
            If Not lista1 Is Nothing Then
                For Each a1 In lista1
                    If contador = 1 Then
                        grasa1 = a1.GRASA
                        proteina1 = a1.PROTEINA
                        lactosa1 = a1.LACTOSA
                        stotales1 = a1.SOLTOTALES
                        celulas1 = a1.CELULAS
                        crioscopia1 = a1.CRIOSCOPIA
                        urea1 = a1.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a1.GRASA
                        proteina2 = a1.PROTEINA
                        lactosa2 = a1.LACTOSA
                        stotales2 = a1.SOLTOTALES
                        celulas2 = a1.CELULAS
                        crioscopia2 = a1.CRIOSCOPIA
                        urea2 = a1.UREA
                    ElseIf contador = 3 Then
                        grasa3 = a1.GRASA
                        proteina3 = a1.PROTEINA
                        lactosa3 = a1.LACTOSA
                        stotales3 = a1.SOLTOTALES
                        celulas3 = a1.CELULAS
                        crioscopia3 = a1.CRIOSCOPIA
                        urea3 = a1.UREA
                    ElseIf contador = 4 Then
                        grasa4 = a1.GRASA
                        proteina4 = a1.PROTEINA
                        lactosa4 = a1.LACTOSA
                        stotales4 = a1.SOLTOTALES
                        celulas4 = a1.CELULAS
                        crioscopia4 = a1.CRIOSCOPIA
                        urea4 = a1.UREA
                    ElseIf contador = 5 Then
                        grasa5 = a1.GRASA
                        proteina5 = a1.PROTEINA
                        lactosa5 = a1.LACTOSA
                        stotales5 = a1.SOLTOTALES
                        celulas5 = a1.CELULAS
                        crioscopia5 = a1.CRIOSCOPIA
                        urea5 = a1.UREA
                        grasapromedio = a1.VMGRASA
                        proteinapromedio = a1.VMPROTEINA
                        lactosapromedio = a1.VMLACTOSA
                        stotalespromedio = a1.VMSTOTALES
                        celulaspromedio = a1.VMCELULAS
                        crioscopiapromedio = a1.VMCRIOSCOPIA
                        ureapromedio = a1.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                gr3 = grasapromedio - grasa3
                gr4 = grasapromedio - grasa4
                gr5 = grasapromedio - grasa5
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                If gr3 < 0 Then
                    gr3 = gr3 * -1
                End If
                If gr4 < 0 Then
                    gr4 = gr4 * -1
                End If
                If gr5 < 0 Then
                    gr5 = gr5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If gr1 < gr2 Then
                    valor1 = gr1
                    valor2 = gr2
                    _gr1 = grasa1
                    _gr2 = grasa2
                Else
                    valor1 = gr2
                    valor2 = gr1
                    _gr1 = grasa2
                    _gr2 = grasa1
                End If
                If valor1 > gr3 Then
                    valor2 = valor1
                    valor1 = gr3
                    _gr2 = _gr1
                    _gr1 = grasa3
                Else
                    If valor2 > gr3 Then
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                End If
                If valor1 > gr4 Then
                    valor2 = valor1
                    valor1 = gr4
                    _gr2 = _gr1
                    _gr1 = grasa4
                Else
                    If valor2 > gr4 Then
                        valor2 = gr4
                        _gr2 = grasa4
                    End If
                End If
                If valor1 > gr5 Then
                    valor2 = valor1
                    valor1 = gr5
                    _gr2 = _gr1
                    _gr1 = grasa5
                Else
                    If valor2 > gr5 Then
                        valor2 = gr5
                        _gr2 = grasa5
                    End If
                End If
                gr1 = valor1
                gr2 = valor2
                gruno = (_gr1 + _gr2) / 2
                grasauno = gruno - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                pr3 = proteinapromedio - proteina3
                pr4 = proteinapromedio - proteina4
                pr5 = proteinapromedio - proteina5
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                If pr3 < 0 Then
                    pr3 = pr3 * -1
                End If
                If pr4 < 0 Then
                    pr4 = pr4 * -1
                End If
                If pr5 < 0 Then
                    pr5 = pr5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If pr1 < pr2 Then
                    valor1 = pr1
                    valor2 = pr2
                    _pr1 = proteina1
                    _pr2 = proteina2
                Else
                    valor1 = pr2
                    valor2 = pr1
                    _pr1 = proteina2
                    _pr2 = proteina1
                End If
                If valor1 > pr3 Then
                    valor2 = valor1
                    valor1 = pr3
                    _pr2 = _pr1
                    _pr1 = proteina3
                Else
                    If valor2 > pr3 Then
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                End If
                If valor1 > pr4 Then
                    valor2 = valor1
                    valor1 = pr4
                    _pr2 = _pr1
                    _pr1 = proteina4
                Else
                    If valor2 > pr4 Then
                        valor2 = pr4
                        _pr2 = proteina4
                    End If
                End If
                If valor1 > pr5 Then
                    valor2 = valor1
                    valor1 = pr5
                    _pr2 = _pr1
                    _pr1 = proteina5
                Else
                    If valor2 > pr5 Then
                        valor2 = pr5
                        _pr2 = proteina5
                    End If
                End If
                pr1 = valor1
                pr2 = valor2
                pruno = (_pr1 + _pr2) / 2
                proteinauno = pruno - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                la3 = lactosapromedio - lactosa3
                la4 = lactosapromedio - lactosa4
                la5 = lactosapromedio - lactosa5
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                If la3 < 0 Then
                    la3 = la3 * -1
                End If
                If la4 < 0 Then
                    la4 = la4 * -1
                End If
                If la5 < 0 Then
                    la5 = la5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If la1 < la2 Then
                    valor1 = la1
                    valor2 = la2
                    _la1 = lactosa1
                    _la2 = lactosa2
                Else
                    valor1 = la2
                    valor2 = la1
                    _la1 = lactosa2
                    _la2 = lactosa1
                End If
                If valor1 > la3 Then
                    valor2 = valor1
                    valor1 = la3
                    _la2 = _la1
                    _la1 = lactosa3
                Else
                    If valor2 > la3 Then
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                End If
                If valor1 > la4 Then
                    valor2 = valor1
                    valor1 = la4
                    _la2 = _la1
                    _la1 = lactosa4
                Else
                    If valor2 > la4 Then
                        valor2 = la4
                        _la2 = lactosa4
                    End If
                End If
                If valor1 > la5 Then
                    valor2 = valor1
                    valor1 = la5
                    _la2 = _la1
                    _la1 = lactosa5
                Else
                    If valor2 > la5 Then
                        valor2 = la5
                        _la2 = lactosa5
                    End If
                End If
                la1 = valor1
                la2 = valor2
                launo = (_la1 + _la2) / 2
                lactosauno = launo - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                st3 = stotalespromedio - stotales3
                st4 = stotalespromedio - stotales4
                st5 = stotalespromedio - stotales5
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                If st3 < 0 Then
                    st3 = st3 * -1
                End If
                If st4 < 0 Then
                    st4 = st4 * -1
                End If
                If st5 < 0 Then
                    st5 = st5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If st1 < st2 Then
                    valor1 = st1
                    valor2 = st2
                    _st1 = stotales1
                    _st2 = stotales2
                Else
                    valor1 = st2
                    valor2 = st1
                    _st1 = stotales2
                    _st2 = stotales1
                End If
                If valor1 > st3 Then
                    valor2 = valor1
                    valor1 = st3
                    _st2 = _st1
                    _st1 = stotales3
                Else
                    If valor2 > st3 Then
                        valor2 = st3
                        _st2 = stotales3
                    End If
                End If
                If valor1 > st4 Then
                    valor2 = valor1
                    valor1 = st4
                    _st2 = _st1
                    _st1 = stotales4
                Else
                    If valor2 > st4 Then
                        valor2 = st4
                        _st2 = stotales4
                    End If
                End If
                If valor1 > st5 Then
                    valor2 = valor1
                    valor1 = st5
                    _st2 = _st1
                    _st1 = stotales5
                Else
                    If valor2 > st5 Then
                        valor2 = st5
                        _st2 = stotales5
                    End If
                End If
                st1 = valor1
                st2 = valor2
                stuno = (_st1 + _st2) / 2
                stotalesuno = stuno - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                ce3 = celulaspromedio - celulas3
                ce4 = celulaspromedio - celulas4
                ce5 = celulaspromedio - celulas5
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                If ce3 < 0 Then
                    ce3 = ce3 * -1
                End If
                If ce4 < 0 Then
                    ce4 = ce4 * -1
                End If
                If ce5 < 0 Then
                    ce5 = ce5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ce1 < ce2 Then
                    valor1 = ce1
                    valor2 = ce2
                    _ce1 = celulas1
                    _ce2 = celulas2
                Else
                    valor1 = ce2
                    valor2 = ce1
                    _ce1 = celulas2
                    _ce2 = celulas1
                End If
                If valor1 > ce3 Then
                    valor2 = valor1
                    valor1 = ce3
                    _ce2 = _ce1
                    _ce1 = celulas3
                Else
                    If valor2 > ce3 Then
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                End If
                If valor1 > ce4 Then
                    valor2 = valor1
                    valor1 = ce4
                    _ce2 = _ce1
                    _ce1 = celulas4
                Else
                    If valor2 > ce4 Then
                        valor2 = ce4
                        _ce2 = celulas4
                    End If
                End If
                If valor1 > ce5 Then
                    valor2 = valor1
                    valor1 = ce5
                    _ce2 = _ce1
                    _ce1 = celulas5
                Else
                    If valor2 > ce5 Then
                        valor2 = ce5
                        _ce2 = celulas5
                    End If
                End If
                ce1 = valor1
                ce2 = valor2
                ceuno = (_ce1 + _ce2) / 2
                celulasuno = ceuno - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                cr3 = crioscopiapromedio - crioscopia3
                cr4 = crioscopiapromedio - crioscopia4
                cr5 = crioscopiapromedio - crioscopia5
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If cr3 < 0 Then
                    cr3 = cr3 * -1
                End If
                If cr4 < 0 Then
                    cr4 = cr4 * -1
                End If
                If cr5 < 0 Then
                    cr5 = cr5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If cr1 < cr2 Then
                    valor1 = cr1
                    valor2 = cr2
                    _cr1 = crioscopia1
                    _cr2 = crioscopia2
                Else
                    valor1 = cr2
                    valor2 = cr1
                    _cr1 = crioscopia2
                    _cr2 = crioscopia1
                End If
                If valor1 > cr3 Then
                    valor2 = valor1
                    valor1 = cr3
                    _cr2 = _cr1
                    _cr1 = crioscopia3
                Else
                    If valor2 > cr3 Then
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                End If
                If valor1 > cr4 Then
                    valor2 = valor1
                    valor1 = cr4
                    _cr2 = _cr1
                    _cr1 = crioscopia4
                Else
                    If valor2 > cr4 Then
                        valor2 = cr4
                        _cr2 = crioscopia4
                    End If
                End If
                If valor1 > cr5 Then
                    valor2 = valor1
                    valor1 = cr5
                    _cr2 = _cr1
                    _cr1 = crioscopia5
                Else
                    If valor2 > cr5 Then
                        valor2 = cr5
                        _cr2 = crioscopia5
                    End If
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cr1 = valor1
                cr2 = valor2
                cruno = (_cr1 + _cr2) / 2
                crioscopiauno = cruno - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                ur3 = ureapromedio - urea3
                ur4 = ureapromedio - urea4
                ur5 = ureapromedio - urea5
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If ur3 < 0 Then
                    ur3 = ur3 * -1
                End If
                If ur4 < 0 Then
                    ur4 = ur4 * -1
                End If
                If ur5 < 0 Then
                    ur5 = ur5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ur1 < ur2 Then
                    valor1 = ur1
                    valor2 = ur2
                    _ur1 = urea1
                    _ur2 = urea2
                Else
                    valor1 = ur2
                    valor2 = ur1
                    _ur1 = urea2
                    _ur2 = urea1
                End If
                If valor1 > ur3 Then
                    valor2 = valor1
                    valor1 = ur3
                    _ur2 = _ur1
                    _ur1 = urea3
                Else
                    If valor2 > ur3 Then
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                End If
                If valor1 > ur4 Then
                    valor2 = valor1
                    valor1 = ur4
                    _ur2 = _ur1
                    _ur1 = urea4
                Else
                    If valor2 > ur4 Then
                        valor2 = ur4
                        _ur2 = urea4
                    End If
                End If
                If valor1 > ur5 Then
                    valor2 = valor1
                    valor1 = ur5
                    _ur2 = _ur1
                    _ur1 = urea5
                Else
                    If valor2 > ur5 Then
                        valor2 = ur5
                        _ur2 = urea5
                    End If
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                ur1 = valor1
                ur2 = valor2
                uruno = (_ur1 + _ur2) / 2
                ureauno = uruno - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r As New dResultadosBD
            _fecha = a1.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r.FECHA = _fec
            r.HORA = a1.HORA
            r.ID = a1.IDENT
            r.EQUIPO = a1.EQUIPO
            r.MGR = grasapromedio
            r.GR1 = _gr1
            r.GR2 = _gr2
            r.GRASA = grasauno
            r.MPR = proteinapromedio
            r.PR1 = _pr1
            r.PR2 = _pr2
            r.PROTEINA = proteinauno
            r.MLA = lactosapromedio
            r.LA1 = _la1
            r.LA2 = _la2
            r.LACTOSA = lactosauno
            r.MST = stotalespromedio
            r.ST1 = _st1
            r.ST2 = _st2
            r.SOLTOTALES = stotalesuno
            r.MCE = celulaspromedio
            r.CE1 = _ce1
            r.CE2 = _ce2
            r.CELULAS = celulasuno
            r.MCR = crioscopiapromedio
            r.CR1 = _cr1
            r.CR2 = _cr2
            r.CRIOSCOPIA = crioscopiauno
            r.MUR = ureapromedio
            r.UR1 = _ur1
            r.UR2 = _ur2
            r.UREA = ureauno
            r.VALIDO = "n"
            r.guardar(Usuario)
        End If
        contador = 1
        '*************************************************************************************************************************
        '*** IDENTIFICACION 2 ****************************************************************************************************
        If contador2 = 1 Then 'SI HAY 1 REGISTROS CON LA IDENTIFICACION 2
            lista2 = a2.listar2(archivox)
            If Not lista2 Is Nothing Then
                For Each a2 In lista2
                    grasa1 = a2.GRASA
                    grasa2 = a2.GRASA
                    proteina1 = a2.PROTEINA
                    proteina2 = a2.PROTEINA
                    lactosa1 = a2.LACTOSA
                    lactosa2 = a2.LACTOSA
                    stotales1 = a2.SOLTOTALES
                    stotales2 = a2.SOLTOTALES
                    celulas1 = a2.CELULAS
                    celulas2 = a2.CELULAS
                    crioscopia1 = a2.CRIOSCOPIA
                    crioscopia2 = a2.CRIOSCOPIA
                    urea1 = a2.UREA
                    urea2 = a2.UREA
                    grasapromedio = a2.VMGRASA
                    proteinapromedio = a2.VMPROTEINA
                    lactosapromedio = a2.VMLACTOSA
                    stotalespromedio = a2.VMSTOTALES
                    celulaspromedio = a2.VMCELULAS
                    crioscopiapromedio = a2.VMCRIOSCOPIA
                    ureapromedio = a2.VMUREA
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                _gr1 = grasa1
                _gr2 = grasa2
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                grdos = (_gr1 + _gr2) / 2
                grasados = grdos - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                _pr1 = proteina1
                _pr2 = proteina2
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                prdos = (_pr1 + _pr2) / 2
                proteinados = prdos - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                _la1 = lactosa1
                _la2 = lactosa2
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                lados = (_la1 + _la2) / 2
                lactosados = lados - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                _st1 = stotales1
                _st2 = stotales2
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                stdos = (_st1 + _st2) / 2
                stotalesdos = stdos - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                _ce1 = celulas1
                _ce2 = celulas2
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                cedos = (_ce1 + _ce2) / 2
                celulasdos = cedos - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                _cr1 = crioscopia1
                _cr2 = crioscopia2
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                crdos = (_cr1 + _cr2) / 2
                crioscopiados = crdos - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                _ur1 = urea1
                _ur2 = urea2
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                urdos = (_ur1 + _ur2) / 2
                ureados = urdos - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r2 As New dResultadosBD
            _fecha = a2.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r2.FECHA = _fec
            r2.HORA = a2.HORA
            r2.ID = a2.IDENT
            r2.EQUIPO = a2.EQUIPO
            r2.MGR = grasapromedio
            r2.GR1 = _gr1
            r2.GR2 = _gr2
            r2.GRASA = grasados
            r2.MPR = proteinapromedio
            r2.PR1 = _pr1
            r2.PR2 = _pr2
            r2.PROTEINA = proteinados
            r2.MLA = lactosapromedio
            r2.LA1 = _la1
            r2.LA2 = _la2
            r2.LACTOSA = lactosados
            r2.MST = stotalespromedio
            r2.ST1 = _st1
            r2.ST2 = _st2
            r2.SOLTOTALES = stotalesdos
            r2.MCE = celulaspromedio
            r2.CE1 = _ce1
            r2.CE2 = _ce2
            r2.CELULAS = celulasdos
            r2.MCR = crioscopiapromedio
            r2.CR1 = _cr1
            r2.CR2 = _cr2
            r2.CRIOSCOPIA = crioscopiados
            r2.MUR = ureapromedio
            r2.UR1 = _ur1
            r2.UR2 = _ur2
            r2.UREA = ureados
            r2.VALIDO = "n"
            r2.guardar(Usuario)
        ElseIf contador2 = 2 Then 'SI HAY 2 REGISTROS CON LA IDENTIFICACION 1
            lista2 = a2.listar2(archivox)
            If Not lista2 Is Nothing Then
                For Each a2 In lista2
                    If contador = 1 Then
                        grasa1 = a2.GRASA
                        proteina1 = a2.PROTEINA
                        lactosa1 = a2.LACTOSA
                        stotales1 = a2.SOLTOTALES
                        celulas1 = a2.CELULAS
                        crioscopia1 = a2.CRIOSCOPIA
                        urea1 = a2.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a2.GRASA
                        proteina2 = a2.PROTEINA
                        lactosa2 = a2.LACTOSA
                        stotales2 = a2.SOLTOTALES
                        celulas2 = a2.CELULAS
                        crioscopia2 = a2.CRIOSCOPIA
                        urea2 = a2.UREA
                        grasapromedio = a2.VMGRASA
                        proteinapromedio = a2.VMPROTEINA
                        lactosapromedio = a2.VMLACTOSA
                        stotalespromedio = a2.VMSTOTALES
                        celulaspromedio = a2.VMCELULAS
                        crioscopiapromedio = a2.VMCRIOSCOPIA
                        ureapromedio = a2.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                _gr1 = grasa1
                _gr2 = grasa2
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                grdos = (_gr1 + _gr2) / 2
                grasados = grdos - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                _pr1 = proteina1
                _pr2 = proteina2
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                prdos = (_pr1 + _pr2) / 2
                proteinados = prdos - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                _la1 = lactosa1
                _la2 = lactosa2
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                lados = (_la1 + _la2) / 2
                lactosados = lados - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                _st1 = stotales1
                _st2 = stotales2
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                stdos = (_st1 + _st2) / 2
                stotalesdos = stdos - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                _ce1 = celulas1
                _ce2 = celulas2
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                cedos = (_ce1 + _ce2) / 2
                celulasdos = cedos - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                _cr1 = crioscopia1
                _cr2 = crioscopia2
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                crdos = (_cr1 + _cr2) / 2
                crioscopiados = crdos - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                _ur1 = urea1
                _ur2 = urea2
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                urdos = (_ur1 + _ur2) / 2
                ureados = urdos - ureapromedio

            End If
            'GUARDO PRIMER REGISTRO
            Dim r2 As New dResultadosBD
            _fecha = a2.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r2.FECHA = _fec
            r2.HORA = a2.HORA
            r2.ID = a2.IDENT
            r2.EQUIPO = a2.EQUIPO
            r2.MGR = grasapromedio
            r2.GR1 = _gr1
            r2.GR2 = _gr2
            r2.GRASA = grasados
            r2.MPR = proteinapromedio
            r2.PR1 = _pr1
            r2.PR2 = _pr2
            r2.PROTEINA = proteinados
            r2.MLA = lactosapromedio
            r2.LA1 = _la1
            r2.LA2 = _la2
            r2.LACTOSA = lactosados
            r2.MST = stotalespromedio
            r2.ST1 = _st1
            r2.ST2 = _st2
            r2.SOLTOTALES = stotalesdos
            r2.MCE = celulaspromedio
            r2.CE1 = _ce1
            r2.CE2 = _ce2
            r2.CELULAS = celulasdos
            r2.MCR = crioscopiapromedio
            r2.CR1 = _cr1
            r2.CR2 = _cr2
            r2.CRIOSCOPIA = crioscopiados
            r2.MUR = ureapromedio
            r2.UR1 = _ur1
            r2.UR2 = _ur2
            r2.UREA = ureados
            r2.VALIDO = "n"
            r2.guardar(Usuario)

        ElseIf contador2 = 3 Then 'SI HAY 3 REGISTROS CON LA IDENTIFICACION 1
            lista2 = a2.listar2(archivox)
            If Not lista2 Is Nothing Then
                For Each a2 In lista2
                    If contador = 1 Then
                        grasa1 = a2.GRASA
                        proteina1 = a2.PROTEINA
                        lactosa1 = a2.LACTOSA
                        stotales1 = a2.SOLTOTALES
                        celulas1 = a2.CELULAS
                        crioscopia1 = a2.CRIOSCOPIA
                        urea1 = a2.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a2.GRASA
                        proteina2 = a2.PROTEINA
                        lactosa2 = a2.LACTOSA
                        stotales2 = a2.SOLTOTALES
                        celulas2 = a2.CELULAS
                        crioscopia2 = a2.CRIOSCOPIA
                        urea2 = a2.UREA
                    ElseIf contador = 3 Then
                        grasa3 = a2.GRASA
                        proteina3 = a2.PROTEINA
                        lactosa3 = a2.LACTOSA
                        stotales3 = a2.SOLTOTALES
                        celulas3 = a2.CELULAS
                        crioscopia3 = a2.CRIOSCOPIA
                        urea3 = a2.UREA
                        grasapromedio = a2.VMGRASA
                        proteinapromedio = a2.VMPROTEINA
                        lactosapromedio = a2.VMLACTOSA
                        stotalespromedio = a2.VMSTOTALES
                        celulaspromedio = a2.VMCELULAS
                        crioscopiapromedio = a2.VMCRIOSCOPIA
                        ureapromedio = a2.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                gr3 = grasapromedio - grasa3
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                If gr3 < 0 Then
                    gr3 = gr3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If gr1 < gr2 Then
                    valor1 = gr1
                    _gr1 = grasa1
                    If gr2 < gr3 Then
                        valor2 = gr2
                        _gr2 = grasa2
                    Else
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                Else
                    valor1 = gr2
                    _gr1 = grasa2
                    If gr1 < gr3 Then
                        valor2 = gr1
                        _gr2 = grasa1
                    Else
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                End If
                gr1 = valor1
                gr2 = valor2
                grdos = (_gr1 + _gr2) / 2
                grasados = grdos - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                pr3 = proteinapromedio - proteina3
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                If pr3 < 0 Then
                    pr3 = pr3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If pr1 < pr2 Then
                    valor1 = pr1
                    _pr1 = proteina1
                    If pr2 < pr3 Then
                        valor2 = pr2
                        _pr2 = proteina2
                    Else
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                Else
                    valor1 = pr2
                    _pr1 = proteina2
                    If pr1 < pr3 Then
                        valor2 = pr1
                        _pr2 = proteina1
                    Else
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                End If
                pr1 = valor1
                pr2 = valor2
                prdos = (_pr1 + _pr2) / 2
                proteinados = prdos - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                la3 = lactosapromedio - lactosa3
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                If la3 < 0 Then
                    la3 = la3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If la1 < la2 Then
                    valor1 = la1
                    _la1 = lactosa1
                    If la2 < la3 Then
                        valor2 = la2
                        _la2 = lactosa2
                    Else
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                Else
                    valor1 = la2
                    _la1 = lactosa2
                    If la1 < la3 Then
                        valor2 = la1
                        _la2 = lactosa1
                    Else
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                End If
                la1 = valor1
                la2 = valor2
                lados = (_la1 + _la2) / 2
                lactosados = lados - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                st3 = stotalespromedio - stotales3
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                If st3 < 0 Then
                    st3 = st3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If st1 < st2 Then
                    valor1 = st1
                    _st1 = stotales1
                    If st2 < st3 Then
                        valor2 = st2
                        _st2 = stotales2
                    Else
                        valor2 = st3
                        _st2 = stotales3
                    End If
                Else
                    valor1 = st2
                    _st1 = stotales2
                    If st1 < st3 Then
                        valor2 = st1
                        _st2 = stotales1
                    Else
                        valor2 = st3
                        _st2 = stotales3
                    End If
                End If
                st1 = valor1
                st2 = valor2
                stdos = (_st1 + _st2) / 2
                stotalesdos = stdos - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                ce3 = celulaspromedio - celulas3
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                If ce3 < 0 Then
                    ce3 = ce3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ce1 < ce2 Then
                    valor1 = ce1
                    _ce1 = celulas1
                    If ce2 < ce3 Then
                        valor2 = ce2
                        _ce1 = celulas2
                    Else
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                Else
                    valor1 = ce2
                    _ce1 = celulas2
                    If ce1 < ce3 Then
                        valor2 = ce1
                        _ce2 = celulas1
                    Else
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                End If
                ce1 = valor1
                ce2 = valor2
                cedos = (_ce1 + _ce2) / 2
                celulasdos = cedos - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                cr3 = crioscopiapromedio - crioscopia3
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If cr3 < 0 Then
                    cr3 = cr3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If cr1 < cr2 Then
                    valor1 = cr1
                    _cr1 = crioscopia1
                    If cr2 < cr3 Then
                        valor2 = cr2
                        _cr2 = crioscopia2
                    Else
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                Else
                    valor1 = cr2
                    _cr1 = crioscopia2
                    If cr1 < cr3 Then
                        valor2 = cr1
                        _cr2 = crioscopia1
                    Else
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cr1 = valor1
                cr2 = valor2
                crdos = (_cr1 + _cr2) / 2
                crioscopiados = crdos - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                ur3 = ureapromedio - urea3
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If ur3 < 0 Then
                    ur3 = ur3 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ur1 < ur2 Then
                    valor1 = ur1
                    _ur1 = urea1
                    If ur2 < ur3 Then
                        valor2 = ur2
                        _ur2 = urea2
                    Else
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                Else
                    valor1 = ur2
                    _ur1 = urea2
                    If ur1 < ur3 Then
                        valor2 = ur1
                        _ur2 = urea1
                    Else
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                ur1 = valor1
                ur2 = valor2
                urdos = (_ur1 + _ur2) / 2
                ureados = urdos - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r2 As New dResultadosBD
            _fecha = a2.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r2.FECHA = _fec
            r2.HORA = a2.HORA
            r2.ID = a2.IDENT
            r2.EQUIPO = a2.EQUIPO
            r2.MGR = grasapromedio
            r2.GR1 = _gr1
            r2.GR2 = _gr2
            r2.GRASA = grasados
            r2.MPR = proteinapromedio
            r2.PR1 = _pr1
            r2.PR2 = _pr2
            r2.PROTEINA = proteinados
            r2.MLA = lactosapromedio
            r2.LA1 = _la1
            r2.LA2 = _la2
            r2.LACTOSA = lactosados
            r2.MST = stotalespromedio
            r2.ST1 = _st1
            r2.ST2 = _st2
            r2.SOLTOTALES = stotalesdos
            r2.MCE = celulaspromedio
            r2.CE1 = _ce1
            r2.CE2 = _ce2
            r2.CELULAS = celulasdos
            r2.MCR = crioscopiapromedio
            r2.CR1 = _cr1
            r2.CR2 = _cr2
            r2.CRIOSCOPIA = crioscopiados
            r2.MUR = ureapromedio
            r2.UR1 = _ur1
            r2.UR2 = _ur2
            r2.UREA = ureados
            r2.VALIDO = "n"
            r2.guardar(Usuario)

        ElseIf contador2 = 4 Then 'SI HAY 4 REGISTROS CON LA IDENTIFICACION 1
            lista2 = a2.listar2(archivox)
            If Not lista2 Is Nothing Then
                For Each a2 In lista2
                    If contador = 1 Then
                        grasa1 = a2.GRASA
                        proteina1 = a2.PROTEINA
                        lactosa1 = a2.LACTOSA
                        stotales1 = a2.SOLTOTALES
                        celulas1 = a2.CELULAS
                        crioscopia1 = a2.CRIOSCOPIA
                        urea1 = a2.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a2.GRASA
                        proteina2 = a2.PROTEINA
                        lactosa2 = a2.LACTOSA
                        stotales2 = a2.SOLTOTALES
                        celulas2 = a2.CELULAS
                        crioscopia2 = a2.CRIOSCOPIA
                        urea2 = a2.UREA
                    ElseIf contador = 3 Then
                        grasa3 = a2.GRASA
                        proteina3 = a2.PROTEINA
                        lactosa3 = a2.LACTOSA
                        stotales3 = a2.SOLTOTALES
                        celulas3 = a2.CELULAS
                        crioscopia3 = a2.CRIOSCOPIA
                        urea3 = a2.UREA
                    ElseIf contador = 4 Then
                        grasa4 = a2.GRASA
                        proteina4 = a2.PROTEINA
                        lactosa4 = a2.LACTOSA
                        stotales4 = a2.SOLTOTALES
                        celulas4 = a2.CELULAS
                        crioscopia4 = a2.CRIOSCOPIA
                        urea4 = a2.UREA
                        grasapromedio = a2.VMGRASA
                        proteinapromedio = a2.VMPROTEINA
                        lactosapromedio = a2.VMLACTOSA
                        stotalespromedio = a1.VMSTOTALES
                        celulaspromedio = a2.VMCELULAS
                        crioscopiapromedio = a2.VMCRIOSCOPIA
                        ureapromedio = a2.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                gr3 = grasapromedio - grasa3
                gr4 = grasapromedio - grasa4
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                If gr3 < 0 Then
                    gr3 = gr3 * -1
                End If
                If gr4 < 0 Then
                    gr4 = gr4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If gr1 < gr2 Then
                    valor1 = gr1
                    valor2 = gr2
                    _gr1 = grasa1
                    _gr2 = grasa2
                Else
                    valor1 = gr2
                    valor2 = gr1
                    _gr1 = grasa2
                    _gr2 = grasa1
                End If
                If valor1 > gr3 Then
                    valor2 = valor1
                    valor1 = gr3
                    _gr2 = _gr1
                    _gr1 = grasa3
                Else
                    If valor2 > gr3 Then
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                End If
                If valor1 > gr4 Then
                    valor2 = valor1
                    valor1 = gr4
                    _gr2 = _gr1
                    _gr1 = grasa4
                Else
                    If valor2 > gr4 Then
                        valor2 = gr4
                        _gr2 = grasa4
                    End If
                End If
                gr1 = valor1
                gr2 = valor2
                grdos = (_gr1 + _gr2) / 2
                grasados = grdos - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                pr3 = proteinapromedio - proteina3
                pr4 = proteinapromedio - proteina4
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                If pr3 < 0 Then
                    pr3 = pr3 * -1
                End If
                If pr4 < 0 Then
                    pr4 = pr4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If pr1 < pr2 Then
                    valor1 = pr1
                    valor2 = pr2
                    _pr1 = proteina1
                    _pr2 = proteina2
                Else
                    valor1 = pr2
                    valor2 = pr1
                    _pr1 = proteina2
                    _pr2 = proteina1
                End If
                If valor1 > pr3 Then
                    valor2 = valor1
                    valor1 = pr3
                    _pr2 = _pr1
                    _pr1 = proteina3
                Else
                    If valor2 > pr3 Then
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                End If
                If valor1 > pr4 Then
                    valor2 = valor1
                    valor1 = pr4
                    _pr2 = _pr1
                    _pr1 = proteina4
                Else
                    If valor2 > pr4 Then
                        valor2 = pr4
                        _pr2 = proteina4
                    End If
                End If
                pr1 = valor1
                pr2 = valor2
                prdos = (_pr1 + _pr2) / 2
                proteinados = prdos - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                la3 = lactosapromedio - lactosa3
                la4 = lactosapromedio - lactosa4
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                If la3 < 0 Then
                    la3 = la3 * -1
                End If
                If la4 < 0 Then
                    la4 = la4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If la1 < la2 Then
                    valor1 = la1
                    valor2 = la2
                    _la1 = lactosa1
                    _la2 = lactosa2
                Else
                    valor1 = la2
                    valor2 = la1
                    _la1 = lactosa2
                    _la2 = lactosa1
                End If
                If valor1 > la3 Then
                    valor2 = valor1
                    valor1 = la3
                    _la2 = _la1
                    _la1 = lactosa3
                Else
                    If valor2 > la3 Then
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                End If
                If valor1 > la4 Then
                    valor2 = valor1
                    valor1 = la4
                    _la2 = _la1
                    _la1 = lactosa4
                Else
                    If valor2 > la4 Then
                        valor2 = la4
                        _la2 = lactosa4
                    End If
                End If
                la1 = valor1
                la2 = valor2
                lados = (_la1 + _la2) / 2
                lactosados = lados - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                st3 = stotalespromedio - stotales3
                st4 = stotalespromedio - stotales4
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                If st3 < 0 Then
                    st3 = st3 * -1
                End If
                If st4 < 0 Then
                    st4 = st4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If st1 < st2 Then
                    valor1 = st1
                    valor2 = st2
                    _st1 = stotales1
                    _st2 = stotales2
                Else
                    valor1 = st2
                    valor2 = st1
                    _st1 = stotales2
                    _st2 = stotales1
                End If
                If valor1 > st3 Then
                    valor2 = valor1
                    valor1 = st3
                    _st2 = _st1
                    _st1 = stotales3
                Else
                    If valor2 > st3 Then
                        valor2 = st3
                        _st2 = stotales3
                    End If
                End If
                If valor1 > st4 Then
                    valor2 = valor1
                    valor1 = st4
                    _st2 = _st1
                    _st1 = stotales4
                Else
                    If valor2 > st4 Then
                        valor2 = st4
                        _st2 = stotales4
                    End If
                End If
                st1 = valor1
                st2 = valor2
                stdos = (_st1 + _st2) / 2
                stotalesdos = stdos - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                ce3 = celulaspromedio - celulas3
                ce4 = celulaspromedio - celulas4
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                If ce3 < 0 Then
                    ce3 = ce3 * -1
                End If
                If ce4 < 0 Then
                    ce4 = ce4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ce1 < ce2 Then
                    valor1 = ce1
                    valor2 = ce2
                    _ce1 = celulas1
                    _ce2 = celulas2
                Else
                    valor1 = ce2
                    valor2 = ce1
                    _ce1 = celulas2
                    _ce2 = celulas1
                End If
                If valor1 > ce3 Then
                    valor2 = valor1
                    valor1 = ce3
                    _ce2 = _ce1
                    _ce1 = celulas3
                Else
                    If valor2 > ce3 Then
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                End If
                If valor1 > ce4 Then
                    valor2 = valor1
                    valor1 = ce4
                    _ce2 = _ce1
                    _ce1 = celulas4
                Else
                    If valor2 > ce4 Then
                        valor2 = ce4
                        _ce2 = celulas4
                    End If
                End If
                ce1 = valor1
                ce2 = valor2
                cedos = (_ce1 + _ce2) / 2
                celulasdos = cedos - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                cr3 = crioscopiapromedio - crioscopia3
                cr4 = crioscopiapromedio - crioscopia4
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If cr3 < 0 Then
                    cr3 = cr3 * -1
                End If
                If cr4 < 0 Then
                    cr4 = cr4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If cr1 < cr2 Then
                    valor1 = cr1
                    valor2 = cr2
                    _cr1 = crioscopia1
                    _cr2 = crioscopia2
                Else
                    valor1 = cr2
                    valor2 = cr1
                    _cr1 = crioscopia2
                    _cr2 = crioscopia1
                End If
                If valor1 > cr3 Then
                    valor2 = valor1
                    valor1 = cr3
                    _cr2 = _cr1
                    _cr1 = crioscopia3
                Else
                    If valor2 > cr3 Then
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                End If
                If valor1 > cr4 Then
                    valor2 = valor1
                    valor1 = cr4
                    _cr2 = _cr1
                    _cr1 = crioscopia4
                Else
                    If valor2 > cr4 Then
                        valor2 = cr4
                        _cr2 = crioscopia4
                    End If
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cr1 = valor1
                cr2 = valor2
                crdos = (_cr1 + _cr2) / 2
                crioscopiados = crdos - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                ur3 = ureapromedio - urea3
                ur4 = ureapromedio - urea4
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If ur3 < 0 Then
                    ur3 = ur3 * -1
                End If
                If ur4 < 0 Then
                    ur4 = ur4 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ur1 < ur2 Then
                    valor1 = ur1
                    valor2 = ur2
                    _ur1 = urea1
                    _ur2 = urea2
                Else
                    valor1 = ur2
                    valor2 = ur1
                    _ur1 = urea2
                    _ur2 = urea1
                End If
                If valor1 > ur3 Then
                    valor2 = valor1
                    valor1 = ur3
                    _ur2 = _ur1
                    _ur1 = urea3
                Else
                    If valor2 > ur3 Then
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                End If
                If valor1 > ur4 Then
                    valor2 = valor1
                    valor1 = ur4
                    _ur2 = _ur1
                    _ur1 = urea4
                Else
                    If valor2 > ur4 Then
                        valor2 = ur4
                        _ur2 = urea4
                    End If
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                ur1 = valor1
                ur2 = valor2
                urdos = (_ur1 + _ur2) / 2
                ureados = urdos - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r2 As New dResultadosBD
            _fecha = a2.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r2.FECHA = _fec
            r2.HORA = a2.HORA
            r2.ID = a2.IDENT
            r2.EQUIPO = a2.EQUIPO
            r2.MGR = grasapromedio
            r2.GR1 = _gr1
            r2.GR2 = _gr2
            r2.GRASA = grasados
            r2.MPR = proteinapromedio
            r2.PR1 = _pr1
            r2.PR2 = _pr2
            r2.PROTEINA = proteinados
            r2.MLA = lactosapromedio
            r2.LA1 = _la1
            r2.LA2 = _la2
            r2.LACTOSA = lactosados
            r2.MST = stotalespromedio
            r2.ST1 = _st1
            r2.ST2 = _st2
            r2.SOLTOTALES = stotalesdos
            r2.MCE = celulaspromedio
            r2.CE1 = _ce1
            r2.CE2 = _ce2
            r2.CELULAS = celulasdos
            r2.MCR = crioscopiapromedio
            r2.CR1 = _cr1
            r2.CR2 = _cr2
            r2.CRIOSCOPIA = crioscopiados
            r2.MUR = ureapromedio
            r2.UR1 = _ur1
            r2.UR2 = _ur2
            r2.UREA = ureados
            r2.VALIDO = "n"
            r2.guardar(Usuario)
        ElseIf contador2 = 5 Then 'SI HAY 5 REGISTROS CON LA IDENTIFICACION 1
            lista1 = a2.listar2(archivox)
            If Not lista2 Is Nothing Then
                For Each a2 In lista2
                    If contador = 1 Then
                        grasa1 = a2.GRASA
                        proteina1 = a2.PROTEINA
                        lactosa1 = a2.LACTOSA
                        stotales1 = a2.SOLTOTALES
                        celulas1 = a2.CELULAS
                        crioscopia1 = a2.CRIOSCOPIA
                        urea1 = a2.UREA
                    ElseIf contador = 2 Then
                        grasa2 = a2.GRASA
                        proteina2 = a2.PROTEINA
                        lactosa2 = a2.LACTOSA
                        stotales2 = a2.SOLTOTALES
                        celulas2 = a2.CELULAS
                        crioscopia2 = a2.CRIOSCOPIA
                        urea2 = a2.UREA
                    ElseIf contador = 3 Then
                        grasa3 = a2.GRASA
                        proteina3 = a2.PROTEINA
                        lactosa3 = a2.LACTOSA
                        stotales3 = a2.SOLTOTALES
                        celulas3 = a2.CELULAS
                        crioscopia3 = a2.CRIOSCOPIA
                        urea3 = a2.UREA
                    ElseIf contador = 4 Then
                        grasa4 = a2.GRASA
                        proteina4 = a2.PROTEINA
                        lactosa4 = a2.LACTOSA
                        stotales4 = a2.SOLTOTALES
                        celulas4 = a2.CELULAS
                        crioscopia4 = a2.CRIOSCOPIA
                        urea4 = a2.UREA
                    ElseIf contador = 5 Then
                        grasa5 = a2.GRASA
                        proteina5 = a2.PROTEINA
                        lactosa5 = a2.LACTOSA
                        stotales5 = a2.SOLTOTALES
                        celulas5 = a2.CELULAS
                        crioscopia5 = a2.CRIOSCOPIA
                        urea5 = a2.UREA
                        grasapromedio = a2.VMGRASA
                        proteinapromedio = a2.VMPROTEINA
                        lactosapromedio = a2.VMLACTOSA
                        stotalespromedio = a2.VMSTOTALES
                        celulaspromedio = a2.VMCELULAS
                        crioscopiapromedio = a2.VMCRIOSCOPIA
                        ureapromedio = a2.VMUREA
                    End If
                    contador = contador + 1
                Next
                'GRASA
                gr1 = grasapromedio - grasa1
                gr2 = grasapromedio - grasa2
                gr3 = grasapromedio - grasa3
                gr4 = grasapromedio - grasa4
                gr5 = grasapromedio - grasa5
                If gr1 < 0 Then
                    gr1 = gr1 * -1
                End If
                If gr2 < 0 Then
                    gr2 = gr2 * -1
                End If
                If gr3 < 0 Then
                    gr3 = gr3 * -1
                End If
                If gr4 < 0 Then
                    gr4 = gr4 * -1
                End If
                If gr5 < 0 Then
                    gr5 = gr5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If gr1 < gr2 Then
                    valor1 = gr1
                    valor2 = gr2
                    _gr1 = grasa1
                    _gr2 = grasa2
                Else
                    valor1 = gr2
                    valor2 = gr1
                    _gr1 = grasa2
                    _gr2 = grasa1
                End If
                If valor1 > gr3 Then
                    valor2 = valor1
                    valor1 = gr3
                    _gr2 = _gr1
                    _gr1 = grasa3
                Else
                    If valor2 > gr3 Then
                        valor2 = gr3
                        _gr2 = grasa3
                    End If
                End If
                If valor1 > gr4 Then
                    valor2 = valor1
                    valor1 = gr4
                    _gr2 = _gr1
                    _gr1 = grasa4
                Else
                    If valor2 > gr4 Then
                        valor2 = gr4
                        _gr2 = grasa4
                    End If
                End If
                If valor1 > gr5 Then
                    valor2 = valor1
                    valor1 = gr5
                    _gr2 = _gr1
                    _gr1 = grasa5
                Else
                    If valor2 > gr5 Then
                        valor2 = gr5
                        _gr2 = grasa5
                    End If
                End If
                gr1 = valor1
                gr2 = valor2
                grdos = (_gr1 + _gr2) / 2
                grasados = grdos - grasapromedio
                'PROTEINA
                pr1 = proteinapromedio - proteina1
                pr2 = proteinapromedio - proteina2
                pr3 = proteinapromedio - proteina3
                pr4 = proteinapromedio - proteina4
                pr5 = proteinapromedio - proteina5
                If pr1 < 0 Then
                    pr1 = pr1 * -1
                End If
                If pr2 < 0 Then
                    pr2 = pr2 * -1
                End If
                If pr3 < 0 Then
                    pr3 = pr3 * -1
                End If
                If pr4 < 0 Then
                    pr4 = pr4 * -1
                End If
                If pr5 < 0 Then
                    pr5 = pr5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If pr1 < pr2 Then
                    valor1 = pr1
                    valor2 = pr2
                    _pr1 = proteina1
                    _pr2 = proteina2
                Else
                    valor1 = pr2
                    valor2 = pr1
                    _pr1 = proteina2
                    _pr2 = proteina1
                End If
                If valor1 > pr3 Then
                    valor2 = valor1
                    valor1 = pr3
                    _pr2 = _pr1
                    _pr1 = proteina3
                Else
                    If valor2 > pr3 Then
                        valor2 = pr3
                        _pr2 = proteina3
                    End If
                End If
                If valor1 > pr4 Then
                    valor2 = valor1
                    valor1 = pr4
                    _pr2 = _pr1
                    _pr1 = proteina4
                Else
                    If valor2 > pr4 Then
                        valor2 = pr4
                        _pr2 = proteina4
                    End If
                End If
                If valor1 > pr5 Then
                    valor2 = valor1
                    valor1 = pr5
                    _pr2 = _pr1
                    _pr1 = proteina5
                Else
                    If valor2 > pr5 Then
                        valor2 = pr5
                        _pr2 = proteina5
                    End If
                End If
                pr1 = valor1
                pr2 = valor2
                prdos = (_pr1 + _pr2) / 2
                proteinados = prdos - proteinapromedio
                'LACTOSA
                la1 = lactosapromedio - lactosa1
                la2 = lactosapromedio - lactosa2
                la3 = lactosapromedio - lactosa3
                la4 = lactosapromedio - lactosa4
                la5 = lactosapromedio - lactosa5
                If la1 < 0 Then
                    la1 = la1 * -1
                End If
                If la2 < 0 Then
                    la2 = la2 * -1
                End If
                If la3 < 0 Then
                    la3 = la3 * -1
                End If
                If la4 < 0 Then
                    la4 = la4 * -1
                End If
                If la5 < 0 Then
                    la5 = la5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If la1 < la2 Then
                    valor1 = la1
                    valor2 = la2
                    _la1 = lactosa1
                    _la2 = lactosa2
                Else
                    valor1 = la2
                    valor2 = la1
                    _la1 = lactosa2
                    _la2 = lactosa1
                End If
                If valor1 > la3 Then
                    valor2 = valor1
                    valor1 = la3
                    _la2 = _la1
                    _la1 = lactosa3
                Else
                    If valor2 > la3 Then
                        valor2 = la3
                        _la2 = lactosa3
                    End If
                End If
                If valor1 > la4 Then
                    valor2 = valor1
                    valor1 = la4
                    _la2 = _la1
                    _la1 = lactosa4
                Else
                    If valor2 > la4 Then
                        valor2 = la4
                        _la2 = lactosa4
                    End If
                End If
                If valor1 > la5 Then
                    valor2 = valor1
                    valor1 = la5
                    _la2 = _la1
                    _la1 = lactosa5
                Else
                    If valor2 > la5 Then
                        valor2 = la5
                        _la2 = lactosa5
                    End If
                End If
                la1 = valor1
                la2 = valor2
                lados = (_la1 + _la2) / 2
                lactosados = lados - lactosapromedio
                'SOLIDOS TOTALES
                st1 = stotalespromedio - stotales1
                st2 = stotalespromedio - stotales2
                st3 = stotalespromedio - stotales3
                st4 = stotalespromedio - stotales4
                st5 = stotalespromedio - stotales5
                If st1 < 0 Then
                    st1 = st1 * -1
                End If
                If st2 < 0 Then
                    st2 = st2 * -1
                End If
                If st3 < 0 Then
                    st3 = st3 * -1
                End If
                If st4 < 0 Then
                    st4 = st4 * -1
                End If
                If st5 < 0 Then
                    st5 = st5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If st1 < st2 Then
                    valor1 = st1
                    valor2 = st2
                    _st1 = stotales1
                    _st2 = stotales2
                Else
                    valor1 = st2
                    valor2 = st1
                    _st1 = stotales2
                    _st2 = stotales1
                End If
                If valor1 > st3 Then
                    valor2 = valor1
                    valor1 = st3
                    _st2 = _st1
                    _st1 = stotales3
                Else
                    If valor2 > st3 Then
                        valor2 = st3
                        _st2 = stotales3
                    End If
                End If
                If valor1 > st4 Then
                    valor2 = valor1
                    valor1 = st4
                    _st2 = _st1
                    _st1 = stotales4
                Else
                    If valor2 > st4 Then
                        valor2 = st4
                        _st2 = stotales4
                    End If
                End If
                If valor1 > st5 Then
                    valor2 = valor1
                    valor1 = st5
                    _st2 = _st1
                    _st1 = stotales5
                Else
                    If valor2 > st5 Then
                        valor2 = st5
                        _st2 = stotales5
                    End If
                End If
                st1 = valor1
                st2 = valor2
                stdos = (_st1 + _st2) / 2
                stotalesdos = stdos - stotalespromedio
                'CELULAS
                ce1 = celulaspromedio - celulas1
                ce2 = celulaspromedio - celulas2
                ce3 = celulaspromedio - celulas3
                ce4 = celulaspromedio - celulas4
                ce5 = celulaspromedio - celulas5
                If ce1 < 0 Then
                    ce1 = ce1 * -1
                End If
                If ce2 < 0 Then
                    ce2 = ce2 * -1
                End If
                If ce3 < 0 Then
                    ce3 = ce3 * -1
                End If
                If ce4 < 0 Then
                    ce4 = ce4 * -1
                End If
                If ce5 < 0 Then
                    ce5 = ce5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ce1 < ce2 Then
                    valor1 = ce1
                    valor2 = ce2
                    _ce1 = celulas1
                    _ce2 = celulas2
                Else
                    valor1 = ce2
                    valor2 = ce1
                    _ce1 = celulas2
                    _ce2 = celulas1
                End If
                If valor1 > ce3 Then
                    valor2 = valor1
                    valor1 = ce3
                    _ce2 = _ce1
                    _ce1 = celulas3
                Else
                    If valor2 > ce3 Then
                        valor2 = ce3
                        _ce2 = celulas3
                    End If
                End If
                If valor1 > ce4 Then
                    valor2 = valor1
                    valor1 = ce4
                    _ce2 = _ce1
                    _ce1 = celulas4
                Else
                    If valor2 > ce4 Then
                        valor2 = ce4
                        _ce2 = celulas4
                    End If
                End If
                If valor1 > ce5 Then
                    valor2 = valor1
                    valor1 = ce5
                    _ce2 = _ce1
                    _ce1 = celulas5
                Else
                    If valor2 > ce5 Then
                        valor2 = ce5
                        _ce2 = celulas5
                    End If
                End If
                ce1 = valor1
                ce2 = valor2
                cedos = (_ce1 + _ce2) / 2
                celulasdos = cedos - celulaspromedio
                'CRIOSCOPIA
                cr1 = crioscopiapromedio - crioscopia1
                cr2 = crioscopiapromedio - crioscopia2
                cr3 = crioscopiapromedio - crioscopia3
                cr4 = crioscopiapromedio - crioscopia4
                cr5 = crioscopiapromedio - crioscopia5
                If cr1 < 0 Then
                    cr1 = cr1 * -1
                End If
                If cr2 < 0 Then
                    cr2 = cr2 * -1
                End If
                If cr3 < 0 Then
                    cr3 = cr3 * -1
                End If
                If cr4 < 0 Then
                    cr4 = cr4 * -1
                End If
                If cr5 < 0 Then
                    cr5 = cr5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If cr1 < cr2 Then
                    valor1 = cr1
                    valor2 = cr2
                    _cr1 = crioscopia1
                    _cr2 = crioscopia2
                Else
                    valor1 = cr2
                    valor2 = cr1
                    _cr1 = crioscopia2
                    _cr2 = crioscopia1
                End If
                If valor1 > cr3 Then
                    valor2 = valor1
                    valor1 = cr3
                    _cr2 = _cr1
                    _cr1 = crioscopia3
                Else
                    If valor2 > cr3 Then
                        valor2 = cr3
                        _cr2 = crioscopia3
                    End If
                End If
                If valor1 > cr4 Then
                    valor2 = valor1
                    valor1 = cr4
                    _cr2 = _cr1
                    _cr1 = crioscopia4
                Else
                    If valor2 > cr4 Then
                        valor2 = cr4
                        _cr2 = crioscopia4
                    End If
                End If
                If valor1 > cr5 Then
                    valor2 = valor1
                    valor1 = cr5
                    _cr2 = _cr1
                    _cr1 = crioscopia5
                Else
                    If valor2 > cr5 Then
                        valor2 = cr5
                        _cr2 = crioscopia5
                    End If
                End If
                If _cr1 = 0 Then
                    _cr1 = -1
                    _cr2 = -1
                    crioscopiapromedio = -2
                End If
                cr1 = valor1
                cr2 = valor2
                crdos = (_cr1 + _cr2) / 2
                crioscopiados = crdos - crioscopiapromedio
                'UREA
                ur1 = ureapromedio - urea1
                ur2 = ureapromedio - urea2
                ur3 = ureapromedio - urea3
                ur4 = ureapromedio - urea4
                ur5 = ureapromedio - urea5
                If ur1 < 0 Then
                    ur1 = ur1 * -1
                End If
                If ur2 < 0 Then
                    ur2 = ur2 * -1
                End If
                If ur3 < 0 Then
                    ur3 = ur3 * -1
                End If
                If ur4 < 0 Then
                    ur4 = ur4 * -1
                End If
                If ur5 < 0 Then
                    ur5 = ur5 * -1
                End If
                'OBTENGO LOS 2 VALORES MAS CERCANOS A LA MEDIA
                If ur1 < ur2 Then
                    valor1 = ur1
                    valor2 = ur2
                    _ur1 = urea1
                    _ur2 = urea2
                Else
                    valor1 = ur2
                    valor2 = ur1
                    _ur1 = urea2
                    _ur2 = urea1
                End If
                If valor1 > ur3 Then
                    valor2 = valor1
                    valor1 = ur3
                    _ur2 = _ur1
                    _ur1 = urea3
                Else
                    If valor2 > ur3 Then
                        valor2 = ur3
                        _ur2 = urea3
                    End If
                End If
                If valor1 > ur4 Then
                    valor2 = valor1
                    valor1 = ur4
                    _ur2 = _ur1
                    _ur1 = urea4
                Else
                    If valor2 > ur4 Then
                        valor2 = ur4
                        _ur2 = urea4
                    End If
                End If
                If valor1 > ur5 Then
                    valor2 = valor1
                    valor1 = ur5
                    _ur2 = _ur1
                    _ur1 = urea5
                Else
                    If valor2 > ur5 Then
                        valor2 = ur5
                        _ur2 = urea5
                    End If
                End If
                If _ur1 = 0 Then
                    _ur1 = -1
                    _ur2 = -1
                    ureapromedio = -2
                End If
                ur1 = valor1
                ur2 = valor2
                urdos = (_ur1 + _ur2) / 2
                ureados = urdos - ureapromedio
            End If
            'GUARDO PRIMER REGISTRO
            Dim r2 As New dResultadosBD
            _fecha = a2.FECHA
            _fec = Format(_fecha, "yyyy-MM-dd")
            r2.FECHA = _fec
            r2.HORA = a2.HORA
            r2.ID = a2.IDENT
            r2.EQUIPO = a2.EQUIPO
            r2.MGR = grasapromedio
            r2.GR1 = _gr1
            r2.GR2 = _gr2
            r2.GRASA = grasados
            r2.MPR = proteinapromedio
            r2.PR1 = _pr1
            r2.PR2 = _pr2
            r2.PROTEINA = proteinados
            r2.MLA = lactosapromedio
            r2.LA1 = _la1
            r2.LA2 = _la2
            r2.LACTOSA = lactosados
            r2.MST = stotalespromedio
            r2.ST1 = _st1
            r2.ST2 = _st2
            r2.SOLTOTALES = stotalesdos
            r2.MCE = celulaspromedio
            r2.CE1 = _ce1
            r2.CE2 = _ce2
            r2.CELULAS = celulasdos
            r2.MCR = crioscopiapromedio
            r2.CR1 = _cr1
            r2.CR2 = _cr2
            r2.CRIOSCOPIA = crioscopiados
            r2.MUR = ureapromedio
            r2.UR1 = _ur1
            r2.UR2 = _ur2
            r2.UREA = ureados
            r2.VALIDO = "n"
            r2.guardar(Usuario)
        End If
        contador = 1
        a1.vaciar(Usuario, archivox)
        a2.vaciar(Usuario, archivox)
        MsgBox("Proceso finalizado!")

        Dim v As New FormGraficaControl
        v.Show()

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grabo_resultados()
    End Sub

    Private Sub ButtonB6_Click(sender As Object, e As EventArgs) Handles ButtonB6.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.csv)|*.csv"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\C:\data"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            Dim Archivo As New FileInfo(fichero)
            fecha_fat = Archivo.LastWriteTime.ToShortDateString
            fec_fat = Format(fecha_fat, "yyyy-MM-dd")
            hora_fat = Archivo.LastWriteTime.ToShortTimeString
            archivox = Archivo.Name
            TextArchivo.Text = fichero
            arch1 = 1
            arch2 = 0
            arch3 = 0
        End If
        If TextArchivo.Text <> "" Then
            proceso_delta600("B6")
        End If
    End Sub
End Class