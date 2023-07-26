Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormInformesCajas
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
        DateDesde.Value = Now
        DateHasta.Value = Now
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSinDevolver.Click
        TextIdCliente.Text = ""
        TextCliente.Text = ""
        listar()

    End Sub
    Private Sub listar()
        ListInformes.Items.Clear()
        Listproductor.Items.Clear()
        Dim en As New dEnvioCajas
        Dim p As New dPedidos
        Dim pr As New dCliente
        Dim lista As New ArrayList
        Dim contador As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        lista = en.listarsindevolver(fecdesde, fechasta)
        ListInformes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    p.ID = en.IDPEDIDO
                    p = p.buscar
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    ListInformes().Items.Add(en)
                    'ListBox1().Items.Add(en.IDPEDIDO & Chr(9) & en.FECHAENVIO & Chr(9) & Chr(9) & en.IDCAJA & Chr(9) & Chr(9) & pr.NOMBRE)
                    Listproductor().Items.Add(en.FECHAENVIO & Chr(9) & pr.NOMBRE & Chr(9) & pr.TELEFONO1)
                Next
            End If
        End If
    End Sub
    Private Sub listar2()
        ListInformes.Items.Clear()
        Listproductor.Items.Clear()
        Dim en As New dEnvioCajas
        Dim p As New dPedidos
        Dim pr As New dCliente
        Dim lista As New ArrayList
        Dim contador As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        lista = en.listarsindevolver2(fecdesde, fechasta)
        ListInformes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    p.ID = en.IDPEDIDO
                    p = p.buscar
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    ListInformes().Items.Add(en)
                    'ListBox1().Items.Add(en.IDPEDIDO & Chr(9) & en.FECHAENVIO & Chr(9) & Chr(9) & en.IDCAJA & Chr(9) & Chr(9) & pr.NOMBRE)
                    Listproductor().Items.Add(en.FECHAENVIO & Chr(9) & pr.NOMBRE & Chr(9) & pr.TELEFONO1)
                Next
            End If
        End If
    End Sub
    Private Sub ListInformea_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) _
                Handles ListInformes.MouseMove

        'Me.ListInformes.SelectedIndex = Me.ListInformes.IndexFromPoint(e.Location)
        Me.Listproductor.SelectedIndex = Me.ListInformes.IndexFromPoint(e.Location)
    End Sub

    Private Sub ListInformes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListInformes.SelectedIndexChanged
        Dim env As dEnvioCajas = CType(ListInformes.SelectedItem, dEnvioCajas)
        If ListInformes.SelectedItems.Count = 1 Then
            Dim idpedido As Long = env.IDPEDIDO
            'Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
            'Dim recibo As String = TextRemito.Text.Trim
            Dim fecharecibo As Date = Now
            'Dim observaciones As String = TextObservaciones.Text.Trim
            If Not ListInformes.SelectedItem Is Nothing Then
                'Dim env As New dEnvioCajas()
                'If TextCaja.Text.Trim.Length > 0 Then
                Dim fec As String
                fec = Format(fecharecibo, "yyyy-MM-dd")
                env.IDPEDIDO = idpedido
                env.IDAGENCIA = 8
                env.RECIBO = "s/n"
                env.FECHARECIBO = fec
                env.OBSRECIBO = "Entrada manual"
                env.RECIBIDO = 1
                'End If
                If MsgBox("La caja será marcada como recibida, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                    If (env.marcarrecibido(Usuario)) Then
                        'MsgBox("Caja recibida", MsgBoxStyle.Information, "Atención")
                        listar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListarxcaja.Click
        TextIdCliente.Text = ""
        TextCliente.Text = ""
        listar2()
    End Sub

    Private Sub ButtonImprimirxfecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirxfecha.Click
        TextIdCliente.Text = ""
        TextCliente.Text = ""
        imprimirxfecha()
    End Sub

    Private Sub imprimirxfecha()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        '*****************************
        Dim en As New dEnvioCajas
        Dim p As New dPedidos
        Dim pr As New dCliente
        Dim lista As New ArrayList
        Dim contador As Integer = 0
        Dim valor As Double = 0
        Dim valor1 As Double = 0
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        lista = en.listarsindevolver(fecdesde, fechasta)
        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 11
        x1hoja.Cells(1, 4).columnwidth = 26 '22
        x1hoja.Cells(1, 5).columnwidth = 22 '17
        x1hoja.Cells(1, 6).columnwidth = 55 '19

        x1hoja.Cells(fila, columna).Formula = "LISTADO DE CAJAS SIN DEVOLVER (ORDENADO POR FECHA)"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "CAJA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.1"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.2"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.3"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FRASCOS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FEHA ENVÍO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "PRODUCTOR"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "TELEFONO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "OBSERVACIONES"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    p.ID = en.IDPEDIDO
                    p = p.buscar
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    x1hoja.Cells(fila, columna).Formula = en.IDCAJA
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA1
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA2
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA3
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FRASCOS
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FECHAENVIO
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = pr.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = pr.TELEFONO1
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    contador = contador + 1
                    valor = 100 / lista.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        ProgressBar1.Value = 0
    End Sub

    Private Sub ButtonImprimirxcaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirxcaja.Click
        TextIdCliente.Text = ""
        TextCliente.Text = ""
        imprimirxcaja()
    End Sub
    Private Sub imprimirxcaja()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        '*****************************
        Dim en As New dEnvioCajas
        Dim p As New dPedidos
        Dim pr As New dCliente
        Dim lista As New ArrayList
        Dim contador As Integer = 0
        Dim valor As Double = 0
        Dim valor1 As Double = 0
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        lista = en.listarsindevolver2(fecdesde, fechasta)
        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 11
        x1hoja.Cells(1, 4).columnwidth = 26 '22
        x1hoja.Cells(1, 5).columnwidth = 22 '17
        x1hoja.Cells(1, 6).columnwidth = 55 '19

        x1hoja.Cells(fila, columna).Formula = "LISTADO DE CAJAS SIN DEVOLVER (ORDENADO POR CAJA)"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "CAJA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.1"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.2"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.3"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FRASCOS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FEHA ENVÍO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "PRODUCTOR"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "TELEFONO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "OBSERVACIONES"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    p.ID = en.IDPEDIDO
                    p = p.buscar
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    x1hoja.Cells(fila, columna).Formula = en.IDCAJA
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA1
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA2
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA3
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FRASCOS
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FECHAENVIO
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = pr.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = pr.TELEFONO1
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    contador = contador + 1
                    valor = 100 / lista.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        ProgressBar1.Value = 0
    End Sub

    Private Sub ButtonBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarCliente.Click
        TextIdCliente.Text = ""
        TextCliente.Text = ""
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdCliente.Text = cli.ID
            TextCliente.Text = cli.NOMBRE
        End If
    End Sub

    Private Sub ButtonListarxCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListarxCliente.Click
        listarxcliente()

    End Sub
    Private Sub listarxcliente()
        If TextIdCliente.Text.Trim.Length = 0 Then MsgBox("Seleccione un cliente", MsgBoxStyle.Exclamation, "Atención") : TextIdCliente.Focus() : Exit Sub
        ListInformes.Items.Clear()
        Listproductor.Items.Clear()
        Dim en As New dEnvioCajas
        Dim p As New dPedidos
        Dim pr As New dCliente
        Dim lista As New ArrayList
        Dim idproductor As Long = TextIdCliente.Text.Trim
        Dim contador As Integer = 0

        lista = en.listarxcliente(idproductor)
        ListInformes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    p.ID = en.IDPEDIDO
                    p = p.buscar
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    ListInformes().Items.Add(en)
                    'ListBox1().Items.Add(en.IDPEDIDO & Chr(9) & en.FECHAENVIO & Chr(9) & Chr(9) & en.IDCAJA & Chr(9) & Chr(9) & pr.NOMBRE)
                    Listproductor().Items.Add(en.FECHAENVIO & Chr(9) & pr.NOMBRE & Chr(9) & pr.TELEFONO1)
                Next
            End If
        End If
    End Sub
    Private Sub imprimirxcliente()
        If TextIdCliente.Text.Trim.Length = 0 Then MsgBox("Seleccione un cliente", MsgBoxStyle.Exclamation, "Atención") : TextIdCliente.Focus() : Exit Sub
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        '*****************************
        Dim en As New dEnvioCajas
        Dim p As New dPedidos
        Dim pr As New dCliente
        Dim lista As New ArrayList
        Dim contador As Integer = 0
        Dim valor As Double = 0
        Dim valor1 As Double = 0
        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim idcliente As Long = TextIdCliente.Text.Trim


        lista = en.listarxcliente(idcliente)
        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 11
        x1hoja.Cells(1, 4).columnwidth = 26 '22
        x1hoja.Cells(1, 5).columnwidth = 22 '17
        x1hoja.Cells(1, 6).columnwidth = 55 '19

        x1hoja.Cells(fila, columna).Formula = "LISTADO DE CAJAS SIN DEVOLVER (POR CLIENTE)"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "CAJA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.1"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.2"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "GR.3"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FRASCOS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FEHA ENVÍO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "PRODUCTOR"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "TELEFONO"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "OBSERVACIONES"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each en In lista
                    p.ID = en.IDPEDIDO
                    p = p.buscar
                    pr.ID = p.IDPRODUCTOR
                    pr = pr.buscar
                    x1hoja.Cells(fila, columna).Formula = en.IDCAJA
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA1
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA2
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = en.GRADILLA3
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    'columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FRASCOS
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = en.FECHAENVIO
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = pr.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = pr.TELEFONO1
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    contador = contador + 1
                    valor = 100 / lista.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        ProgressBar1.Value = 0
    End Sub

    Private Sub ButtonImprimirxcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirxcliente.Click
        imprimirxcliente()
    End Sub
End Class