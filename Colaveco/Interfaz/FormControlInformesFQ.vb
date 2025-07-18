﻿Imports System.IO
Public Class FormControlInformesFQ
    Public check_resultado As Integer = 0
    Public check_coincide As Integer = 0
    Public check_om As Integer = 0
    Public check_nc As Integer = 0
    Dim email As String
    Dim Informe As Long

#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        listarinformesfq()
    End Sub

#End Region
    
    Private Sub listarinformesfq()
        Dim cifq As New dControlInformesFQ

        Dim lista As New ArrayList
        lista = cifq.listar
        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then


                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each cifq In lista
                    Dim m As New dMuestras
                    Dim ti As New dTipoInforme
                    Dim si As New dSubInforme
                    Dim s As New dSinaveleFicha

                    DataGridView1(columna, fila).Value = cifq.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cifq.FECHACONTROL
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cifq.FICHA
                    columna = columna + 1
                    's.FICHA = cifq.FICHA
                    's = s.buscar
                    'If Not s Is Nothing Then
                    '    DataGridView1(columna, fila).Value = s.SINAVELE
                    '    columna = columna + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = ""
                    '    columna = columna + 1
                    'End If
                    DataGridView1(columna, fila).Value = cifq.FECHA
                    columna = columna + 1
                    'm.ID = cifq.MUESTRA
                    'm = m.buscar
                    'If Not m Is Nothing Then
                    '    DataGridView1(columna, fila).Value = m.NOMBRE
                    '    columna = columna + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "vacío"
                    '    columna = columna + 1
                    'End If
                    ti.ID = cifq.TIPO
                    ti = ti.buscar
                    DataGridView1(columna, fila).Value = ti.NOMBRE
                    columna = columna + 1
                    'si.ID = cifq.SUBTIPO
                    'si = si.buscar
                    'If Not si Is Nothing Then
                    '    DataGridView1(columna, fila).Value = si.NOMBRE
                    '    columna = columna + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = ""
                    '    columna = columna + 1
                    'End If
                    If cifq.RESULTADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If cifq.COINCIDE = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If cifq.OM = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    If cifq.NC = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = cifq.OBSERVACIONES
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = Usuario.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Ver informe"
                    columna = columna + 1
                    If cifq.CONTROLADO = 0 Then
                        DataGridView1(columna, fila).Value = False
                    Else
                        DataGridView1(columna, fila).Value = True
                    End If
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = DataGridView1.Columns(5).Index Then
            check_resultado = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_resultado = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(6).Index Then
            check_coincide = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_coincide = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(7).Index Then
            check_om = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_om = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
        If e.ColumnIndex = DataGridView1.Columns(8).Index Then
            check_nc = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If check_nc = 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Dim Arch1 As String, Arch2 As String, Arch3 As String, Arch4 As String, Arch5 As String, Arch6 As String, Arch7 As String, Arch8 As String
        Dim Arch1 As String, Arch2 As String, Arch3 As String, Arch5 As String


        If DataGridView1.Columns(e.ColumnIndex).Name = "Resultado" Then
            If check_resultado = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarresultado(Usuario)
                'GestorNuevo modificar estado Cotnrol
                Dim controlGestor As New dNGControl
                Try
                    'Registro en Gestor Nuevo
                    controlGestor.InformeId = row.Cells("Ficha").Value
                    controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                    controlGestor.ControlControlado = 1
                    controlGestor.modificar()
                Catch ex As Exception

                End Try
                listarinformesfq()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarresultado(Usuario)
                'GestorNuevo modificar estado Cotnrol
                Dim controlGestor As New dNGControl
                Try
                    'Registro en Gestor Nuevo
                    controlGestor.InformeId = row.Cells("Ficha").Value
                    controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                    controlGestor.ControlControlado = 0
                    controlGestor.modificar()
                Catch ex As Exception

                End Try
                listarinformesfq()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Coincide" Then
            If check_coincide = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarcoincide(Usuario)
                'GestorNuevo modificar estado Cotnrol
                Dim controlGestor As New dNGControl
                Try
                    'Registro en Gestor Nuevo
                    controlGestor.InformeId = row.Cells("Ficha").Value
                    controlGestor.ControlCoincide = 1
                    controlGestor.coincideControl()

                Catch ex As Exception

                End Try
                listarinformesfq()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarcoincide(Usuario)
                'GestorNuevo modificar estado Cotnrol
                Dim controlGestor As New dNGControl
                Try
                    'Registro en Gestor Nuevo
                    controlGestor.InformeId = row.Cells("Ficha").Value
                    controlGestor.ControlCoincide = 0
                    controlGestor.coincideControl()

                Catch ex As Exception

                End Try
                listarinformesfq()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "OM" Then
            If check_om = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarom(Usuario)
                listarinformesfq()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarom(Usuario)
                listarinformesfq()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "NC" Then
            If check_nc = 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.marcarnc(Usuario)
                listarinformesfq()
            Else
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim id As Long = 0
                Dim ci As New dControlInformesFQ
                id = row.Cells("Id").Value
                ci.ID = id
                ci.desmarcarnc(Usuario)
                listarinformesfq()
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Controlada" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim observaciones As String = ""
            Dim ci As New dControlInformesFQ
            id = row.Cells("Id").Value
            observaciones = row.Cells("Observaciones").Value
            ci.ID = id
            ci.marcarcontrolada(Usuario)

            'GestorNuevo modificar estado Cotnrol
            Dim controlGestor As New dNGControl
            Try
                'Registro en Gestor Nuevo
                Informe = row.Cells("Ficha").Value
                controlGestor.InformeId = row.Cells("Ficha").Value
                controlGestor.ControlControlado = 1
                controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                controlGestor.modificar()
                enviomailInformeConVisualizacion()
            Catch ex As Exception

            End Try

            ci.guardarobservaciones(Usuario, observaciones)
            listarinformesfq()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "VerInforme" Then
            Dim sa1 As New dSolicitudAnalisis
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ficha As Long = 0

            Dim ci As New dControlInformesFQ
            id = row.Cells("Id").Value
            ficha = row.Cells("Ficha").Value
            ci.ID = id
            ci = ci.buscar

            sa1.ID = ficha
            sa1 = sa1.buscar
            If Not sa1 Is Nothing Then
                If sa1.ELIMINADO = 1 Then
                    MsgBox("Esta solicitud fué eliminada!")
                End If
            End If

            If Not ci Is Nothing Then

                If ci.TIPO = 1 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    'Arch2 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    'Arch3 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                ElseIf ci.TIPO = 3 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    'Arch2 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    'Arch3 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                ElseIf ci.TIPO = 4 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    'Arch2 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    'Arch3 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    'ElseIf ci.TIPO = 5 Then
                    '    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '    Arch2 = "\\192.168.1.10\E\NET\PAL\" & ficha & ".xls"
                    '    Arch3 = "\\192.168.1.10\E\NET\PAL\" & ficha & ".pdf"
                    '    Arch4 = "\\192.168.1.10\E\NET\PAL\" & ficha & "A.xls"
                    '    If File.Exists(Arch1) Then
                    '        System.Diagnostics.Process.Start(Arch1)
                    '    End If
                    '    If File.Exists(Arch2) Then
                    '        System.Diagnostics.Process.Start(Arch2)
                    '    ElseIf File.Exists(Arch3) Then
                    '        System.Diagnostics.Process.Start(Arch3)
                    '    End If
                    '    If File.Exists(Arch4) Then
                    '        System.Diagnostics.Process.Start(Arch4)
                    '    End If
                    'ElseIf ci.TIPO = 6 Then
                    '    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '    Arch2 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & ".xls"
                    '    Arch3 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & ".pdf"
                    '    Arch4 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & "A.xls"
                    '    If File.Exists(Arch1) Then
                    '        System.Diagnostics.Process.Start(Arch1)
                    '    End If
                    '    If File.Exists(Arch2) Then
                    '        System.Diagnostics.Process.Start(Arch2)
                    '    ElseIf File.Exists(Arch3) Then
                    '        System.Diagnostics.Process.Start(Arch3)
                    '    End If
                    '    If File.Exists(Arch4) Then
                    '        System.Diagnostics.Process.Start(Arch4)
                    '    End If
                ElseIf ci.TIPO = 7 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    'Arch2 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    'Arch3 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    'ElseIf ci.TIPO = 8 Then
                    '    Dim sa As New dSolicitudAnalisis
                    '    sa.ID = ficha
                    '    sa = sa.buscar
                    '    If sa.IDSUBINFORME = 22 Then
                    '        Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '        Arch2 = "http://www.mgap.gub.uy/sinavele/hsinavele.aspx"

                    '        'Arch2 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                    '        'Arch3 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                    '        'Arch4 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & "A.xls"
                    '        If File.Exists(Arch1) Then
                    '            System.Diagnostics.Process.Start(Arch1)
                    '        End If
                    '        System.Diagnostics.Process.Start(Arch2)
                    '        'If File.Exists(Arch2) Then
                    '        '    System.Diagnostics.Process.Start(Arch2)
                    '        'ElseIf File.Exists(Arch3) Then
                    '        '    System.Diagnostics.Process.Start(Arch3)
                    '        'End If
                    '        'If File.Exists(Arch4) Then
                    '        '    System.Diagnostics.Process.Start(Arch4)
                    '        'End If
                    '    Else
                    '        'Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '        'Arch2 = "\\192.168.1.10\E\NET\LEPTO\" & ficha & ".xls"
                    '        'Arch3 = "\\192.168.1.10\E\NET\LEPTO\" & ficha & ".pdf"
                    '        'Arch4 = "\\192.168.1.10\E\NET\LEPTO Y NEOSPORA\" & ficha & ".xls"
                    '        'Arch5 = "\\192.168.1.10\E\NET\LEPTO Y NEOSPORA\" & ficha & ".pdf"
                    '        'Arch6 = "\\192.168.1.10\E\NET\LEUCOSIS\" & ficha & ".xls"
                    '        'Arch7 = "\\192.168.1.10\E\NET\LEUCOSIS\" & ficha & ".pdf"
                    '        Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '        Arch2 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                    '        Arch3 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                    '        Arch4 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                    '        Arch5 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                    '        Arch6 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                    '        Arch7 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                    '        If File.Exists(Arch1) Then
                    '            System.Diagnostics.Process.Start(Arch1)
                    '        End If
                    '        If File.Exists(Arch2) Then
                    '            System.Diagnostics.Process.Start(Arch2)
                    '        ElseIf File.Exists(Arch3) Then
                    '            System.Diagnostics.Process.Start(Arch3)
                    '        ElseIf File.Exists(Arch5) Then
                    '            System.Diagnostics.Process.Start(Arch5)
                    '        ElseIf File.Exists(Arch6) Then
                    '            System.Diagnostics.Process.Start(Arch6)
                    '        ElseIf File.Exists(Arch7) Then
                    '            System.Diagnostics.Process.Start(Arch7)
                    '        ElseIf File.Exists(Arch8) Then
                    '            System.Diagnostics.Process.Start(Arch8)
                    '        End If

                    '    End If
                    'ElseIf ci.TIPO = 9 Then
                    '    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '    Arch2 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & ".xls"
                    '    Arch3 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & ".pdf"
                    '    Arch4 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & "A.xls"

                    '    If File.Exists(Arch1) Then
                    '        System.Diagnostics.Process.Start(Arch1)
                    '    End If
                    '    If File.Exists(Arch2) Then
                    '        System.Diagnostics.Process.Start(Arch2)
                    '    ElseIf File.Exists(Arch3) Then
                    '        System.Diagnostics.Process.Start(Arch3)
                    '    End If
                    '    If File.Exists(Arch4) Then
                    '        System.Diagnostics.Process.Start(Arch4)
                    '    End If
                ElseIf ci.TIPO = 10 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    'Arch2 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    'Arch3 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    'ElseIf ci.TIPO = 13 Then
                    '    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '    Arch2 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".xls"
                    '    Arch3 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".pdf"
                    '    Arch4 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & "A.xls"
                    '    Arch5 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".xlsx"
                    '    If File.Exists(Arch1) Then
                    '        System.Diagnostics.Process.Start(Arch1)
                    '    End If
                    '    If File.Exists(Arch2) Then
                    '        System.Diagnostics.Process.Start(Arch2)
                    '    ElseIf File.Exists(Arch3) Then
                    '        System.Diagnostics.Process.Start(Arch3)
                    '    ElseIf File.Exists(Arch5) Then
                    '        System.Diagnostics.Process.Start(Arch5)
                    '    End If
                    '    If File.Exists(Arch4) Then
                    '        System.Diagnostics.Process.Start(Arch4)
                    '    End If
                    'ElseIf ci.TIPO = 14 Then
                    '    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    '    Arch2 = "\\192.168.1.10\E\NET\suelos\" & ficha & ".xls"
                    '    Arch3 = "\\192.168.1.10\E\NET\suelos\" & ficha & ".pdf"
                    '    Arch4 = "\\192.168.1.10\E\NET\suelos\" & ficha & "A.xls"
                    '    Arch5 = "\\192.168.1.10\E\NET\suelos\" & ficha & ".xlsx"
                    '    If File.Exists(Arch1) Then
                    '        System.Diagnostics.Process.Start(Arch1)
                    '    End If
                    '    If File.Exists(Arch2) Then
                    '        System.Diagnostics.Process.Start(Arch2)
                    '    ElseIf File.Exists(Arch3) Then
                    '        System.Diagnostics.Process.Start(Arch3)
                    '    ElseIf File.Exists(Arch5) Then
                    '        System.Diagnostics.Process.Start(Arch5)
                    '    End If
                    '    If File.Exists(Arch4) Then
                    '        System.Diagnostics.Process.Start(Arch4)
                    '    End If
                ElseIf ci.TIPO = 15 Then
                    Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                    'Arch2 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
                    Arch2 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
                    'Arch3 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    Arch3 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
                    'Arch5 = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    Arch5 = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xlsx"
                    If File.Exists(Arch1) Then
                        System.Diagnostics.Process.Start(Arch1)
                    End If
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub enviomailInformeConVisualizacion()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        sa.ID = Informe
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If
        Dim texto As String = ""
        texto = "Nos es grato comunicarle que el informe Nº " & " " & Informe & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se encuentra disponible en la web/app de Colaveco." & vbCrLf _
            & "Para poder acceder a los resultados debe ir a www.colaveco.com.uy y digitar su usuario y contraseña." & vbCrLf _
            & "Sino cuenta con usuario y contraseña, favor solicitarla en administración al correo electrónico colaveco@gmail.com o al teléfono 4554 5311." & vbCrLf _
            & "Agradecemos su confianza y quedamos a sus órdenes." & vbCrLf & vbCrLf _
            & "Sin mas, saluda muy atte." & vbCrLf & vbCrLf _
            & "Administración - COLAVECO"

        Dim sol As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim prod As Long = sol.IDPRODUCTOR
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        If cli.NOT_EMAIL_ANALISIS1 <> "" Then
            email = RTrim(cli.NOT_EMAIL_ANALISIS1)
        ElseIf cli.NOT_EMAIL_ANALISIS2 <> "" Then
            email = RTrim(cli.NOT_EMAIL_ANALISIS2)
        ElseIf cli.EMAIL <> "" Then
            email = RTrim(cli.EMAIL)
        End If

        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            Try
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Informe" & " Nº " & Informe & " - Colaveco"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = texto
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        Informe = 0
    End Sub
End Class