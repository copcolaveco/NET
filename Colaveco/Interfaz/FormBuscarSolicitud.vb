Imports System.IO
Public Class FormBuscarSolicitud
    Private _solicitudanalisis As dSolicitudAnalisis
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Property SolicitudAnalisis() As dSolicitudAnalisis
        Get
            Return _solicitudanalisis
        End Get
        Set(ByVal value As dSolicitudAnalisis)
            _solicitudanalisis = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        RadioButtonSolicitud.Checked = True
        Dim dtFecha As Date = DateSerial(Year(Date.Today), Month(Date.Today), 1)
        DateTimeDesde.Value = dtFecha
        DateTimeHasta.Value = Date.Today
        ocultar_campos()
    End Sub
#End Region
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
        End If
    End Sub
    Private Sub limpiar()
        Textficha.Text = ""
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        'ListSolicitudes.Items.Clear()
    End Sub
    Private Sub ocultar_campos()
        If RadioButtonSolicitud.Checked = True Then
            Textficha.Enabled = True
            TextIdProductor.Enabled = False
            TextProductor.Enabled = False
            ButtonBuscarProductor.Enabled = False
            DateTimeDesde.Enabled = False
            DateTimeHasta.Enabled = False
        ElseIf RadioButtonProductor.Checked = True Then
            Textficha.Enabled = False
            TextIdProductor.Enabled = True
            TextProductor.Enabled = True
            ButtonBuscarProductor.Enabled = True
            DateTimeDesde.Enabled = True
            DateTimeHasta.Enabled = True
        Else
            Textficha.Enabled = False
            TextIdProductor.Enabled = False
            TextProductor.Enabled = False
            ButtonBuscarProductor.Enabled = False
            DateTimeDesde.Enabled = True
            DateTimeHasta.Enabled = True
        End If
    End Sub

    Private Sub RadioButtonSolicitud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSolicitud.CheckedChanged
        ocultar_campos()
    End Sub

    Private Sub RadioButtonProductor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonProductor.CheckedChanged
        ocultar_campos()
    End Sub

    Private Sub RadioButtonFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ocultar_campos()
    End Sub
    Private Sub listarporid()
     
        Dim s As New dSolicitudAnalisis
        Dim texto As Long = Textficha.Text.Trim
        Dim lista As New ArrayList
        lista = s.listarporid(texto)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHAINGRESO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.NMUESTRAS
                    columna = columna + 1
                    If s.IDTIPOINFORME = 1 Then
                        Dim noap As New dMuestrasNoAptas
                        Dim listanoap As New ArrayList
                        Dim ficha = s.ID
                        listanoap = noap.listarporficha(ficha)
                        Dim cantidad As Integer = 0
                        If Not listanoap Is Nothing Then
                            For Each noap In listanoap
                                If noap.MOTIVO <> 8 Then
                                    cantidad = cantidad + noap.CANTIDAD
                                End If
                            Next
                        End If
                        If Not noap Is Nothing Then
                            DataGridView1(columna, fila).Value = cantidad
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        noap = Nothing
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim ti As New dTipoInforme
                    ti.ID = s.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim p As New dCliente
                    p.ID = s.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1

                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1

                    End If
                    DataGridView1(columna, fila).Value = s.OBSERVACIONES
                    columna = columna + 1
                    Dim est As New dEstados
                    est.FICHA = s.ID
                    est = est.buscarultimo
                    If Not est Is Nothing Then
                        Dim test As New dEstadosTipos
                        test.ID = est.ESTADO
                        test = test.buscar
                        If Not test Is Nothing Then
                            DataGridView1(columna, fila).Value = test.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PAGO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporproductor()
      
        Dim s As New dSolicitudAnalisis
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")

        Dim texto As Long = TextIdProductor.Text.Trim
        Dim lista As New ArrayList
        lista = s.listarporproductor(texto, fechad, fechah)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHAINGRESO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.NMUESTRAS
                    columna = columna + 1
                    If s.IDTIPOINFORME = 1 Then
                        Dim noap As New dMuestrasNoAptas
                        Dim listanoap As New ArrayList
                        Dim ficha = s.ID
                        listanoap = noap.listarporficha(ficha)
                        Dim cantidad As Integer = 0
                        If Not listanoap Is Nothing Then
                            For Each noap In listanoap
                                If noap.MOTIVO <> 8 Then
                                    cantidad = cantidad + noap.CANTIDAD
                                End If
                            Next
                        End If
                        If Not noap Is Nothing Then
                            DataGridView1(columna, fila).Value = cantidad
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        noap = Nothing
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim ti As New dTipoInforme
                    ti.ID = s.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim p As New dCliente
                    p.ID = s.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1

                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1

                    End If
                    DataGridView1(columna, fila).Value = s.OBSERVACIONES
                    columna = columna + 1
                    Dim est As New dEstados
                    est.FICHA = s.ID
                    est = est.buscarultimo
                    If Not est Is Nothing Then
                        Dim test As New dEstadosTipos
                        test.ID = est.ESTADO
                        test = test.buscar
                        If Not test Is Nothing Then
                            DataGridView1(columna, fila).Value = test.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PAGO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub listarporfecha()
        Dim s As New dSolicitudAnalisis
        Dim fechadesde As Date = DateTimeDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateTimeHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = s.listarporfecha(fechad, fechah)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHAINGRESO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.NMUESTRAS
                    columna = columna + 1
                    If s.IDTIPOINFORME = 1 Then
                        Dim noap As New dMuestrasNoAptas
                        Dim listanoap As New ArrayList
                        Dim ficha = s.ID
                        listanoap = noap.listarporficha(ficha)
                        Dim cantidad As Integer = 0
                        If Not listanoap Is Nothing Then
                            For Each noap In listanoap
                                If noap.MOTIVO <> 8 Then
                                    cantidad = cantidad + noap.CANTIDAD
                                End If
                            Next
                        End If
                        If Not noap Is Nothing Then
                            DataGridView1(columna, fila).Value = cantidad
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        noap = Nothing
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim ti As New dTipoInforme
                    ti.ID = s.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim p As New dCliente
                    p.ID = s.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1

                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1

                    End If
                    DataGridView1(columna, fila).Value = s.OBSERVACIONES
                    columna = columna + 1
                    Dim est As New dEstados
                    est.FICHA = s.ID
                    est = est.buscarultimo
                    If Not est Is Nothing Then
                        Dim test As New dEstadosTipos
                        test.ID = est.ESTADO
                        test = test.buscar
                        If Not test Is Nothing Then
                            DataGridView1(columna, fila).Value = test.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    If s.PAGO = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'ListSolicitudes.Items.Clear()
        If RadioButtonSolicitud.Checked = True Then
            listarporid()
        ElseIf RadioButtonProductor.Checked = True Then
            listarporproductor()
        Else
            listarporfecha()
        End If
    End Sub

    Private Sub ListSolicitudes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ListSolicitudes.SelectedItems.Count = 1 Then
        '    Dim sol As dSolicitudAnalisis = CType(ListSolicitudes.SelectedItem, dSolicitudAnalisis)
        '    SolicitudAnalisis = sol
        'End If
        'Me.Close()
    End Sub

    Private Sub Textficha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Textficha.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Textficha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textficha.TextChanged

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Dim Arch1 As String, Arch2 As String, Arch3 As String, Arch4 As String, Arch5 As String, Arch6 As String, Arch7 As String, Arch8 As String
        Dim Arch2 As String, Arch3 As String, Arch4 As String, Arch5 As String, Arch6 As String, Arch7 As String
        If DataGridView1.Columns(e.ColumnIndex).Name = "Pagook" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolicitudAnalisis
            id = row.Cells("Ficha").Value
            s.ID = id
            s = s.buscar
            If s.PAGO = 1 Then
                s.desmarcarpago(Usuario)
            Else
                s.marcarpago(Usuario)
            End If
            DataGridView1.Rows.Clear()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Seleccionar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolicitudAnalisis
            id = row.Cells("Ficha").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                SolicitudAnalisis = s
                Me.Close()
            End If

        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Excel" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim ficha As Long = 0
            Dim s As New dSolicitudAnalisis
            ficha = row.Cells("Ficha").Value
            s.ID = ficha
            s = s.buscar
            If Not s Is Nothing Then

                If s.IDTIPOINFORME = 1 Then
                    Arch2 = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & ficha & "A.xls"
                    'If File.Exists(Arch2) Then
                    '    System.Diagnostics.Process.Start(Arch2)
                    If File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 3 Then
                    Arch2 = "\\192.168.1.10\E\NET\AGUA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\AGUA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\AGUA\" & ficha & "A.xls"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 4 Then
                    Arch2 = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & ficha & "A.xls"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 5 Then
                    Arch2 = "\\192.168.1.10\E\NET\PAL\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\PAL\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\PAL\" & ficha & "A.xls"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 6 Then
                    Arch2 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & ficha & "A.xls"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 7 Then
                    Arch2 = "\\192.168.1.10\E\NET\ALIMENTOS\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\ALIMENTOS\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\ALIMENTOS\" & ficha & "A.xls"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 8 Then
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = ficha
                    sa = sa.buscar
                    If sa.IDSUBINFORME = 22 Then
                        'Arch1 = "\\192.168.1.10\E\NET\SOLICITUDES\S" & ficha & ".xls"
                        'Arch2 = "http://www.mgap.gub.uy/sinavele/hsinavele.aspx"

                        'Arch2 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".xls"
                        'Arch3 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & ".pdf"
                        'Arch4 = "\\192.168.1.10\E\NET\SEROLOGIA\" & ficha & "A.xls"
                        'If File.Exists(Arch1) Then
                        '    System.Diagnostics.Process.Start(Arch1)
                        'End If
                        'System.Diagnostics.Process.Start(Arch2)
                        'If File.Exists(Arch2) Then
                        '    System.Diagnostics.Process.Start(Arch2)
                        'ElseIf File.Exists(Arch3) Then
                        '    System.Diagnostics.Process.Start(Arch3)
                        'End If
                        'If File.Exists(Arch4) Then
                        '    System.Diagnostics.Process.Start(Arch4)
                        'End If
                    Else
                        Arch2 = "\\192.168.1.10\E\NET\LEPTO\" & ficha & ".xls"
                        Arch3 = "\\192.168.1.10\E\NET\LEPTO\" & ficha & ".pdf"
                        Arch4 = "\\192.168.1.10\E\NET\LEPTO Y NEOSPORA\" & ficha & ".xls"
                        Arch5 = "\\192.168.1.10\E\NET\LEPTO Y NEOSPORA\" & ficha & ".pdf"
                        Arch6 = "\\192.168.1.10\E\NET\LEUCOSIS\" & ficha & ".xls"
                        Arch7 = "\\192.168.1.10\E\NET\LEUCOSIS\" & ficha & ".pdf"
                        If File.Exists(Arch2) Then
                            System.Diagnostics.Process.Start(Arch2)
                        ElseIf File.Exists(Arch3) Then
                            System.Diagnostics.Process.Start(Arch3)
                        ElseIf File.Exists(Arch5) Then
                            System.Diagnostics.Process.Start(Arch5)
                        ElseIf File.Exists(Arch6) Then
                            System.Diagnostics.Process.Start(Arch6)
                        ElseIf File.Exists(Arch7) Then
                            System.Diagnostics.Process.Start(Arch7)
                        End If

                    End If
                ElseIf s.IDTIPOINFORME = 9 Then
                    Arch2 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\PATOLOGIA\" & ficha & "A.xls"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 10 Then
                    Arch2 = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & "A.xls"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 11 Then
                    Arch2 = "\\192.168.1.10\E\NET\AMBIENTAL\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\AMBIENTAL\" & ficha & ".pdf"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    End If
                ElseIf s.IDTIPOINFORME = 13 Then
                    Arch2 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & "A.xls"
                    Arch5 = "\\192.168.1.10\E\NET\NUTRICION\" & ficha & ".xlsx"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 14 Then
                    Arch2 = "\\192.168.1.10\E\NET\Suelos\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\Suelos\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\Suelos\" & ficha & "A.xls"
                    Arch5 = "\\192.168.1.10\E\NET\Suelos\" & ficha & ".xlsx"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                ElseIf s.IDTIPOINFORME = 15 Then
                    Arch2 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & ".xls"
                    Arch3 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & ".pdf"
                    Arch4 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & "A.xls"
                    Arch5 = "\\192.168.1.10\E\NET\Brucelosis en leche\" & ficha & ".xlsx"
                    If File.Exists(Arch2) Then
                        System.Diagnostics.Process.Start(Arch2)
                    ElseIf File.Exists(Arch3) Then
                        System.Diagnostics.Process.Start(Arch3)
                    ElseIf File.Exists(Arch5) Then
                        System.Diagnostics.Process.Start(Arch5)
                    End If
                    If File.Exists(Arch4) Then
                        System.Diagnostics.Process.Start(Arch4)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
   
    End Sub
End Class