Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormEstadisticaNutricion
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
        cargarComboClase()
        'cargarComboAlimento()
        habilitar_alimento()
        habilitar_clase_alimento()

    End Sub
#End Region
    Public Sub cargarComboClase()
        Dim c As New dNutricionClase
        Dim lista As New ArrayList
        lista = c.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboClase.Items.Add(c)
                    ComboClase2.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAlimento()
        ComboAlimento.Items.Clear()
        ComboAlimento2.Items.Clear()
        Dim clasealimento As dNutricionClase = CType(ComboClase.SelectedItem, dNutricionClase)
        Dim idclasealimento As Integer = clasealimento.ID
        Dim a As New dNutricionAlimento
        Dim lista As New ArrayList
        lista = a.listarporclase(idclasealimento)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboAlimento.Items.Add(a)
                    ComboAlimento2.Items.Add(a)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAlimento2()
        ComboAlimento2.Items.Clear()
        Dim clasealimento2 As dNutricionClase = CType(ComboClase2.SelectedItem, dNutricionClase)
        Dim idclasealimento As Integer = clasealimento2.ID
        Dim a As New dNutricionAlimento
        Dim lista As New ArrayList
        lista = a.listarporclase(idclasealimento)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboAlimento2.Items.Add(a)
                Next
            End If
        End If
    End Sub

    Private Sub ComboClase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboClase.SelectedIndexChanged
        cargarComboAlimento()
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        listar()
    End Sub
    Private Sub listar()
        Dim n As New dNutricion
        Dim sumamsh As Double = 0
        Dim sumacenizash As Double = 0
        Dim sumacenizass As Double = 0
        Dim sumapbh As Double = 0
        Dim sumapbs As Double = 0
        Dim sumafndh As Double = 0
        Dim sumafnds As Double = 0
        Dim sumafadh As Double = 0
        Dim sumafads As Double = 0
        Dim sumaenls As Double = 0
        Dim sumaems As Double = 0
        Dim sumafch As Double = 0
        Dim sumafcs As Double = 0
        Dim sumaphh As Double = 0
        Dim sumaeeh As Double = 0
        Dim sumaees As Double = 0
        Dim sumanidah As Double = 0
        'Dim sumadon As Double = 0
        'Dim sumaafla As Double = 0
        'Dim sumazeara As Double = 0
        'Dim sumafibraefectiva As Double = 0
        'Dim sumaclostridios As Double = 0
        Dim cuentamsh As Integer = 0
        Dim cuentacenizash As Integer = 0
        Dim cuentacenizass As Integer = 0
        Dim cuentapbh As Integer = 0
        Dim cuentapbs As Integer = 0
        Dim cuentafndh As Integer = 0
        Dim cuentafnds As Integer = 0
        Dim cuentafadh As Integer = 0
        Dim cuentafads As Integer = 0
        Dim cuentaenls As Integer = 0
        Dim cuentaems As Integer = 0
        Dim cuentafch As Integer = 0
        Dim cuentafcs As Integer = 0
        Dim cuentaphh As Integer = 0
        Dim cuentaeeh As Integer = 0
        Dim cuentaees As Integer = 0
        Dim cuentanidah As Integer = 0
        'Dim cuentadon As Integer = 0
        'Dim cuentaafla As Integer = 0
        'Dim cuentazeara As Integer = 0
        'Dim cuentafibraefectiva As Integer = 0
        'Dim cuentaclostridios As Integer = 0
        Dim productomsh As Double = 1
        Dim productocenizash As Double = 1
        Dim productocenizass As Double = 1
        Dim productopbh As Double = 1
        Dim productopbs As Double = 1
        Dim productofndh As Double = 1
        Dim productofnds As Double = 1
        Dim productofadh As Double = 1
        Dim productofads As Double = 1
        Dim productoenls As Double = 1
        Dim productoems As Double = 1
        Dim productofch As Double = 1
        Dim productofcs As Double = 1
        Dim productophh As Double = 1
        Dim productoeeh As Double = 1
        Dim productoees As Double = 1
        Dim productonidah As Double = 1
        'Dim productodon As Double = 1
        'Dim productoafla As Double = 1
        'Dim productozeara As Double = 1
        'Dim productofibraefectiva As Double = 1
        'Dim productoclostridios As Double = 1
        Dim mediamsh As Double = 0
        Dim mediacenizash As Double = 0
        Dim mediacenizass As Double = 0
        Dim mediapbh As Double = 0
        Dim mediapbs As Double = 0
        Dim mediafndh As Double = 0
        Dim mediafnds As Double = 0
        Dim mediafads As Double = 0
        Dim mediafadh As Double = 0
        Dim mediaenls As Double = 0
        Dim mediaems As Double = 0
        Dim mediafch As Double = 0
        Dim mediafcs As Double = 0
        Dim mediaphh As Double = 0
        Dim mediaeeh As Double = 0
        Dim mediaees As Double = 0
        Dim medianidah As Double = 0
        'Dim mediadon As Double = 0
        'Dim mediaafla As Double = 0
        'Dim mediazeara As Double = 0
        'Dim mediafibraefectiva As Double = 0
        'Dim mediaclostridios As Double = 0
        Dim desvmsh As Double = 0
        Dim desvcenizash As Double = 0
        Dim desvcenizass As Double = 0
        Dim desvpbh As Double = 0
        Dim desvpbs As Double = 0
        Dim desvfndh As Double = 0
        Dim desvfnds As Double = 0
        Dim desvfads As Double = 0
        Dim desvfadh As Double = 0
        Dim desvenls As Double = 0
        Dim desvems As Double = 0
        Dim desvfch As Double = 0
        Dim desvfcs As Double = 0
        Dim desvphh As Double = 0
        Dim desveeh As Double = 0
        Dim desvees As Double = 0
        Dim desvnidah As Double = 0
        'Dim desvdon As Double = 0
        'Dim desvafla As Double = 0
        'Dim desvzeara As Double = 0
        'Dim desvfibraefectiva As Double = 0
        'Dim desvclostridios As Double = 0
        Dim cuadmsh As Double = 0
        Dim cuadcenizash As Double = 0
        Dim cuadcenizass As Double = 0
        Dim cuadpbh As Double = 0
        Dim cuadpbs As Double = 0
        Dim cuadfndh As Double = 0
        Dim cuadfnds As Double = 0
        Dim cuadfads As Double = 0
        Dim cuadfadh As Double = 0
        Dim cuadenls As Double = 0
        Dim cuadems As Double = 0
        Dim cuadfch As Double = 0
        Dim cuadfcs As Double = 0
        Dim cuadphh As Double = 0
        Dim cuadeeh As Double = 0
        Dim cuadees As Double = 0
        Dim cuadnidah As Double = 0
        'Dim cuaddon As Double = 0
        'Dim cuadafla As Double = 0
        'Dim cuadzeara As Double = 0
        'Dim cuadfibraefectiva As Double = 0
        'Dim cuadclostridios As Double = 0
        Dim sumacuadmsh As Double = 0
        Dim sumacuadcenizash As Double = 0
        Dim sumacuadcenizass As Double = 0
        Dim sumacuadpbh As Double = 0
        Dim sumacuadpbs As Double = 0
        Dim sumacuadfndh As Double = 0
        Dim sumacuadfnds As Double = 0
        Dim sumacuadfads As Double = 0
        Dim sumacuadfadh As Double = 0
        Dim sumacuadenls As Double = 0
        Dim sumacuadems As Double = 0
        Dim sumacuadfch As Double = 0
        Dim sumacuadfcs As Double = 0
        Dim sumacuadphh As Double = 0
        Dim sumacuadeeh As Double = 0
        Dim sumacuadees As Double = 0
        Dim sumacuadnidah As Double = 0
        'Dim sumacuaddon As Double = 0
        'Dim sumacuadafla As Double = 0
        'Dim sumacuadzeara As Double = 0
        'Dim sumacuadfibraefectiva As Double = 0
        'Dim sumacuadclostridios As Double = 0
        Dim restomsh As Double = 0
        Dim restocenizash As Double = 0
        Dim restocenizass As Double = 0
        Dim restopbh As Double = 0
        Dim restopbs As Double = 0
        Dim restofndh As Double = 0
        Dim restofnds As Double = 0
        Dim restofadh As Double = 0
        Dim restofads As Double = 0
        Dim restoenls As Double = 0
        Dim restoems As Double = 0
        Dim restofch As Double = 0
        Dim restofcs As Double = 0
        Dim restophh As Double = 0
        Dim restoeeh As Double = 0
        Dim restoees As Double = 0
        Dim restonidah As Double = 0
        'Dim restodon As Double = 0
        'Dim restoafla As Double = 0
        'Dim restozeara As Double = 0
        'Dim restofibraefectiva As Double = 0
        'Dim restoclostridios As Double = 0
        Dim desvestmsh As Double = 0
        Dim desvestcenizash As Double = 0
        Dim desvestcenizass As Double = 0
        Dim desvestpbh As Double = 0
        Dim desvestpbs As Double = 0
        Dim desvestfndh As Double = 0
        Dim desvestfnds As Double = 0
        Dim desvestfadh As Double = 0
        Dim desvestfads As Double = 0
        Dim desvestenls As Double = 0
        Dim desvestems As Double = 0
        Dim desvestfch As Double = 0
        Dim desvestfcs As Double = 0
        Dim desvestphh As Double = 0
        Dim desvesteeh As Double = 0
        Dim desvestees As Double = 0
        Dim desvestnidah As Double = 0
        'Dim desvestdon As Double = 0
        'Dim desvestafla As Double = 0
        'Dim desvestzeara As Double = 0
        'Dim desvestfibraefectiva As Double = 0
        'Dim desvestclostridios As Double = 0
        Dim medgeommsh As Double = 0
        Dim medgeomcenizash As Double = 0
        Dim medgeomcenizass As Double = 0
        Dim medgeompbh As Double = 0
        Dim medgeompbs As Double = 0
        Dim medgeomfndh As Double = 0
        Dim medgeomfnds As Double = 0
        Dim medgeomfadh As Double = 0
        Dim medgeomfads As Double = 0
        Dim medgeomenls As Double = 0
        Dim medgeomems As Double = 0
        Dim medgeomfch As Double = 0
        Dim medgeomfcs As Double = 0
        Dim medgeomphh As Double = 0
        Dim medgeomeeh As Double = 0
        Dim medgeomees As Double = 0
        Dim medgeomnidah As Double = 0
        'Dim medgeomdon As Double = 0
        'Dim medgeomafla As Double = 0
        'Dim medgeomzeara As Double = 0
        'Dim medgeomfibraefectiva As Double = 0
        'Dim medgeomclostridios As Double = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        'Dim idclase As dNutricionClase = CType(ComboClase.SelectedItem, dNutricionClase)
        'Dim idalimento As dNutricionAlimento = CType(ComboAlimento.SelectedItem, dNutricionAlimento)
        Dim idclase As New dNutricionClase
        Dim idalimento As New dNutricionAlimento
        idclase = CType(ComboClase.SelectedItem, dNutricionClase)
        idalimento = CType(ComboAlimento.SelectedItem, dNutricionAlimento)
        Dim lista As New ArrayList

        'If Not idclase Is Nothing Then
        '    If Not idalimento Is Nothing Then
        '        lista = n.listarxfechaxclasexalimento(fecdesde, fechasta, idclase.ID, idalimento.ID)
        '    Else
        '        lista = n.listarxfechaxclase(fecdesde, fechasta, idclase.ID)
        '    End If
        'Else
        '    lista = n.listarxfecha(fecdesde, fechasta)
        'End If

        If CheckClaseAlimento.Checked = True Then
            If ComboClase.Text <> "" Then
                If CheckAlimento.Checked = True Then
                    If ComboAlimento.Text <> "" Then
                        lista = n.listarxfechaxclasexalimento(fecdesde, fechasta, idclase.ID, idalimento.ID)
                    Else
                        MsgBox("Selecciones un alimento")
                    End If
                Else
                    lista = n.listarxfechaxclase(fecdesde, fechasta, idclase.ID)
                End If
            Else
                MsgBox("Selecciones una clase de alimento")
            End If
        Else
            lista = n.listarxfecha(fecdesde, fechasta)
        End If

        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim contador As Integer = lista.Count
                contador = contador + 4
                DataGridView1.Rows.Add(contador)
                For Each n In lista
                    DataGridView1(columna, fila).Value = n.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = n.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = n.FECHAINGRESO
                    columna = columna + 1
                    Dim c As New dNutricionClase
                    Dim a As New dNutricionAlimento
                    c.ID = n.CLASE
                    c = c.buscar
                    a.ID = n.ALIMENTO
                    a = a.buscar
                    If Not c Is Nothing Then
                        DataGridView1(columna, fila).Value = c.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If Not a Is Nothing Then
                        DataGridView1(columna, fila).Value = a.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.MSH <> -1 Then
                        DataGridView1(columna, fila).Value = n.MSH
                        columna = columna + 1
                        sumamsh = sumamsh + n.MSH
                        cuentamsh = cuentamsh + 1
                        productomsh = productomsh * n.MSH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.CENIZASH <> -1 Then
                        DataGridView1(columna, fila).Value = n.CENIZASH
                        columna = columna + 1
                        sumacenizash = sumacenizash + n.CENIZASH
                        cuentacenizash = cuentacenizash + 1
                        productocenizash = productocenizash * n.CENIZASH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.CENIZASS <> -1 Then
                        DataGridView1(columna, fila).Value = n.CENIZASS
                        columna = columna + 1
                        sumacenizass = sumacenizass + n.CENIZASS
                        cuentacenizass = cuentacenizass + 1
                        productocenizass = productocenizass * n.CENIZASS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.PBH <> -1 Then
                        DataGridView1(columna, fila).Value = n.PBH
                        columna = columna + 1
                        sumapbh = sumapbh + n.PBH
                        cuentapbh = cuentapbh + 1
                        productopbh = productopbh * n.PBH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.PBS <> -1 Then
                        DataGridView1(columna, fila).Value = n.PBS
                        columna = columna + 1
                        sumapbs = sumapbs + n.PBS
                        cuentapbs = cuentapbs + 1
                        productopbs = productopbs * n.PBS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.FNDH <> -1 Then
                        DataGridView1(columna, fila).Value = n.FNDH
                        columna = columna + 1
                        sumafndh = sumafndh + n.FNDH
                        cuentafndh = cuentafndh + 1
                        productofndh = productofndh * n.FNDH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.FNDS <> -1 Then
                        DataGridView1(columna, fila).Value = n.FNDS
                        columna = columna + 1
                        sumafnds = sumafnds + n.FNDS
                        cuentafnds = cuentafnds + 1
                        productofnds = productofnds * n.FNDS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.FADH <> -1 Then
                        DataGridView1(columna, fila).Value = n.FADH
                        columna = columna + 1
                        sumafadh = sumafadh + n.FADH
                        cuentafadh = cuentafadh + 1
                        productofadh = productofadh * n.FADH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.FADS <> -1 Then
                        DataGridView1(columna, fila).Value = n.FADS
                        columna = columna + 1
                        sumafads = sumafads + n.FADS
                        cuentafads = cuentafads + 1
                        productofads = productofads * n.FADS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.ENLS <> -1 Then
                        DataGridView1(columna, fila).Value = n.ENLS
                        columna = columna + 1
                        sumaenls = sumaenls + n.ENLS
                        cuentaenls = cuentaenls + 1
                        productoenls = productoenls * n.ENLS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.EMS <> -1 Then
                        DataGridView1(columna, fila).Value = n.EMS
                        columna = columna + 1
                        sumaems = sumaems + n.EMS
                        cuentaems = cuentaems + 1
                        productoems = productoems * n.EMS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.FCH <> -1 Then
                        DataGridView1(columna, fila).Value = n.FCH
                        columna = columna + 1
                        sumafch = sumafch + n.FCH
                        cuentafch = cuentafch + 1
                        productofch = productofch * n.FCH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.FCS <> -1 Then
                        DataGridView1(columna, fila).Value = n.FCS
                        columna = columna + 1
                        sumafcs = sumafcs + n.FCS
                        cuentafcs = cuentafcs + 1
                        productofcs = productofcs * n.FCS
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.PHH <> -1 Then
                        DataGridView1(columna, fila).Value = n.PHH
                        columna = columna + 1
                        sumaphh = sumaphh + n.PHH
                        cuentaphh = cuentaphh + 1
                        productophh = productophh * n.PHH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.EEH <> -1 Then
                        DataGridView1(columna, fila).Value = n.EEH
                        columna = columna + 1
                        sumaeeh = sumaeeh + n.EEH
                        cuentaeeh = cuentaeeh + 1
                        productoeeh = productoeeh * n.EEH
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.EES <> -1 Then
                        DataGridView1(columna, fila).Value = n.EES
                        columna = columna + 1
                        sumaees = sumaees + n.EES
                        cuentaees = cuentaees + 1
                        productoees = productoees * n.EES
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = columna + 1
                    End If
                    If n.NIDAH <> -1 Then
                        DataGridView1(columna, fila).Value = n.NIDAH
                        columna = 0
                        sumanidah = sumanidah + n.NIDAH
                        cuentanidah = cuentanidah + 1
                        productonidah = productonidah * n.NIDAH
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "-"
                        columna = 0
                        fila = fila + 1
                    End If
                    'If n.DON <> "-1" Then
                    '    DataGridView1(columna, fila).Value = n.DON
                    '    columna = 0
                    '    sumadon = sumadon + n.DON
                    '    cuentadon = cuentadon + 1
                    '    productodon = productodon * n.DON
                    '    fila = fila + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "-"
                    '    columna = 0
                    '    fila = fila + 1
                    'End If
                    'If n.AFLA <> "-1" Then
                    '    DataGridView1(columna, fila).Value = n.AFLA
                    '    columna = 0
                    '    sumaafla = sumaafla + n.AFLA
                    '    cuentaafla = cuentaafla + 1
                    '    productoafla = productoafla * n.AFLA
                    '    fila = fila + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "-"
                    '    columna = 0
                    '    fila = fila + 1
                    'End If
                    'If n.ZEARA <> "-1" Then
                    '    DataGridView1(columna, fila).Value = n.ZEARA
                    '    columna = 0
                    '    sumazeara = sumazeara + n.ZEARA
                    '    cuentazeara = cuentazeara + 1
                    '    productozeara = productozeara * n.ZEARA
                    '    fila = fila + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "-"
                    '    columna = 0
                    '    fila = fila + 1
                    'End If
                    'If n.FIBRAEFECTIVA <> "-1" Then
                    '    DataGridView1(columna, fila).Value = n.FIBRAEFECTIVA
                    '    columna = 0
                    '    sumafibraefectiva = sumafibraefectiva + n.FIBRAEFECTIVA
                    '    cuentafibraefectiva = cuentafibraefectiva + 1
                    '    productofibraefectiva = productofibraefectiva * n.FIBRAEFECTIVA
                    '    fila = fila + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "-"
                    '    columna = 0
                    '    fila = fila + 1
                    'End If
                    'If n.CLOSTRIDIOS <> "-1" Then
                    '    DataGridView1(columna, fila).Value = n.CLOSTRIDIOS
                    '    columna = 0
                    '    sumaclostridios = sumaclostridios + n.CLOSTRIDIOS
                    '    cuentaclostridios = cuentaclostridios + 1
                    '    productoclostridios = productoclostridios * n.CLOSTRIDIOS
                    '    fila = fila + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "-"
                    '    columna = 0
                    '    fila = fila + 1
                    'End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                If sumamsh <> 0 And cuentamsh <> 0 Then
                    mediamsh = sumamsh / cuentamsh
                End If
                If sumacenizash <> 0 And cuentacenizash <> 0 Then
                    mediacenizash = sumacenizash / cuentacenizash
                End If
                If sumacenizass <> 0 And cuentacenizass <> 0 Then
                    mediacenizass = sumacenizass / cuentacenizass
                End If
                If sumapbh <> 0 And cuentapbh <> 0 Then
                    mediapbh = sumapbh / cuentapbh
                End If
                If sumapbs <> 0 And cuentapbs <> 0 Then
                    mediapbs = sumapbs / cuentapbs
                End If
                If sumafndh <> 0 And cuentafndh <> 0 Then
                    mediafndh = sumafndh / cuentafndh
                End If
                If sumafnds <> 0 And cuentafnds <> 0 Then
                    mediafnds = sumafnds / cuentafnds
                End If
                If sumafadh <> 0 And cuentafadh <> 0 Then
                    mediafadh = sumafadh / cuentafadh
                End If
                If sumafads <> 0 And cuentafads <> 0 Then
                    mediafads = sumafads / cuentafads
                End If
                If sumaenls <> 0 And cuentaenls <> 0 Then
                    mediaenls = sumaenls / cuentaenls
                End If
                If sumaems <> 0 And cuentaems <> 0 Then
                    mediaems = sumaems / cuentaems
                End If
                If sumafch <> 0 And cuentafch <> 0 Then
                    mediafch = sumafch / cuentafch
                End If
                If sumafcs <> 0 And cuentafcs <> 0 Then
                    mediafcs = sumafcs / cuentafcs
                End If
                If sumaphh <> 0 And cuentaphh <> 0 Then
                    mediaphh = sumaphh / cuentaphh
                End If
                If sumaeeh <> 0 And cuentaeeh <> 0 Then
                    mediaeeh = sumaeeh / cuentaeeh
                End If
                If sumaees <> 0 And cuentaees <> 0 Then
                    mediaees = sumaees / cuentaees
                End If
                If sumanidah <> 0 And cuentanidah <> 0 Then
                    medianidah = sumanidah / cuentanidah
                End If
                'If sumadon <> 0 And cuentadon <> 0 Then
                '    mediadon = sumadon / cuentadon
                'End If
                'If sumaafla <> 0 And cuentaafla <> 0 Then
                '    mediaafla = sumaafla / cuentaafla
                'End If
                'If sumazeara <> 0 And cuentazeara <> 0 Then
                '    mediazeara = sumazeara / cuentazeara
                'End If
                'If sumafibraefectiva <> 0 And cuentafibraefectiva <> 0 Then
                '    mediafibraefectiva = sumafibraefectiva / cuentafibraefectiva
                'End If
                'If sumaclostridios <> 0 And cuentaclostridios <> 0 Then
                '    mediaclostridios = sumaclostridios / cuentaclostridios
                'End If
                For Each n In lista
                    If n.MSH <> -1 Then
                        desvmsh = n.MSH - mediamsh
                        cuadmsh = desvmsh * desvmsh
                        sumacuadmsh = sumacuadmsh + cuadmsh
                    End If
                    If n.CENIZASH <> -1 Then
                        desvcenizash = n.CENIZASH - mediacenizash
                        cuadcenizash = desvcenizash * desvcenizash
                        sumacuadcenizash = sumacuadcenizash + cuadcenizash
                    End If
                    If n.CENIZASS <> -1 Then
                        desvcenizass = n.CENIZASS - mediacenizass
                        cuadcenizass = desvcenizass * desvcenizass
                        sumacuadcenizass = sumacuadcenizass + cuadcenizass
                    End If
                    If n.PBH <> -1 Then
                        desvpbh = n.PBH - mediapbh
                        cuadpbh = desvpbh * desvpbh
                        sumacuadpbh = sumacuadpbh + cuadpbh
                    End If
                    If n.PBS <> -1 Then
                        desvpbs = n.PBS - mediapbs
                        cuadpbs = desvpbs * desvpbs
                        sumacuadpbs = sumacuadpbs + cuadpbs
                    End If
                    If n.FNDH <> -1 Then
                        desvfndh = n.FNDH - mediafndh
                        cuadfndh = desvfndh * desvfndh
                        sumacuadfndh = sumacuadfndh + cuadfndh
                    End If
                    If n.FNDS <> -1 Then
                        desvfnds = n.FNDS - mediafnds
                        cuadfnds = desvfnds * desvfnds
                        sumacuadfnds = sumacuadfnds + cuadfnds
                    End If
                    If n.FADH <> -1 Then
                        desvfadh = n.FADH - mediafadh
                        cuadfadh = desvfadh * desvfadh
                        sumacuadfadh = sumacuadfadh + cuadfadh
                    End If
                    If n.FADS <> -1 Then
                        desvfads = n.FADS - mediafads
                        cuadfads = desvfads * desvfads
                        sumacuadfads = sumacuadfads + cuadfads
                    End If
                    If n.ENLS <> -1 Then
                        desvenls = n.ENLS - mediaenls
                        cuadenls = desvenls * desvenls
                        sumacuadenls = sumacuadenls + cuadenls
                    End If
                    If n.EMS <> -1 Then
                        desvems = n.EMS - mediaems
                        cuadems = desvems * desvems
                        sumacuadems = sumacuadems + cuadems
                    End If
                    If n.FCH <> -1 Then
                        desvfch = n.FCH - mediafch
                        cuadfch = desvfch * desvfch
                        sumacuadfch = sumacuadfch + cuadfch
                    End If
                    If n.FCS <> -1 Then
                        desvfcs = n.FCS - mediafcs
                        cuadfcs = desvfcs * desvfcs
                        sumacuadfcs = sumacuadfcs + cuadfcs
                    End If
                    If n.PHH <> -1 Then
                        desvphh = n.PHH - mediaphh
                        cuadphh = desvphh * desvphh
                        sumacuadphh = sumacuadphh + cuadphh
                    End If
                    If n.EEH <> -1 Then
                        desveeh = n.EEH - mediaeeh
                        cuadeeh = desveeh * desveeh
                        sumacuadeeh = sumacuadeeh + cuadeeh
                    End If
                    If n.EES <> -1 Then
                        desvees = n.EES - mediaees
                        cuadees = desvees * desvees
                        sumacuadees = sumacuadees + cuadees
                    End If
                    If n.NIDAH <> -1 Then
                        desvnidah = n.NIDAH - medianidah
                        cuadnidah = desvnidah * desvnidah
                        sumacuadnidah = sumacuadnidah + cuadnidah
                    End If
                    'If n.DON <> "-1" Then
                    '    desvdon = n.DON - mediadon
                    '    cuaddon = desvdon * desvdon
                    '    sumacuaddon = sumacuaddon + cuaddon
                    'End If
                    'If n.AFLA <> "-1" Then
                    '    desvafla = n.AFLA - mediaafla
                    '    cuadafla = desvafla * desvafla
                    '    sumacuadafla = sumacuadafla + cuadafla
                    'End If
                    'If n.ZEARA <> "-1" Then
                    '    desvzeara = n.ZEARA - mediazeara
                    '    cuadzeara = desvzeara * desvzeara
                    '    sumacuadzeara = sumacuadzeara + cuadzeara
                    'End If
                    'If n.FIBRAEFECTIVA <> "-1" Then
                    '    desvfibraefectiva = n.FIBRAEFECTIVA - mediafibraefectiva
                    '    cuadfibraefectiva = desvfibraefectiva * desvfibraefectiva
                    '    sumacuadfibraefectiva = sumacuadfibraefectiva + cuadfibraefectiva
                    'End If
                    'If n.CLOSTRIDIOS <> "-1" Then
                    '    desvclostridios = n.CLOSTRIDIOS - mediaclostridios
                    '    cuadclostridios = desvclostridios * desvclostridios
                    '    sumacuadclostridios = sumacuadclostridios + cuadclostridios
                    'End If
                Next
                If sumacuadmsh > 0 Then
                    restomsh = sumacuadmsh / (cuentamsh - 1)
                End If
                If sumacuadcenizash > 0 Then
                    restocenizash = sumacuadcenizash / (cuentacenizash - 1)
                End If
                If sumacuadcenizass > 0 Then
                    restocenizass = sumacuadcenizass / (cuentacenizass - 1)
                End If
                If sumacuadpbh > 0 Then
                    restopbh = sumacuadpbh / (cuentapbh - 1)
                End If
                If sumacuadpbs > 0 Then
                    restopbs = sumacuadpbs / (cuentapbs - 1)
                End If
                If sumacuadfndh > 0 Then
                    restofndh = sumacuadfndh / (cuentafndh - 1)
                End If
                If sumacuadfnds > 0 Then
                    restofnds = sumacuadfnds / (cuentafnds - 1)
                End If
                If sumacuadfadh > 0 Then
                    restofadh = sumacuadfadh / (cuentafadh - 1)
                End If
                If sumacuadfads > 0 Then
                    restofads = sumacuadfads / (cuentafads - 1)
                End If
                If sumacuadenls > 0 Then
                    restoenls = sumacuadenls / (cuentaenls - 1)
                End If
                If sumacuadems > 0 Then
                    restoems = sumacuadems / (cuentaems - 1)
                End If
                If sumacuadfch > 0 Then
                    restofch = sumacuadfch / (cuentafch - 1)
                End If
                If sumacuadfcs > 0 Then
                    restofcs = sumacuadfcs / (cuentafcs - 1)
                End If
                If sumacuadphh > 0 Then
                    restophh = sumacuadphh / (cuentaphh - 1)
                End If
                If sumacuadeeh > 0 Then
                    restoeeh = sumacuadeeh / (cuentaeeh - 1)
                End If
                If sumacuadees > 0 Then
                    restoees = sumacuadees / (cuentaees - 1)
                End If
                If sumacuadnidah > 0 Then
                    restonidah = sumacuadnidah / (cuentanidah - 1)
                End If
                'If sumacuaddon > 0 Then
                '    restodon = sumacuaddon / (cuentadon - 1)
                'End If
                'If sumacuadafla > 0 Then
                '    restoafla = sumacuadafla / (cuentaafla - 1)
                'End If
                'If sumacuadzeara > 0 Then
                '    restozeara = sumacuadzeara / (cuentazeara - 1)
                'End If
                'If sumacuadfibraefectiva > 0 Then
                '    restofibraefectiva = sumacuadfibraefectiva / (cuentafibraefectiva - 1)
                'End If
                'If sumacuadclostridios > 0 Then
                '    restoclostridios = sumacuadclostridios / (cuentaclostridios - 1)
                'End If
                If restomsh > 0 Then
                    desvestmsh = Math.Sqrt(restomsh)
                End If
                If restocenizash > 0 Then
                    desvestcenizash = Math.Sqrt(restocenizash)
                End If
                If restocenizass > 0 Then
                    desvestcenizass = Math.Sqrt(restocenizass)
                End If
                If restopbh > 0 Then
                    desvestpbh = Math.Sqrt(restopbh)
                End If
                If restopbs > 0 Then
                    desvestpbs = Math.Sqrt(restopbs)
                End If
                If restofndh > 0 Then
                    desvestfndh = Math.Sqrt(restofndh)
                End If
                If restofnds > 0 Then
                    desvestfnds = Math.Sqrt(restofnds)
                End If
                If restofadh > 0 Then
                    desvestfadh = Math.Sqrt(restofadh)
                End If
                If restofads > 0 Then
                    desvestfads = Math.Sqrt(restofads)
                End If
                If restoenls > 0 Then
                    desvestenls = Math.Sqrt(restoenls)
                End If
                If restoems > 0 Then
                    desvestems = Math.Sqrt(restoems)
                End If
                If restofch > 0 Then
                    desvestfch = Math.Sqrt(restofch)
                End If
                If restofcs > 0 Then
                    desvestfcs = Math.Sqrt(restofcs)
                End If
                If restophh > 0 Then
                    desvestphh = Math.Sqrt(restophh)
                End If
                If restoeeh > 0 Then
                    desvesteeh = Math.Sqrt(restoeeh)
                End If
                If restoees > 0 Then
                    desvestees = Math.Sqrt(restoees)
                End If
                If restonidah > 0 Then
                    desvestnidah = Math.Sqrt(restonidah)
                End If
                'If restodon > 0 Then
                '    desvestdon = Math.Sqrt(restodon)
                'End If
                'If restoafla > 0 Then
                '    desvestafla = Math.Sqrt(restoafla)
                'End If
                'If restozeara > 0 Then
                '    desvestzeara = Math.Sqrt(restozeara)
                'End If
                'If restofibraefectiva > 0 Then
                '    desvestfibraefectiva = Math.Sqrt(restofibraefectiva)
                'End If
                'If restoclostridios > 0 Then
                '    desvestclostridios = Math.Sqrt(restoclostridios)
                'End If
                medgeommsh = productomsh ^ (1 / cuentamsh)
                medgeomcenizash = productocenizash ^ (1 / cuentacenizash)
                medgeomcenizass = productocenizass ^ (1 / cuentacenizass)
                medgeompbh = productopbh ^ (1 / cuentapbh)
                medgeompbs = productopbs ^ (1 / cuentapbs)
                medgeomfndh = productofndh ^ (1 / cuentafndh)
                medgeomfnds = productofnds ^ (1 / cuentafnds)
                medgeomfadh = productofadh ^ (1 / cuentafadh)
                medgeomfads = productofads ^ (1 / cuentafads)
                medgeomenls = productoenls ^ (1 / cuentaenls)
                medgeomems = productoems ^ (1 / cuentaems)
                medgeomfch = productofch ^ (1 / cuentafch)
                medgeomfcs = productofcs ^ (1 / cuentafcs)
                medgeomphh = productophh ^ (1 / cuentaphh)
                medgeomeeh = productoeeh ^ (1 / cuentaeeh)
                medgeomees = productoees ^ (1 / cuentaees)
                medgeomnidah = productonidah ^ (1 / cuentanidah)
                'medgeomdon = productodon ^ (1 / cuentadon)
                'medgeomafla = productoafla ^ (1 / cuentaafla)
                'medgeomzeara = productozeara ^ (1 / cuentazeara)
                'medgeomfibraefectiva = productofibraefectiva ^ (1 / cuentafibraefectiva)
                'medgeomclostridios = productoclostridios ^ (1 / cuentaclostridios)
                columna = 1
                fila = fila + 1
                DataGridView1(columna, fila).Value = "Promedio"
                columna = columna + 2
                If mediamsh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediamsh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediacenizash <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediacenizash, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediacenizass <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediacenizass, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediapbh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediapbh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediapbs <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediapbs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafndh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafndh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafnds <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafnds, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafadh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafadh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafads <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafads, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaenls <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaenls, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaems <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaems, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafch <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafch, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafcs <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediafcs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaphh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaphh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaeeh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaeeh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaees <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(mediaees, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medianidah <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(medianidah, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                'If mediadon <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(mediadon, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If mediaafla <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(mediaafla, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If mediazeara <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(mediazeara, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If mediafibraefectiva <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(mediafibraefectiva, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If mediaclostridios <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(mediaclostridios, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If

                DataGridView1(columna, fila).Value = "Desv. Estándar"
                columna = columna + 2
                If desvestmsh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestmsh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestcenizash <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestcenizash, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestcenizass <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestcenizass, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestpbh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestpbh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestpbs <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestpbs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfndh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfndh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfnds <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfnds, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfadh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfadh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfads <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfads, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestenls <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestenls, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestems <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestems, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfch <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfch, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfcs <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestfcs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestphh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestphh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvesteeh <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvesteeh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestees <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestees, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestnidah <> 0 Then
                    DataGridView1(columna, fila).Value = Math.Round(desvestnidah, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                'If desvestdon <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(desvestdon, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If desvestafla <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(desvestafla, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If desvestzeara <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(desvestzeara, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If desvestfibraefectiva <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(desvestfibraefectiva, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If
                'If desvestclostridios <> 0 Then
                '    DataGridView1(columna, fila).Value = Math.Round(desvestclostridios, 2)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 1
                '    fila = fila + 1
                'End If

                DataGridView1(columna, fila).Value = "Media geom."
                columna = columna + 2
                If medgeommsh <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeommsh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomcenizash <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomcenizash, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomcenizass <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomcenizass, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeompbh <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeompbh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeompbs <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeompbs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfndh <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfndh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfnds <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfnds, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfadh <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfadh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfads <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfads, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomenls <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomenls, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomems <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomems, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfch <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfch, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfcs <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomfcs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomphh <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomphh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomeeh <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomeeh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomees <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomees, 2)
                    columna = columna + 1
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomnidah <> 1 Then
                    DataGridView1(columna, fila).Value = Math.Round(medgeomnidah, 2)
                    columna = 0
                Else
                    DataGridView1(columna, fila).Value = "-"
                    columna = 0
                End If
                'If medgeomdon <> 1 Then
                '    DataGridView1(columna, fila).Value = Math.Round(medgeomdon, 2)
                '    columna = 0
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 0
                'End If
                'If medgeomafla <> 1 Then
                '    DataGridView1(columna, fila).Value = Math.Round(medgeomafla, 2)
                '    columna = 0
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 0
                'End If
                'If medgeomzeara <> 1 Then
                '    DataGridView1(columna, fila).Value = Math.Round(medgeomzeara, 2)
                '    columna = 0
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 0
                'End If
                'If medgeomfibraefectiva <> 1 Then
                '    DataGridView1(columna, fila).Value = Math.Round(medgeomfibraefectiva, 2)
                '    columna = 0
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 0
                'End If
                'If medgeomclostridios <> 1 Then
                '    DataGridView1(columna, fila).Value = Math.Round(medgeomclostridios, 2)
                '    columna = 0
                'Else
                '    DataGridView1(columna, fila).Value = "-"
                '    columna = 0

                'End If
            End If
        End If
    End Sub

    Private Sub ButtonListarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportar.Click
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10
        x1hoja.Cells(1, 5).columnwidth = 10
        x1hoja.Cells(1, 6).columnwidth = 10
        x1hoja.Cells(1, 7).columnwidth = 10
        x1hoja.Cells(1, 8).columnwidth = 10
        x1hoja.Cells(1, 9).columnwidth = 10
        x1hoja.Cells(1, 10).columnwidth = 10
        x1hoja.Cells(1, 11).columnwidth = 10
        x1hoja.Cells(1, 12).columnwidth = 10
        x1hoja.Cells(1, 13).columnwidth = 10
        x1hoja.Cells(1, 14).columnwidth = 10
        x1hoja.Cells(1, 15).columnwidth = 10
        x1hoja.Cells(1, 16).columnwidth = 10
        x1hoja.Cells(1, 17).columnwidth = 10
        x1hoja.Cells(1, 18).columnwidth = 10
        x1hoja.Cells(1, 19).columnwidth = 10
        x1hoja.Cells(1, 20).columnwidth = 10
        x1hoja.Cells(1, 21).columnwidth = 10
        x1hoja.Cells(1, 22).columnwidth = 10
        x1hoja.Cells(1, 23).columnwidth = 10
        x1hoja.Cells(1, 24).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        x1hoja.Cells(fila, columna).formula = "ESTADÍSTICAS DE NUTRICIÓN" & "  -  " & fecdesde & " - " & fechasta
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Clase"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Alimento"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% MS 105ºC"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% Cenizas(H)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% Cenizas(S)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% PB(H)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% PB(S)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% FND(H)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% FND(S)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% FAD(H)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% FAD(S)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "ENL(Mcal/Kg MS)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "EM(Mcal/Kg MS)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% FC(H)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% FC(S)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "pH"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% EE(H)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% EE(S)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "% NIDA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "DON"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "AFLA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "ZEARA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "FIBRA EFECTIVA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "CLOSTRIDIOS"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 1
        columna = 1

        Dim n As New dNutricion
        Dim sumamsh As Double = 0
        Dim sumacenizash As Double = 0
        Dim sumacenizass As Double = 0
        Dim sumapbh As Double = 0
        Dim sumapbs As Double = 0
        Dim sumafndh As Double = 0
        Dim sumafnds As Double = 0
        Dim sumafadh As Double = 0
        Dim sumafads As Double = 0
        Dim sumaenls As Double = 0
        Dim sumaems As Double = 0
        Dim sumafch As Double = 0
        Dim sumafcs As Double = 0
        Dim sumaphh As Double = 0
        Dim sumaeeh As Double = 0
        Dim sumaees As Double = 0
        Dim sumanidah As Double = 0
        'Dim sumadon As Double = 0
        'Dim sumaafla As Double = 0
        'Dim sumazeara As Double = 0
        'Dim sumafibraefectiva As Double = 0
        'Dim sumaclostridios As Double = 0
        Dim cuentamsh As Integer = 0
        Dim cuentacenizash As Integer = 0
        Dim cuentacenizass As Integer = 0
        Dim cuentapbh As Integer = 0
        Dim cuentapbs As Integer = 0
        Dim cuentafndh As Integer = 0
        Dim cuentafnds As Integer = 0
        Dim cuentafadh As Integer = 0
        Dim cuentafads As Integer = 0
        Dim cuentaenls As Integer = 0
        Dim cuentaems As Integer = 0
        Dim cuentafch As Integer = 0
        Dim cuentafcs As Integer = 0
        Dim cuentaphh As Integer = 0
        Dim cuentaeeh As Integer = 0
        Dim cuentaees As Integer = 0
        Dim cuentanidah As Integer = 0
        'Dim cuentadon As Integer = 0
        'Dim cuentaafla As Integer = 0
        'Dim cuentazeara As Integer = 0
        'Dim cuentafibraefectiva As Integer = 0
        'Dim cuentaclostridios As Integer = 0
        Dim productomsh As Double = 1
        Dim productocenizash As Double = 1
        Dim productocenizass As Double = 1
        Dim productopbh As Double = 1
        Dim productopbs As Double = 1
        Dim productofndh As Double = 1
        Dim productofnds As Double = 1
        Dim productofadh As Double = 1
        Dim productofads As Double = 1
        Dim productoenls As Double = 1
        Dim productoems As Double = 1
        Dim productofch As Double = 1
        Dim productofcs As Double = 1
        Dim productophh As Double = 1
        Dim productoeeh As Double = 1
        Dim productoees As Double = 1
        Dim productonidah As Double = 1
        'Dim productodon As Double = 1
        'Dim productoafla As Double = 1
        'Dim productozeara As Double = 1
        'Dim productofibraefectiva As Double = 1
        'Dim productoclostridios As Double = 1
        Dim mediamsh As Double = 0
        Dim mediacenizash As Double = 0
        Dim mediacenizass As Double = 0
        Dim mediapbh As Double = 0
        Dim mediapbs As Double = 0
        Dim mediafndh As Double = 0
        Dim mediafnds As Double = 0
        Dim mediafads As Double = 0
        Dim mediafadh As Double = 0
        Dim mediaenls As Double = 0
        Dim mediaems As Double = 0
        Dim mediafch As Double = 0
        Dim mediafcs As Double = 0
        Dim mediaphh As Double = 0
        Dim mediaeeh As Double = 0
        Dim mediaees As Double = 0
        Dim medianidah As Double = 0
        'Dim mediadon As Double = 0
        'Dim mediaafla As Double = 0
        'Dim mediazeara As Double = 0
        'Dim mediafibraefectiva As Double = 0
        'Dim mediaclostridios As Double = 0
        Dim desvmsh As Double = 0
        Dim desvcenizash As Double = 0
        Dim desvcenizass As Double = 0
        Dim desvpbh As Double = 0
        Dim desvpbs As Double = 0
        Dim desvfndh As Double = 0
        Dim desvfnds As Double = 0
        Dim desvfads As Double = 0
        Dim desvfadh As Double = 0
        Dim desvenls As Double = 0
        Dim desvems As Double = 0
        Dim desvfch As Double = 0
        Dim desvfcs As Double = 0
        Dim desvphh As Double = 0
        Dim desveeh As Double = 0
        Dim desvees As Double = 0
        Dim desvnidah As Double = 0
        'Dim desvdon As Double = 0
        'Dim desvafla As Double = 0
        'Dim desvzeara As Double = 0
        'Dim desvfibraefectiva As Double = 0
        'Dim desvclostridios As Double = 0
        Dim cuadmsh As Double = 0
        Dim cuadcenizash As Double = 0
        Dim cuadcenizass As Double = 0
        Dim cuadpbh As Double = 0
        Dim cuadpbs As Double = 0
        Dim cuadfndh As Double = 0
        Dim cuadfnds As Double = 0
        Dim cuadfads As Double = 0
        Dim cuadfadh As Double = 0
        Dim cuadenls As Double = 0
        Dim cuadems As Double = 0
        Dim cuadfch As Double = 0
        Dim cuadfcs As Double = 0
        Dim cuadphh As Double = 0
        Dim cuadeeh As Double = 0
        Dim cuadees As Double = 0
        Dim cuadnidah As Double = 0
        'Dim cuaddon As Double = 0
        'Dim cuadafla As Double = 0
        'Dim cuadzeara As Double = 0
        'Dim cuadfibraefectiva As Double = 0
        'Dim cuadclostridios As Double = 0
        Dim sumacuadmsh As Double = 0
        Dim sumacuadcenizash As Double = 0
        Dim sumacuadcenizass As Double = 0
        Dim sumacuadpbh As Double = 0
        Dim sumacuadpbs As Double = 0
        Dim sumacuadfndh As Double = 0
        Dim sumacuadfnds As Double = 0
        Dim sumacuadfads As Double = 0
        Dim sumacuadfadh As Double = 0
        Dim sumacuadenls As Double = 0
        Dim sumacuadems As Double = 0
        Dim sumacuadfch As Double = 0
        Dim sumacuadfcs As Double = 0
        Dim sumacuadphh As Double = 0
        Dim sumacuadeeh As Double = 0
        Dim sumacuadees As Double = 0
        Dim sumacuadnidah As Double = 0
        'Dim sumacuaddon As Double = 0
        'Dim sumacuadafla As Double = 0
        'Dim sumacuadzeara As Double = 0
        'Dim sumacuadfibraefectiva As Double = 0
        'Dim sumacuadclostridios As Double = 0
        Dim restomsh As Double = 0
        Dim restocenizash As Double = 0
        Dim restocenizass As Double = 0
        Dim restopbh As Double = 0
        Dim restopbs As Double = 0
        Dim restofndh As Double = 0
        Dim restofnds As Double = 0
        Dim restofadh As Double = 0
        Dim restofads As Double = 0
        Dim restoenls As Double = 0
        Dim restoems As Double = 0
        Dim restofch As Double = 0
        Dim restofcs As Double = 0
        Dim restophh As Double = 0
        Dim restoeeh As Double = 0
        Dim restoees As Double = 0
        Dim restonidah As Double = 0
        'Dim restodon As Double = 0
        'Dim restoafla As Double = 0
        'Dim restozeara As Double = 0
        'Dim restofibraefectiva As Double = 0
        'Dim restoclostridios As Double = 0
        Dim desvestmsh As Double = 0
        Dim desvestcenizash As Double = 0
        Dim desvestcenizass As Double = 0
        Dim desvestpbh As Double = 0
        Dim desvestpbs As Double = 0
        Dim desvestfndh As Double = 0
        Dim desvestfnds As Double = 0
        Dim desvestfadh As Double = 0
        Dim desvestfads As Double = 0
        Dim desvestenls As Double = 0
        Dim desvestems As Double = 0
        Dim desvestfch As Double = 0
        Dim desvestfcs As Double = 0
        Dim desvestphh As Double = 0
        Dim desvesteeh As Double = 0
        Dim desvestees As Double = 0
        Dim desvestnidah As Double = 0
        'Dim desvestdon As Double = 0
        'Dim desvestafla As Double = 0
        'Dim desvestzeara As Double = 0
        'Dim desvestfibraefectiva As Double = 0
        'Dim desvestclostridios As Double = 0
        Dim medgeommsh As Double = 0
        Dim medgeomcenizash As Double = 0
        Dim medgeomcenizass As Double = 0
        Dim medgeompbh As Double = 0
        Dim medgeompbs As Double = 0
        Dim medgeomfndh As Double = 0
        Dim medgeomfnds As Double = 0
        Dim medgeomfadh As Double = 0
        Dim medgeomfads As Double = 0
        Dim medgeomenls As Double = 0
        Dim medgeomems As Double = 0
        Dim medgeomfch As Double = 0
        Dim medgeomfcs As Double = 0
        Dim medgeomphh As Double = 0
        Dim medgeomeeh As Double = 0
        Dim medgeomees As Double = 0
        Dim medgeomnidah As Double = 0
        'Dim medgeomdon As Double = 0
        'Dim medgeomafla As Double = 0
        'Dim medgeomzeara As Double = 0
        'Dim medgeomfibraefectiva As Double = 0
        'Dim medgeomclostridios As Double = 0
       
        'Dim idclase As dNutricionClase = CType(ComboClase.SelectedItem, dNutricionClase)
        'Dim idalimento As dNutricionAlimento = CType(ComboAlimento.SelectedItem, dNutricionAlimento)

        Dim idclase As New dNutricionClase
        Dim idalimento As New dNutricionAlimento
        idclase = CType(ComboClase.SelectedItem, dNutricionClase)
        idalimento = CType(ComboAlimento.SelectedItem, dNutricionAlimento)

        Dim lista As New ArrayList
        'lista = n.listarxfechaxclasexalimento(fecdesde, fechasta, idclase.ID, idalimento.ID)

        'If Not idclase Is Nothing Then
        '    If Not idalimento Is Nothing Then
        '        lista = n.listarxfechaxclasexalimento(fecdesde, fechasta, idclase.ID, idalimento.ID)
        '    Else
        '        lista = n.listarxfechaxclase(fecdesde, fechasta, idclase.ID)
        '    End If
        'Else
        '    lista = n.listarxfecha(fecdesde, fechasta)
        'End If

        If CheckClaseAlimento.Checked = True Then
            If ComboClase.Text <> "" Then
                If CheckAlimento.Checked = True Then
                    If ComboAlimento.Text <> "" Then
                        lista = n.listarxfechaxclasexalimento(fecdesde, fechasta, idclase.ID, idalimento.ID)
                    Else
                        MsgBox("Selecciones un alimento")
                    End If
                Else
                    lista = n.listarxfechaxclase(fecdesde, fechasta, idclase.ID)
                End If
            Else
                MsgBox("Selecciones una clase de alimento")
            End If
        Else
            lista = n.listarxfecha(fecdesde, fechasta)
        End If


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    Dim c As New dNutricionClase
                    Dim a As New dNutricionAlimento
                    c.ID = n.CLASE
                    c = c.buscar
                    a.ID = n.ALIMENTO
                    a = a.buscar
                    If Not c Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = c.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If Not a Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = a.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.MSH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.MSH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumamsh = sumamsh + n.MSH
                        cuentamsh = cuentamsh + 1
                        productomsh = productomsh * n.MSH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.CENIZASH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.CENIZASH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumacenizash = sumacenizash + n.CENIZASH
                        cuentacenizash = cuentacenizash + 1
                        productocenizash = productocenizash * n.CENIZASH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.CENIZASS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.CENIZASS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumacenizass = sumacenizass + n.CENIZASS
                        cuentacenizass = cuentacenizass + 1
                        productocenizass = productocenizass * n.CENIZASS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.PBH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.PBH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumapbh = sumapbh + n.PBH
                        cuentapbh = cuentapbh + 1
                        productopbh = productopbh * n.PBH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.PBS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.PBS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumapbs = sumapbs + n.PBS
                        cuentapbs = cuentapbs + 1
                        productopbs = productopbs * n.PBS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.FNDH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.FNDH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafndh = sumafndh + n.FNDH
                        cuentafndh = cuentafndh + 1
                        productofndh = productofndh * n.FNDH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.FNDS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.FNDS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafnds = sumafnds + n.FNDS
                        cuentafnds = cuentafnds + 1
                        productofnds = productofnds * n.FNDS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.FADH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.FADH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafadh = sumafadh + n.FADH
                        cuentafadh = cuentafadh + 1
                        productofadh = productofadh * n.FADH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.FADS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.FADS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafads = sumafads + n.FADS
                        cuentafads = cuentafads + 1
                        productofads = productofads * n.FADS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.ENLS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.ENLS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaenls = sumaenls + n.ENLS
                        cuentaenls = cuentaenls + 1
                        productoenls = productoenls * n.ENLS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.EMS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.EMS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaems = sumaems + n.EMS
                        cuentaems = cuentaems + 1
                        productoems = productoems * n.EMS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.FCH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.FCH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafch = sumafch + n.FCH
                        cuentafch = cuentafch + 1
                        productofch = productofch * n.FCH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.FCS <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.FCS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumafcs = sumafcs + n.FCS
                        cuentafcs = cuentafcs + 1
                        productofcs = productofcs * n.FCS
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.PHH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.PHH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaphh = sumaphh + n.PHH
                        cuentaphh = cuentaphh + 1
                        productophh = productophh * n.PHH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.EEH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.EEH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaeeh = sumaeeh + n.EEH
                        cuentaeeh = cuentaeeh + 1
                        productoeeh = productoeeh * n.EEH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.EES <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.EES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumaees = sumaees + n.EES
                        cuentaees = cuentaees + 1
                        productoees = productoees * n.EES
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.NIDAH <> -1 Then
                        x1hoja.Cells(fila, columna).formula = n.NIDAH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        sumanidah = sumanidah + n.NIDAH
                        cuentanidah = cuentanidah + 1
                        productonidah = productonidah * n.NIDAH
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.DON <> "-1" Then
                        x1hoja.Cells(fila, columna).formula = n.DON
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        'sumadon = sumadon + n.DON
                        'cuentadon = cuentadon + 1
                        'productodon = productodon * n.DON
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.AFLA <> "-1" Then
                        x1hoja.Cells(fila, columna).formula = n.AFLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        'sumaafla = sumaafla + n.AFLA
                        'cuentaafla = cuentaafla + 1
                        'productoafla = productoafla * n.AFLA
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.ZEARA <> "-1" Then
                        x1hoja.Cells(fila, columna).formula = n.ZEARA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        'sumazeara = sumazeara + n.ZEARA
                        'cuentazeara = cuentazeara + 1
                        'productozeara = productozeara * n.ZEARA
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.FIBRAEFECTIVA <> "-1" Then
                        x1hoja.Cells(fila, columna).formula = n.FIBRAEFECTIVA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        'sumafibraefectiva = sumafibraefectiva + n.FIBRAEFECTIVA
                        'cuentafibraefectiva = cuentafibraefectiva + 1
                        'productofibraefectiva = productofibraefectiva * n.FIBRAEFECTIVA
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                    End If
                    If n.CLOSTRIDIOS <> "-1" Then
                        x1hoja.Cells(fila, columna).formula = n.CLOSTRIDIOS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        'sumaclostridios = sumaclostridios + n.CLOSTRIDIOS
                        'cuentaclostridios = cuentaclostridios + 1
                        'productoclostridios = productoclostridios * n.CLOSTRIDIOS
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If
                Next

                If sumamsh <> 0 And cuentamsh <> 0 Then
                    mediamsh = sumamsh / cuentamsh
                End If
                If sumacenizash <> 0 And cuentacenizash <> 0 Then
                    mediacenizash = sumacenizash / cuentacenizash
                End If
                If sumacenizass <> 0 And cuentacenizass <> 0 Then
                    mediacenizass = sumacenizass / cuentacenizass
                End If
                If sumapbh <> 0 And cuentapbh <> 0 Then
                    mediapbh = sumapbh / cuentapbh
                End If
                If sumapbs <> 0 And cuentapbs <> 0 Then
                    mediapbs = sumapbs / cuentapbs
                End If
                If sumafndh <> 0 And cuentafndh <> 0 Then
                    mediafndh = sumafndh / cuentafndh
                End If
                If sumafnds <> 0 And cuentafnds <> 0 Then
                    mediafnds = sumafnds / cuentafnds
                End If
                If sumafadh <> 0 And cuentafadh <> 0 Then
                    mediafadh = sumafadh / cuentafadh
                End If
                If sumafads <> 0 And cuentafads <> 0 Then
                    mediafads = sumafads / cuentafads
                End If
                If sumaenls <> 0 And cuentaenls <> 0 Then
                    mediaenls = sumaenls / cuentaenls
                End If
                If sumaems <> 0 And cuentaems <> 0 Then
                    mediaems = sumaems / cuentaems
                End If
                If sumafch <> 0 And cuentafch <> 0 Then
                    mediafch = sumafch / cuentafch
                End If
                If sumafcs <> 0 And cuentafcs <> 0 Then
                    mediafcs = sumafcs / cuentafcs
                End If
                If sumaphh <> 0 And cuentaphh <> 0 Then
                    mediaphh = sumaphh / cuentaphh
                End If
                If sumaeeh <> 0 And cuentaeeh <> 0 Then
                    mediaeeh = sumaeeh / cuentaeeh
                End If
                If sumaees <> 0 And cuentaees <> 0 Then
                    mediaees = sumaees / cuentaees
                End If
                If sumanidah <> 0 And cuentanidah <> 0 Then
                    medianidah = sumanidah / cuentanidah
                End If
                'If sumadon <> 0 And cuentadon <> 0 Then
                '    mediadon = sumadon / cuentadon
                'End If
                'If sumaafla <> 0 And cuentaafla <> 0 Then
                '    mediaafla = sumaafla / cuentaafla
                'End If
                'If sumazeara <> 0 And cuentazeara <> 0 Then
                '    mediazeara = sumazeara / cuentazeara
                'End If
                'If sumafibraefectiva <> 0 And cuentafibraefectiva <> 0 Then
                '    mediafibraefectiva = sumafibraefectiva / cuentafibraefectiva
                'End If
                'If sumaclostridios <> 0 And cuentaclostridios <> 0 Then
                '    mediaclostridios = sumaclostridios / cuentaclostridios
                'End If
                For Each n In lista
                    If n.MSH <> -1 Then
                        desvmsh = n.MSH - mediamsh
                        cuadmsh = desvmsh * desvmsh
                        sumacuadmsh = sumacuadmsh + cuadmsh
                    End If
                    If n.CENIZASH <> -1 Then
                        desvcenizash = n.CENIZASH - mediacenizash
                        cuadcenizash = desvcenizash * desvcenizash
                        sumacuadcenizash = sumacuadcenizash + cuadcenizash
                    End If
                    If n.CENIZASS <> -1 Then
                        desvcenizass = n.CENIZASS - mediacenizass
                        cuadcenizass = desvcenizass * desvcenizass
                        sumacuadcenizass = sumacuadcenizass + cuadcenizass
                    End If
                    If n.PBH <> -1 Then
                        desvpbh = n.PBH - mediapbh
                        cuadpbh = desvpbh * desvpbh
                        sumacuadpbh = sumacuadpbh + cuadpbh
                    End If
                    If n.PBS <> -1 Then
                        desvpbs = n.PBS - mediapbs
                        cuadpbs = desvpbs * desvpbs
                        sumacuadpbs = sumacuadpbs + cuadpbs
                    End If
                    If n.FNDH <> -1 Then
                        desvfndh = n.FNDH - mediafndh
                        cuadfndh = desvfndh * desvfndh
                        sumacuadfndh = sumacuadfndh + cuadfndh
                    End If
                    If n.FNDS <> -1 Then
                        desvfnds = n.FNDS - mediafnds
                        cuadfnds = desvfnds * desvfnds
                        sumacuadfnds = sumacuadfnds + cuadfnds
                    End If
                    If n.FADH <> -1 Then
                        desvfadh = n.FADH - mediafadh
                        cuadfadh = desvfadh * desvfadh
                        sumacuadfadh = sumacuadfadh + cuadfadh
                    End If
                    If n.FADS <> -1 Then
                        desvfads = n.FADS - mediafads
                        cuadfads = desvfads * desvfads
                        sumacuadfads = sumacuadfads + cuadfads
                    End If
                    If n.ENLS <> -1 Then
                        desvenls = n.ENLS - mediaenls
                        cuadenls = desvenls * desvenls
                        sumacuadenls = sumacuadenls + cuadenls
                    End If
                    If n.EMS <> -1 Then
                        desvems = n.EMS - mediaems
                        cuadems = desvems * desvems
                        sumacuadems = sumacuadems + cuadems
                    End If
                    If n.FCH <> -1 Then
                        desvfch = n.FCH - mediafch
                        cuadfch = desvfch * desvfch
                        sumacuadfch = sumacuadfch + cuadfch
                    End If
                    If n.FCS <> -1 Then
                        desvfcs = n.FCS - mediafcs
                        cuadfcs = desvfcs * desvfcs
                        sumacuadfcs = sumacuadfcs + cuadfcs
                    End If
                    If n.PHH <> -1 Then
                        desvphh = n.PHH - mediaphh
                        cuadphh = desvphh * desvphh
                        sumacuadphh = sumacuadphh + cuadphh
                    End If
                    If n.EEH <> -1 Then
                        desveeh = n.EEH - mediaeeh
                        cuadeeh = desveeh * desveeh
                        sumacuadeeh = sumacuadeeh + cuadeeh
                    End If
                    If n.EES <> -1 Then
                        desvees = n.EES - mediaees
                        cuadees = desvees * desvees
                        sumacuadees = sumacuadees + cuadees
                    End If
                    If n.NIDAH <> -1 Then
                        desvnidah = n.NIDAH - medianidah
                        cuadnidah = desvnidah * desvnidah
                        sumacuadnidah = sumacuadnidah + cuadnidah
                    End If
                    'If n.DON <> "-1" Then
                    '    desvdon = n.DON - mediadon
                    '    cuaddon = desvdon * desvdon
                    '    sumacuaddon = sumacuaddon + cuaddon
                    'End If
                    'If n.AFLA <> "-1" Then
                    '    desvafla = n.AFLA - mediaafla
                    '    cuadafla = desvafla * desvafla
                    '    sumacuadafla = sumacuadafla + cuadafla
                    'End If
                    'If n.ZEARA <> "-1" Then
                    '    desvzeara = n.ZEARA - mediazeara
                    '    cuadzeara = desvzeara * desvzeara
                    '    sumacuadzeara = sumacuadzeara + cuadzeara
                    'End If
                    'If n.FIBRAEFECTIVA <> "-1" Then
                    '    desvfibraefectiva = n.FIBRAEFECTIVA - mediafibraefectiva
                    '    cuadfibraefectiva = desvfibraefectiva * desvfibraefectiva
                    '    sumacuadfibraefectiva = sumacuadfibraefectiva + cuadfibraefectiva
                    'End If
                    'If n.CLOSTRIDIOS <> "-1" Then
                    '    desvclostridios = n.CLOSTRIDIOS - mediaclostridios
                    '    cuadclostridios = desvclostridios * desvclostridios
                    '    sumacuadclostridios = sumacuadclostridios + cuadclostridios
                    'End If
                Next
                If sumacuadmsh > 0 Then
                    restomsh = sumacuadmsh / (cuentamsh - 1)
                End If
                If sumacuadcenizash > 0 Then
                    restocenizash = sumacuadcenizash / (cuentacenizash - 1)
                End If
                If sumacuadcenizass > 0 Then
                    restocenizass = sumacuadcenizass / (cuentacenizass - 1)
                End If
                If sumacuadpbh > 0 Then
                    restopbh = sumacuadpbh / (cuentapbh - 1)
                End If
                If sumacuadpbs > 0 Then
                    restopbs = sumacuadpbs / (cuentapbs - 1)
                End If
                If sumacuadfndh > 0 Then
                    restofndh = sumacuadfndh / (cuentafndh - 1)
                End If
                If sumacuadfnds > 0 Then
                    restofnds = sumacuadfnds / (cuentafnds - 1)
                End If
                If sumacuadfadh > 0 Then
                    restofadh = sumacuadfadh / (cuentafadh - 1)
                End If
                If sumacuadfads > 0 Then
                    restofads = sumacuadfads / (cuentafads - 1)
                End If
                If sumacuadenls > 0 Then
                    restoenls = sumacuadenls / (cuentaenls - 1)
                End If
                If sumacuadems > 0 Then
                    restoems = sumacuadems / (cuentaems - 1)
                End If
                If sumacuadfch > 0 Then
                    restofch = sumacuadfch / (cuentafch - 1)
                End If
                If sumacuadfcs > 0 Then
                    restofcs = sumacuadfcs / (cuentafcs - 1)
                End If
                If sumacuadphh > 0 Then
                    restophh = sumacuadphh / (cuentaphh - 1)
                End If
                If sumacuadeeh > 0 Then
                    restoeeh = sumacuadeeh / (cuentaeeh - 1)
                End If
                If sumacuadees > 0 Then
                    restoees = sumacuadees / (cuentaees - 1)
                End If
                If sumacuadnidah > 0 Then
                    restonidah = sumacuadnidah / (cuentanidah - 1)
                End If
                If restomsh > 0 Then
                    desvestmsh = Math.Sqrt(restomsh)
                End If
                If restocenizash > 0 Then
                    desvestcenizash = Math.Sqrt(restocenizash)
                End If
                If restocenizass > 0 Then
                    desvestcenizass = Math.Sqrt(restocenizass)
                End If
                If restopbh > 0 Then
                    desvestpbh = Math.Sqrt(restopbh)
                End If
                If restopbs > 0 Then
                    desvestpbs = Math.Sqrt(restopbs)
                End If
                If restofndh > 0 Then
                    desvestfndh = Math.Sqrt(restofndh)
                End If
                If restofnds > 0 Then
                    desvestfnds = Math.Sqrt(restofnds)
                End If
                If restofadh > 0 Then
                    desvestfadh = Math.Sqrt(restofadh)
                End If
                If restofads > 0 Then
                    desvestfads = Math.Sqrt(restofads)
                End If
                If restoenls > 0 Then
                    desvestenls = Math.Sqrt(restoenls)
                End If
                If restoems > 0 Then
                    desvestems = Math.Sqrt(restoems)
                End If
                If restofch > 0 Then
                    desvestfch = Math.Sqrt(restofch)
                End If
                If restofcs > 0 Then
                    desvestfcs = Math.Sqrt(restofcs)
                End If
                If restophh > 0 Then
                    desvestphh = Math.Sqrt(restophh)
                End If
                If restoeeh > 0 Then
                    desvesteeh = Math.Sqrt(restoeeh)
                End If
                If restoees > 0 Then
                    desvestees = Math.Sqrt(restoees)
                End If
                If restonidah > 0 Then
                    desvestnidah = Math.Sqrt(restonidah)
                End If
                'If restodon > 0 Then
                '    desvestdon = Math.Sqrt(restodon)
                'End If
                'If restoafla > 0 Then
                '    desvestafla = Math.Sqrt(restoafla)
                'End If
                'If restozeara > 0 Then
                '    desvestzeara = Math.Sqrt(restozeara)
                'End If
                'If restofibraefectiva > 0 Then
                '    desvestfibraefectiva = Math.Sqrt(restofibraefectiva)
                'End If
                'If restoclostridios > 0 Then
                '    desvestclostridios = Math.Sqrt(restoclostridios)
                'End If

                medgeommsh = productomsh ^ (1 / cuentamsh)
                medgeomcenizash = productocenizash ^ (1 / cuentacenizash)
                medgeomcenizass = productocenizass ^ (1 / cuentacenizass)
                medgeompbh = productopbh ^ (1 / cuentapbh)
                medgeompbs = productopbs ^ (1 / cuentapbs)
                medgeomfndh = productofndh ^ (1 / cuentafndh)
                medgeomfnds = productofnds ^ (1 / cuentafnds)
                medgeomfadh = productofadh ^ (1 / cuentafadh)
                medgeomfads = productofads ^ (1 / cuentafads)
                medgeomenls = productoenls ^ (1 / cuentaenls)
                medgeomems = productoems ^ (1 / cuentaems)
                medgeomfch = productofch ^ (1 / cuentafch)
                medgeomfcs = productofcs ^ (1 / cuentafcs)
                medgeomphh = productophh ^ (1 / cuentaphh)
                medgeomeeh = productoeeh ^ (1 / cuentaeeh)
                medgeomees = productoees ^ (1 / cuentaees)
                medgeomnidah = productonidah ^ (1 / cuentanidah)
                'medgeomdon = productodon ^ (1 / cuentadon)
                'medgeomafla = productoafla ^ (1 / cuentaafla)
                'medgeomzeara = productozeara ^ (1 / cuentazeara)
                'medgeomfibraefectiva = productofibraefectiva ^ (1 / cuentafibraefectiva)
                'medgeomclostridios = productoclostridios ^ (1 / cuentaclostridios)

                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Promedio"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 2
                If mediamsh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediamsh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediacenizash <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediacenizash, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediacenizass <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediacenizass, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediapbh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediapbh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediapbs <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediapbs, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediafndh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafndh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediafnds <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafndh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediafadh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafadh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediafads <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafads, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaenls <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaenls, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaems <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaems, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediafch <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafch, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediafcs <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediafcs, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaphh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaphh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaeeh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaeeh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If mediaees <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(mediaees, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medianidah <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medianidah, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If
                'If mediadon <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(mediadon, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If mediaafla <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(mediaafla, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If mediazeara <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(mediazeara, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If mediafibraefectiva <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(mediafibraefectiva, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If mediaclostridios <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(mediaclostridios, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = 1
                '    fila = fila + 1
                'End If

                x1hoja.Cells(fila, columna).formula = "Desv. Estándar"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 2
                If desvestmsh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestmsh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestcenizash <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestcenizash, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestcenizass <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestcenizass, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestpbh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestpbh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestpbs <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestpbs, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestfndh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfndh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestfnds <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfnds, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestfadh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfadh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestfads <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfads, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestenls <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestenls, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestems <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestems, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestfch <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfch, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestfcs <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfcs, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestphh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestphh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvesteeh <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvesteeh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestees <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestees, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If desvestnidah <> 0 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(desvestnidah, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If
                'If desvestdon <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(desvestdon, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If desvestafla <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(desvestafla, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If desvestzeara <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(desvestzeara, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If desvestfibraefectiva <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(desvestfibraefectiva, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If desvestclostridios <> 0 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(desvestclostridios, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = 1
                '    fila = fila + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = 1
                '    fila = fila + 1
                'End If

                x1hoja.Cells(fila, columna).formula = "Media geom."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 2
                If medgeommsh <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeommsh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomcenizash <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomcenizash, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomcenizass <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomcenizass, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeompbh <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeompbh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeompbs <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeompbs, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomfndh <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfndh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomfnds <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfnds, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomfadh <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfadh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomfads <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfads, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomenls <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomenls, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomems <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomems, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomfch <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfch, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomfcs <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfcs, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomphh <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomphh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomeeh <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomeeh, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomees <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomees, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If
                If medgeomnidah <> 1 Then
                    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomnidah, 2)
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If
                'If medgeomdon <> 1 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomdon, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If medgeomafla <> 1 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomafla, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If medgeomzeara <> 1 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomzeara, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If medgeomfibraefectiva <> 1 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomfibraefectiva, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
                'If medgeomclostridios <> 1 Then
                '    x1hoja.Cells(fila, columna).formula = Math.Round(medgeomclostridios, 2)
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'Else
                '    x1hoja.Cells(fila, columna).formula = "-"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Bold = False
                '    x1hoja.Cells(fila, columna).Font.Size = 10
                '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                '    columna = columna + 1
                'End If
            End If
        End If




      


        x1app.Visible = True
        'x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub

    Private Sub CheckClaseAlimento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckClaseAlimento.CheckedChanged
        ComboClase.Text = ""
        habilitar_clase_alimento()
    End Sub

    Private Sub CheckAlimento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAlimento.CheckedChanged
        ComboAlimento.Text = ""
        habilitar_alimento()
    End Sub
    Private Sub habilitar_clase_alimento()
        If CheckClaseAlimento.Checked = True Then
            ComboClase.Enabled = True
        Else
            ComboClase.Enabled = False
        End If
        If CheckClaseAlimento2.Checked = True Then
            ComboClase2.Enabled = True
        Else
            ComboClase2.Enabled = False
        End If
    End Sub
    Private Sub habilitar_alimento()
        If CheckAlimento.Checked = True Then
            ComboAlimento.Enabled = True
        Else
            ComboAlimento.Enabled = False
        End If
        If CheckAlimento2.Checked = True Then
            ComboAlimento2.Enabled = True
        Else
            ComboAlimento2.Enabled = False
        End If

    End Sub

    Private Sub ButtonListar2_Click(sender As Object, e As EventArgs) Handles ButtonListar2.Click
        listar2()
    End Sub

    Private Sub listar2()
        Dim n As New dNutricion
        Dim sumamsh As Double = 0
        Dim sumacenizash As Double = 0
        Dim sumacenizass As Double = 0
        Dim sumapbh As Double = 0
        Dim sumapbs As Double = 0
        Dim sumafndh As Double = 0
        Dim sumafnds As Double = 0
        Dim sumafadh As Double = 0
        Dim sumafads As Double = 0
        Dim sumaenls As Double = 0
        Dim sumaems As Double = 0
        Dim sumafch As Double = 0
        Dim sumafcs As Double = 0
        Dim sumaphh As Double = 0
        Dim sumaeeh As Double = 0
        Dim sumaees As Double = 0
        Dim sumanidah As Double = 0
        Dim sumadon As Double = 0
        Dim sumaafla As Double = 0
        Dim sumazea As Double = 0
        'Dim sumafibraefectiva As Double = 0
        'Dim sumaclostridios As Double = 0
        Dim cuentamsh As Integer = 0
        Dim cuentacenizash As Integer = 0
        Dim cuentacenizass As Integer = 0
        Dim cuentapbh As Integer = 0
        Dim cuentapbs As Integer = 0
        Dim cuentafndh As Integer = 0
        Dim cuentafnds As Integer = 0
        Dim cuentafadh As Integer = 0
        Dim cuentafads As Integer = 0
        Dim cuentaenls As Integer = 0
        Dim cuentaems As Integer = 0
        Dim cuentafch As Integer = 0
        Dim cuentafcs As Integer = 0
        Dim cuentaphh As Integer = 0
        Dim cuentaeeh As Integer = 0
        Dim cuentaees As Integer = 0
        Dim cuentanidah As Integer = 0
        Dim cuentadon As Integer = 0
        Dim cuentaafla As Integer = 0
        Dim cuentazea As Integer = 0
        'Dim cuentafibraefectiva As Integer = 0
        'Dim cuentaclostridios As Integer = 0
        Dim productomsh As Double = 1
        Dim productocenizash As Double = 1
        Dim productocenizass As Double = 1
        Dim productopbh As Double = 1
        Dim productopbs As Double = 1
        Dim productofndh As Double = 1
        Dim productofnds As Double = 1
        Dim productofadh As Double = 1
        Dim productofads As Double = 1
        Dim productoenls As Double = 1
        Dim productoems As Double = 1
        Dim productofch As Double = 1
        Dim productofcs As Double = 1
        Dim productophh As Double = 1
        Dim productoeeh As Double = 1
        Dim productoees As Double = 1
        Dim productonidah As Double = 1
        Dim productodon As Double = 1
        Dim productoafla As Double = 1
        Dim productozea As Double = 1
        'Dim productofibraefectiva As Double = 1
        'Dim productoclostridios As Double = 1
        Dim mediamsh As Double = 0
        Dim mediacenizash As Double = 0
        Dim mediacenizass As Double = 0
        Dim mediapbh As Double = 0
        Dim mediapbs As Double = 0
        Dim mediafndh As Double = 0
        Dim mediafnds As Double = 0
        Dim mediafads As Double = 0
        Dim mediafadh As Double = 0
        Dim mediaenls As Double = 0
        Dim mediaems As Double = 0
        Dim mediafch As Double = 0
        Dim mediafcs As Double = 0
        Dim mediaphh As Double = 0
        Dim mediaeeh As Double = 0
        Dim mediaees As Double = 0
        Dim medianidah As Double = 0
        Dim mediadon As Double = 0
        Dim mediaafla As Double = 0
        Dim mediazea As Double = 0
        'Dim mediafibraefectiva As Double = 0
        'Dim mediaclostridios As Double = 0
        Dim desvmsh As Double = 0
        Dim desvcenizash As Double = 0
        Dim desvcenizass As Double = 0
        Dim desvpbh As Double = 0
        Dim desvpbs As Double = 0
        Dim desvfndh As Double = 0
        Dim desvfnds As Double = 0
        Dim desvfads As Double = 0
        Dim desvfadh As Double = 0
        Dim desvenls As Double = 0
        Dim desvems As Double = 0
        Dim desvfch As Double = 0
        Dim desvfcs As Double = 0
        Dim desvphh As Double = 0
        Dim desveeh As Double = 0
        Dim desvees As Double = 0
        Dim desvnidah As Double = 0
        Dim desvdon As Double = 0
        Dim desvafla As Double = 0
        Dim desvzea As Double = 0
        'Dim desvfibraefectiva As Double = 0
        'Dim desvclostridios As Double = 0
        Dim cuadmsh As Double = 0
        Dim cuadcenizash As Double = 0
        Dim cuadcenizass As Double = 0
        Dim cuadpbh As Double = 0
        Dim cuadpbs As Double = 0
        Dim cuadfndh As Double = 0
        Dim cuadfnds As Double = 0
        Dim cuadfads As Double = 0
        Dim cuadfadh As Double = 0
        Dim cuadenls As Double = 0
        Dim cuadems As Double = 0
        Dim cuadfch As Double = 0
        Dim cuadfcs As Double = 0
        Dim cuadphh As Double = 0
        Dim cuadeeh As Double = 0
        Dim cuadees As Double = 0
        Dim cuadnidah As Double = 0
        Dim cuaddon As Double = 0
        Dim cuadafla As Double = 0
        Dim cuadzea As Double = 0
        'Dim cuadfibraefectiva As Double = 0
        'Dim cuadclostridios As Double = 0
        Dim sumacuadmsh As Double = 0
        Dim sumacuadcenizash As Double = 0
        Dim sumacuadcenizass As Double = 0
        Dim sumacuadpbh As Double = 0
        Dim sumacuadpbs As Double = 0
        Dim sumacuadfndh As Double = 0
        Dim sumacuadfnds As Double = 0
        Dim sumacuadfads As Double = 0
        Dim sumacuadfadh As Double = 0
        Dim sumacuadenls As Double = 0
        Dim sumacuadems As Double = 0
        Dim sumacuadfch As Double = 0
        Dim sumacuadfcs As Double = 0
        Dim sumacuadphh As Double = 0
        Dim sumacuadeeh As Double = 0
        Dim sumacuadees As Double = 0
        Dim sumacuadnidah As Double = 0
        Dim sumacuaddon As Double = 0
        Dim sumacuadafla As Double = 0
        Dim sumacuadzea As Double = 0
        'Dim sumacuadfibraefectiva As Double = 0
        'Dim sumacuadclostridios As Double = 0
        Dim restomsh As Double = 0
        Dim restocenizash As Double = 0
        Dim restopbh As Double = 0
        Dim restopbs As Double = 0
        Dim restofndh As Double = 0
        Dim restofnds As Double = 0
        Dim restofadh As Double = 0
        Dim restofads As Double = 0
        Dim restoenls As Double = 0
        Dim restoems As Double = 0
        Dim restofch As Double = 0
        Dim restofcs As Double = 0
        Dim restophh As Double = 0
        Dim restoeeh As Double = 0
        Dim restoees As Double = 0
        Dim restonidah As Double = 0
        Dim restodon As Double = 0
        Dim restoafla As Double = 0
        Dim restozea As Double = 0
        'Dim restofibraefectiva As Double = 0
        Dim desvestmsh As Double = 0
        Dim desvestcenizash As Double = 0
        Dim desvestcenizass As Double = 0
        Dim desvestpbh As Double = 0
        Dim desvestpbs As Double = 0
        Dim desvestfndh As Double = 0
        Dim desvestfnds As Double = 0
        Dim desvestfadh As Double = 0
        Dim desvestfads As Double = 0
        Dim desvestenls As Double = 0
        Dim desvestems As Double = 0
        Dim desvestfch As Double = 0
        Dim desvestfcs As Double = 0
        Dim desvestphh As Double = 0
        Dim desvesteeh As Double = 0
        Dim desvestees As Double = 0
        Dim desvestnidah As Double = 0
        Dim desvestdon As Double = 0
        Dim desvestafla As Double = 0
        Dim desvestzea As Double = 0
        'Dim desvestfibraefectiva As Double = 0
        'Dim desvestclostridios As Double = 0
        Dim medgeommsh As Double = 0
        Dim medgeomcenizash As Double = 0
        Dim medgeomcenizass As Double = 0
        Dim medgeompbh As Double = 0
        Dim medgeompbs As Double = 0
        Dim medgeomfndh As Double = 0
        Dim medgeomfnds As Double = 0
        Dim medgeomfadh As Double = 0
        Dim medgeomfads As Double = 0
        Dim medgeomenls As Double = 0
        Dim medgeomems As Double = 0
        Dim medgeomfch As Double = 0
        Dim medgeomfcs As Double = 0
        Dim medgeomphh As Double = 0
        Dim medgeomeeh As Double = 0
        Dim medgeomees As Double = 0
        Dim medgeomnidah As Double = 0
        Dim medgeomdon As Double = 0
        Dim medgeomafla As Double = 0
        Dim medgeomzea As Double = 0
        'Dim medgeomfibraefectiva As Double = 0
        'Dim medgeomclostridios As Double = 0

        Dim desde As Date = DateDesde2.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta2.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idclase As dNutricionClase = CType(ComboClase2.SelectedItem, dNutricionClase)
        'Dim idalimento As dNutricionAlimento = CType(ComboAlimento.SelectedItem, dNutricionAlimento)
        Dim idalimento As New dNutricionAlimento
        idalimento = CType(ComboAlimento2.SelectedItem, dNutricionAlimento)
        Dim lista As New ArrayList
        Dim n2 As New dNuevoAnalisis

        'If Not idclase Is Nothing Then
        '    If Not idalimento Is Nothing Then
        '        lista = n.listarxfechaxclasexalimento(fecdesde, fechasta, idclase.ID, idalimento.ID)
        '    Else
        '        lista = n.listarxfechaxclase(fecdesde, fechasta, idclase.ID)
        '    End If
        'Else
        '    lista = n.listarxfecha(fecdesde, fechasta)
        'End If

        If CheckClaseAlimento2.Checked = True Then
            If ComboClase2.Text <> "" Then
                If CheckAlimento2.Checked = True Then
                    If ComboAlimento2.Text <> "" Then
                        lista = n.listarxfechaxclasexalimento(fecdesde, fechasta, idclase.ID, idalimento.ID)
                    Else
                        MsgBox("Selecciones un alimento")
                    End If
                Else
                    lista = n.listarxfechaxclase(fecdesde, fechasta, idclase.ID)
                End If
            Else
                MsgBox("Selecciones una clase de alimento")
            End If
        Else
            lista = n2.listarxfecha(fecdesde, fechasta)
        End If

        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                Dim contador As Integer = lista.Count
                contador = contador + 4
                DataGridView1.Rows.Add(contador)
                For Each n2 In lista
                    'DataGridView1(columna, fila).Value = n2.ID
                    'columna = columna + 1
                    DataGridView1(1, fila).Value = n2.FICHA
                    columna = columna + 1
                    DataGridView1(2, fila).Value = n2.FECHAPROCESO
                    columna = columna + 1
                    'Dim c As New dNutricionClase
                    'Dim a As New dNutricionAlimento
                    'c.ID = n.CLASE
                    'c = c.buscar
                    'a.ID = n.ALIMENTO
                    'a = a.buscar
                    'If Not c Is Nothing Then
                    '    DataGridView1(columna, fila).Value = c.NOMBRE
                    '    columna = columna + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "-"
                    '    columna = columna + 1
                    'End If
                    'If Not a Is Nothing Then
                    '    DataGridView1(columna, fila).Value = a.NOMBRE
                    '    columna = columna + 1
                    'Else
                    '    DataGridView1(columna, fila).Value = "-"
                    '    columna = columna + 1
                    'End If

                    '%MSH
                    If n2.ANALISIS = 164 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(3, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumamsh = sumamsh + n2.RESULTADO
                                cuentamsh = cuentamsh + 1
                                productomsh = productomsh * n2.RESULTADO
                            Else
                                DataGridView1(3, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(3, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumamsh = sumamsh + n2.RESULTADO2
                                cuentamsh = cuentamsh + 1
                                productomsh = productomsh * n2.RESULTADO2
                            Else
                                DataGridView1(3, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%CENIZAS
                    If n2.ANALISIS = 221 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(4, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumacenizass = sumacenizass + n2.RESULTADO
                                cuentacenizass = cuentacenizass + 1
                                productocenizass = productocenizass * n2.RESULTADO
                            Else
                                DataGridView1(4, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(4, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumacenizass = sumacenizass + n2.RESULTADO2
                                cuentacenizass = cuentacenizass + 1
                                productocenizass = productocenizass * n2.RESULTADO2
                            Else
                                DataGridView1(4, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%PB
                    If n2.ANALISIS = 159 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(5, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumapbs = sumapbs + n2.RESULTADO
                                cuentapbs = cuentapbs + 1
                                productopbs = productopbs * n2.RESULTADO
                            Else
                                DataGridView1(5, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(5, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumapbs = sumapbs + n2.RESULTADO2
                                cuentapbs = cuentapbs + 1
                                productopbs = productopbs * n2.RESULTADO2
                            Else
                                DataGridView1(5, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%FND
                    If n2.ANALISIS = 283 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(6, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumafnds = sumafnds + n2.RESULTADO
                                cuentafnds = cuentafnds + 1
                                productofnds = productofnds * n2.RESULTADO
                            Else
                                DataGridView1(6, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(6, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumafnds = sumafnds + n2.RESULTADO2
                                cuentafnds = cuentafnds + 1
                                productofnds = productofnds * n2.RESULTADO2
                            Else
                                DataGridView1(6, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%FAD
                    If n2.ANALISIS = 282 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(7, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumafads = sumafads + n2.RESULTADO
                                cuentafads = cuentafads + 1
                                productofads = productofads * n2.RESULTADO
                            Else
                                DataGridView1(7, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(7, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumafads = sumafads + n2.RESULTADO2
                                cuentafads = cuentafads + 1
                                productofads = productofads * n2.RESULTADO2
                            Else
                                DataGridView1(7, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%ENL
                    If n2.ANALISIS = 284 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(8, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumaenls = sumaenls + n2.RESULTADO
                                cuentaenls = cuentaenls + 1
                                productoenls = productoenls * n2.RESULTADO
                            Else
                                DataGridView1(8, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(8, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumaenls = sumaenls + n2.RESULTADO2
                                cuentaenls = cuentaenls + 1
                                productoenls = productoenls * n2.RESULTADO2
                            Else
                                DataGridView1(8, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%EM
                    If n2.ANALISIS = 285 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(9, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumaems = sumaems + n2.RESULTADO
                                cuentaems = cuentaems + 1
                                productoems = productoems * n2.RESULTADO
                            Else
                                DataGridView1(9, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(9, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumaems = sumaems + n2.RESULTADO2
                                cuentaems = cuentaems + 1
                                productoems = productoems * n2.RESULTADO2
                            Else
                                DataGridView1(9, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%FC
                    If n2.ANALISIS = 286 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(10, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumafcs = sumafcs + n2.RESULTADO
                                cuentafcs = cuentafcs + 1
                                productofcs = productofcs * n2.RESULTADO
                            Else
                                DataGridView1(10, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(10, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumafcs = sumafcs + n2.RESULTADO2
                                cuentafcs = cuentafcs + 1
                                productofcs = productofcs * n2.RESULTADO2
                            Else
                                DataGridView1(10, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%PH
                    If n2.ANALISIS = 165 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(11, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumaphh = sumaphh + n2.RESULTADO
                                cuentaphh = cuentaphh + 1
                                productophh = productophh * n2.RESULTADO
                            Else
                                DataGridView1(11, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(11, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumaphh = sumaphh + n2.RESULTADO2
                                cuentaphh = cuentaphh + 1
                                productophh = productophh * n2.RESULTADO2
                            Else
                                DataGridView1(11, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%EE
                    If n2.ANALISIS = 129 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(12, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumaees = sumaees + n2.RESULTADO
                                cuentaees = cuentaees + 1
                                productoees = productoees * n2.RESULTADO
                            Else
                                DataGridView1(12, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(12, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumaees = sumaees + n2.RESULTADO
                                cuentaees = cuentaees + 1
                                productoees = productoees * n2.RESULTADO
                            Else
                                DataGridView1(12, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%NI
                    If n2.ANALISIS = 287 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                DataGridView1(13, fila).Value = n2.RESULTADO
                                columna = columna + 1
                                sumanidah = sumanidah + n2.RESULTADO
                                cuentanidah = cuentanidah + 1
                                productonidah = productonidah * n2.RESULTADO
                            Else
                                DataGridView1(13, fila).Value = "-"
                                columna = columna + 1
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                DataGridView1(13, fila).Value = n2.RESULTADO2
                                columna = columna + 1
                                sumanidah = sumanidah + n2.RESULTADO2
                                cuentanidah = cuentanidah + 1
                                productonidah = productonidah * n2.RESULTADO2
                            Else
                                DataGridView1(13, fila).Value = "-"
                                columna = columna + 1
                            End If
                        End If
                    End If

                    '%AFLA
                    If n2.ANALISIS = 288 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            DataGridView1(15, fila).Value = n2.RESULTADO
                            'columna = columna + 1
                            'sumaafla = sumaafla + n2.RESULTADO
                            'cuentaafla = cuentaafla + 1
                            'productoafla = productoafla * n2.RESULTADO
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            DataGridView1(15, fila).Value = n2.RESULTADO2
                            'columna = columna + 1
                            'sumaafla = sumaafla + n2.RESULTADO2
                            'cuentaafla = cuentaafla + 1
                            'productoafla = productoafla * n2.RESULTADO2
                        End If
                    End If

                    '%DON
                    If n2.ANALISIS = 289 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            DataGridView1(14, fila).Value = n2.RESULTADO
                            columna = columna + 1
                            'sumadon = sumadon + n2.RESULTADO
                            ''cuentadon = cuentadon + 1
                            'productodon = productodon * n2.RESULTADO
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            DataGridView1(14, fila).Value = n2.RESULTADO2
                            columna = columna + 1
                            'sumadon = sumadon + n2.RESULTADO2
                            'cuentadon = cuentadon + 1
                            'productodon = productodon * n2.RESULTADO2
                        End If
                    End If

                    '%ZEA
                    If n2.ANALISIS = 290 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            DataGridView1(16, fila).Value = n2.RESULTADO
                            'columna = columna + 1
                            'sumazea = sumazea + n2.RESULTADO
                            'cuentazea = cuentazea + 1
                            'productozea = productozea * n2.RESULTADO
                            fila = fila + 1
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then

                            DataGridView1(16, fila).Value = n2.RESULTADO2
                            'columna = columna + 1
                            'sumazea = sumazea + n2.RESULTADO2
                            'cuentazea = cuentazea + 1
                            'productozea = productozea * n2.RESULTADO2
                            fila = fila + 1
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                If sumamsh <> 0 And cuentamsh <> 0 Then
                    mediamsh = sumamsh / cuentamsh
                End If
                If sumacenizass <> 0 And cuentacenizass <> 0 Then
                    mediacenizass = sumacenizass / cuentacenizass
                End If
                If sumapbs <> 0 And cuentapbs <> 0 Then
                    mediapbs = sumapbs / cuentapbs
                End If
                If sumafnds <> 0 And cuentafnds <> 0 Then
                    mediafnds = sumafnds / cuentafnds
                End If
                If sumafads <> 0 And cuentafads <> 0 Then
                    mediafads = sumafads / cuentafads
                End If
                If sumaenls <> 0 And cuentaenls <> 0 Then
                    mediaenls = sumaenls / cuentaenls
                End If
                If sumaems <> 0 And cuentaems <> 0 Then
                    mediaems = sumaems / cuentaems
                End If
                If sumafcs <> 0 And cuentafcs <> 0 Then
                    mediafcs = sumafcs / cuentafcs
                End If
                If sumaphh <> 0 And cuentaphh <> 0 Then
                    mediaphh = sumaphh / cuentaphh
                End If
                If sumaees <> 0 And cuentaees <> 0 Then
                    mediaees = sumaees / cuentaees
                End If
                If sumanidah <> 0 And cuentanidah <> 0 Then
                    medianidah = sumanidah / cuentanidah
                End If
                If sumadon <> 0 And cuentadon <> 0 Then
                    mediadon = sumadon / cuentadon
                End If
                If sumaafla <> 0 And cuentaafla <> 0 Then
                    mediaafla = sumaafla / cuentaafla
                End If
                If sumazea <> 0 And cuentazea <> 0 Then
                    mediazea = sumazea / cuentazea
                End If
                'If sumafibraefectiva <> 0 And cuentafibraefectiva <> 0 Then
                '    mediafibraefectiva = sumafibraefectiva / cuentafibr'aefectiva
                'Erand If
                'If s'umaclostridiraos <> 0 Anrad cuentaclosratridios <> 0 Then                '
                '    mediaclostridios = sumaclostridios / cuentaclostridios
                'End If
                For Each n2 In lista
                    '%MS
                    If n2.ANALISIS = 164 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvmsh = n2.RESULTADO - mediamsh
                                cuadmsh = desvmsh * desvmsh
                                sumacuadmsh = sumacuadmsh + cuadmsh
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvmsh = n2.RESULTADO2 - mediamsh
                                cuadmsh = desvmsh * desvmsh
                                sumacuadmsh = sumacuadmsh + cuadmsh
                            End If
                        End If
                    End If

                    'Cenizas
                    If n2.ANALISIS = 221 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvcenizass = n2.RESULTADO - mediacenizass
                                cuadcenizass = desvcenizass * desvcenizass
                                sumacuadcenizass = sumacuadcenizass + cuadcenizass
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvcenizass = n2.RESULTADO2 - mediacenizass
                                cuadcenizass = desvcenizass * desvcenizass
                                sumacuadcenizass = sumacuadcenizass + cuadcenizass
                            End If
                        End If
                    End If

                    'PB
                    If n2.ANALISIS = 159 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvpbs = n2.RESULTADO - mediapbs
                                cuadpbs = desvpbs * desvpbs
                                sumacuadpbs = sumacuadpbs + cuadpbs
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvpbs = n2.RESULTADO2 - mediapbs
                                cuadpbs = desvpbs * desvpbs
                                sumacuadpbs = sumacuadpbs + cuadpbs
                            End If
                        End If
                    End If

                    'FND
                    If n2.ANALISIS = 283 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvfnds = n2.RESULTADO - mediafnds
                                cuadfnds = desvfnds * desvfnds
                                sumacuadfnds = sumacuadfnds + cuadfnds
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvfnds = n2.RESULTADO2 - mediafnds
                                cuadfnds = desvfnds * desvfnds
                                sumacuadfnds = sumacuadfnds + cuadfnds
                            End If
                        End If
                    End If

                    'FAD
                    If n2.ANALISIS = 282 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvfads = n2.RESULTADO - mediafads
                                cuadfads = desvfads * desvfads
                                sumacuadfads = sumacuadfads + cuadfads
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvfads = n2.RESULTADO2 - mediafads
                                cuadfads = desvfads * desvfads
                                sumacuadfads = sumacuadfads + cuadfads
                            End If
                        End If
                    End If

                    'ENL
                    If n2.ANALISIS = 284 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvenls = n2.RESULTADO - mediaenls
                                cuadenls = desvenls * desvenls
                                sumacuadenls = sumacuadenls + cuadenls
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvenls = n2.RESULTADO2 - mediaenls
                                cuadenls = desvenls * desvenls
                                sumacuadenls = sumacuadenls + cuadenls
                            End If
                        End If
                    End If

                    'EM
                    If n2.ANALISIS = 285 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvems = n2.RESULTADO - mediaems
                                cuadems = desvems * desvems
                                sumacuadems = sumacuadems + cuadems
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvems = n2.RESULTADO2 - mediaems
                                cuadems = desvems * desvems
                                sumacuadems = sumacuadems + cuadems
                            End If
                        End If
                    End If

                    'FC
                    If n2.ANALISIS = 286 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvfcs = n2.RESULTADO - mediafcs
                                cuadfcs = desvfcs * desvfcs
                                sumacuadfcs = sumacuadfcs + cuadfcs
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvfcs = n2.RESULTADO2 - mediafcs
                                cuadfcs = desvfcs * desvfcs
                                sumacuadfcs = sumacuadfcs + cuadfcs
                            End If
                        End If
                    End If

                    'PH
                    If n2.ANALISIS = 165 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvphh = n2.RESULTADO - mediaphh
                                cuadphh = desvphh * desvphh
                                sumacuadphh = sumacuadphh + cuadphh
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvphh = n2.RESULTADO2 - mediaphh
                                cuadphh = desvphh * desvphh
                                sumacuadphh = sumacuadphh + cuadphh
                            End If
                        End If
                    End If

                    'EE
                    If n2.ANALISIS = 129 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvees = n2.RESULTADO - mediaees
                                cuadees = desvees * desvees
                                sumacuadees = sumacuadees + cuadees
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvees = n2.RESULTADO2 - mediaees
                                cuadees = desvees * desvees
                                sumacuadees = sumacuadees + cuadees
                            End If
                        End If
                    End If

                    'NI
                    If n2.ANALISIS = 287 Then
                        If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                            If n2.RESULTADO <> -1 Then
                                desvnidah = n2.RESULTADO - medianidah
                                cuadnidah = desvnidah * desvnidah
                                sumacuadnidah = sumacuadnidah + cuadnidah
                            End If
                        ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                            If n2.RESULTADO2 <> -1 Then
                                desvnidah = n2.RESULTADO2 - medianidah
                                cuadnidah = desvnidah * desvnidah
                                sumacuadnidah = sumacuadnidah + cuadnidah
                            End If
                        End If
                    End If

                    ''DON
                    'If n2.ANALISIS = 289 Then
                    '    If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                    '        If n2.RESULTADO <> -1 Then
                    '            desvdon = n2.RESULTADO - mediadon
                    '            cuaddon = desvdon * desvdon
                    '            sumacuaddon = sumacuaddon + cuaddon
                    '        End If
                    '    ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                    '        If n2.RESULTADO2 <> -1 Then
                    '            desvdon = n2.RESULTADO2 - mediadon
                    '            cuaddon = desvdon * desvdon
                    '            sumacuaddon = sumacuaddon + cuaddon
                    '        End If
                    '    End If
                    'End If

                    ''AFLA
                    'If n2.ANALISIS = 288 Then
                    '    If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                    '        If n2.RESULTADO <> -1 Then
                    '            desvafla = n2.RESULTADO - mediaafla
                    '            cuadafla = desvafla * desvafla
                    '            sumacuadafla = sumacuadafla + cuadafla
                    '        End If
                    '    ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" Then
                    '        If n2.RESULTADO2 <> -1 Then
                    '            desvafla = n2.RESULTADO2 - mediaafla
                    '            cuadafla = desvafla * desvafla
                    '            sumacuadafla = sumacuadafla + cuadafla
                    '        End If
                    '    End If
                    'End If

                    ''ZEA
                    'If n2.ANALISIS = 288 Then
                    '    If n2.RESULTADO <> "" And n2.RESULTADO <> "-" And n2.RESULTADO <> "--" And n2.RESULTADO <> "---" And n2.RESULTADO <> "----" And n2.RESULTADO <> "**" Then
                    '        If n2.RESULTADO <> -1 Then
                    '            desvestzea = n2.RESULTADO - mediazea
                    '            cuadzea = desvestzea * desvestzea
                    '            sumacuadzea = sumacuadzea + cuadzea
                    '        End If
                    '    ElseIf n2.RESULTADO2 <> "" And n2.RESULTADO2 <> "-" And n2.RESULTADO2 <> "--" And n2.RESULTADO2 <> "---" And n2.RESULTADO2 <> "----" And n2.RESULTADO2 <> "**" <> "" Then
                    '        If n2.RESULTADO2 <> -1 Then
                    '            desvestzea = n2.RESULTADO2 - mediazea
                    '            cuadzea = desvestzea * desvestzea
                    '            sumacuadzea = sumacuadzea + cuadzea
                    '        End If
                    '    End If
                    'End If

                Next
                If sumacuadmsh > 0 Then
                    restomsh = sumacuadmsh / (cuentamsh - 1)
                End If
                If sumacuadcenizass > 0 Then
                    restocenizash = sumacuadcenizass / (cuentacenizass - 1)
                End If
                If sumacuadpbs > 0 Then
                    restopbs = sumacuadpbs / (cuentapbs - 1)
                End If
                If sumacuadfnds > 0 Then
                    restofnds = sumacuadfnds / (cuentafnds - 1)
                End If
                If sumacuadfads > 0 Then
                    restofads = sumacuadfads / (cuentafads - 1)
                End If
                If sumacuadenls > 0 Then
                    restoenls = sumacuadenls / (cuentaenls - 1)
                End If
                If sumacuadems > 0 Then
                    restoems = sumacuadems / (cuentaems - 1)
                End If
                If sumacuadfcs > 0 Then
                    restofcs = sumacuadfcs / (cuentafcs - 1)
                End If
                If sumacuadphh > 0 Then
                    restophh = sumacuadphh / (cuentaphh - 1)
                End If
                If sumacuadees > 0 Then
                    restoees = sumacuadees / (cuentaees - 1)
                End If
                If sumacuadnidah > 0 Then
                    restonidah = sumacuadnidah / (cuentanidah - 1)
                End If
                If sumacuaddon > 0 Then
                    restodon = sumacuaddon / (cuentadon - 1)
                End If
                If sumacuadafla > 0 Then
                    restoafla = sumacuadafla / (cuentaafla - 1)
                End If
                If sumacuadzea > 0 Then
                    restozea = sumacuadzea / (cuentazea - 1)
                End If
                
                If restomsh > 0 Then
                    desvestmsh = Math.Sqrt(restomsh)
                End If
                If restocenizash > 0 Then
                    desvestcenizass = Math.Sqrt(restocenizash)
                End If
                If restopbs > 0 Then
                    desvestpbs = Math.Sqrt(restopbs)
                End If
                If restofnds > 0 Then
                    desvestfnds = Math.Sqrt(restofnds)
                End If
                If restofads > 0 Then
                    desvestfads = Math.Sqrt(restofads)
                End If
                If restoenls > 0 Then
                    desvestenls = Math.Sqrt(restoenls)
                End If
                If restoems > 0 Then
                    desvestems = Math.Sqrt(restoems)
                End If
                If restofcs > 0 Then
                    desvestfcs = Math.Sqrt(restofcs)
                End If
                If restophh > 0 Then
                    desvestphh = Math.Sqrt(restophh)
                End If
                If restoees > 0 Then
                    desvestees = Math.Sqrt(restoees)
                End If
                If restonidah > 0 Then
                    desvestnidah = Math.Sqrt(restonidah)
                End If
                If restodon > 0 Then
                    desvestdon = Math.Sqrt(restodon)
                End If
                If restoafla > 0 Then
                    desvestafla = Math.Sqrt(restoafla)
                End If
                If restozea > 0 Then
                    desvestzea = Math.Sqrt(restozea)
                End If

                medgeommsh = productomsh ^ (1 / cuentamsh)
                medgeomcenizass = productocenizass ^ (1 / cuentacenizass)
                medgeompbs = productopbs ^ (1 / cuentapbs)
                medgeomfnds = productofnds ^ (1 / cuentafnds)
                medgeomfads = productofads ^ (1 / cuentafads)
                medgeomenls = productoenls ^ (1 / cuentaenls)
                medgeomems = productoems ^ (1 / cuentaems)
                medgeomfcs = productofcs ^ (1 / cuentafcs)
                medgeomphh = productophh ^ (1 / cuentaphh)
                medgeomees = productoees ^ (1 / cuentaees)
                medgeomnidah = productonidah ^ (1 / cuentanidah)
                medgeomdon = productodon ^ (1 / cuentadon)
                medgeomafla = productoafla ^ (1 / cuentaafla)
                medgeomzea = productozea ^ (1 / cuentazea)

                columna = 1
                fila = fila + 1
                DataGridView1(1, fila).Value = "Promedio"
                columna = columna + 2
                If mediamsh <> 0 Then
                    DataGridView1(3, fila).Value = Math.Round(mediamsh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(3, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediacenizass <> 0 Then
                    DataGridView1(4, fila).Value = Math.Round(mediacenizass, 2)
                    columna = columna + 1
                Else
                    DataGridView1(4, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediapbs <> 0 Then
                    DataGridView1(5, fila).Value = Math.Round(mediapbs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(5, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafnds <> 0 Then
                    DataGridView1(6, fila).Value = Math.Round(mediafnds, 2)
                    columna = columna + 1
                Else
                    DataGridView1(6, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafads <> 0 Then
                    DataGridView1(7, fila).Value = Math.Round(mediafads, 2)
                    columna = columna + 1
                Else
                    DataGridView1(7, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaenls <> 0 Then
                    DataGridView1(8, fila).Value = Math.Round(mediaenls, 2)
                    columna = columna + 1
                Else
                    DataGridView1(8, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaems <> 0 Then
                    DataGridView1(9, fila).Value = Math.Round(mediaems, 2)
                    columna = columna + 1
                Else
                    DataGridView1(9, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediafcs <> 0 Then
                    DataGridView1(10, fila).Value = Math.Round(mediafcs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(10, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaphh <> 0 Then
                    DataGridView1(11, fila).Value = Math.Round(mediaphh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(11, fila).Value = "-"
                    columna = columna + 1
                End If
                If mediaees <> 0 Then
                    DataGridView1(12, fila).Value = Math.Round(mediaees, 2)
                    columna = columna + 1
                Else
                    DataGridView1(12, fila).Value = "-"
                    columna = columna + 1
                End If
                If medianidah <> 0 Then
                    DataGridView1(13, fila).Value = Math.Round(medianidah, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(13, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                If mediadon <> 0 Then
                    DataGridView1(15, fila).Value = Math.Round(mediadon, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(15, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                If mediaafla <> 0 Then
                    DataGridView1(14, fila).Value = Math.Round(mediaafla, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(14, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                If mediazea <> 0 Then
                    DataGridView1(16, fila).Value = Math.Round(mediazea, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(16, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If

                DataGridView1(1, fila).Value = "Desv. Estándar"
                columna = columna + 2
                If desvestmsh <> 0 Then
                    DataGridView1(3, fila).Value = Math.Round(desvestmsh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(3, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestcenizass <> 0 Then
                    DataGridView1(4, fila).Value = Math.Round(desvestcenizass, 2)
                    columna = columna + 1
                Else
                    DataGridView1(4, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestpbs <> 0 Then
                    DataGridView1(5, fila).Value = Math.Round(desvestpbs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(5, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfnds <> 0 Then
                    DataGridView1(6, fila).Value = Math.Round(desvestfnds, 2)
                    columna = columna + 1
                Else
                    DataGridView1(6, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfads <> 0 Then
                    DataGridView1(7, fila).Value = Math.Round(desvestfads, 2)
                    columna = columna + 1
                Else
                    DataGridView1(7, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestenls <> 0 Then
                    DataGridView1(8, fila).Value = Math.Round(desvestenls, 2)
                    columna = columna + 1
                Else
                    DataGridView1(8, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestems <> 0 Then
                    DataGridView1(9, fila).Value = Math.Round(desvestems, 2)
                    columna = columna + 1
                Else
                    DataGridView1(9, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestfcs <> 0 Then
                    DataGridView1(10, fila).Value = Math.Round(desvestfcs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(10, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestphh <> 0 Then
                    DataGridView1(11, fila).Value = Math.Round(desvestphh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(11, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestees <> 0 Then
                    DataGridView1(12, fila).Value = Math.Round(desvestees, 2)
                    columna = columna + 1
                Else
                    DataGridView1(12, fila).Value = "-"
                    columna = columna + 1
                End If
                If desvestnidah <> 0 Then
                    DataGridView1(13, fila).Value = Math.Round(desvestnidah, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(13, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                If desvestdon <> 0 Then
                    DataGridView1(15, fila).Value = Math.Round(desvestdon, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(15, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                If desvestafla <> 0 Then
                    DataGridView1(14, fila).Value = Math.Round(desvestafla, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(14, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If
                If desvestzea <> 0 Then
                    DataGridView1(16, fila).Value = Math.Round(desvestzea, 2)
                    columna = 1
                    fila = fila + 1
                Else
                    DataGridView1(16, fila).Value = "-"
                    columna = 1
                    fila = fila + 1
                End If

                DataGridView1(1, fila).Value = "Media geom."
                columna = columna + 2
                If medgeommsh <> 1 Then
                    DataGridView1(3, fila).Value = Math.Round(medgeommsh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(3, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomcenizass <> 1 Then
                    DataGridView1(4, fila).Value = Math.Round(medgeomcenizass, 2)
                    columna = columna + 1
                Else
                    DataGridView1(4, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeompbs <> 1 Then
                    DataGridView1(5, fila).Value = Math.Round(medgeompbs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(5, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfnds <> 1 Then
                    DataGridView1(6, fila).Value = Math.Round(medgeomfnds, 2)
                    columna = columna + 1
                Else
                    DataGridView1(6, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfads <> 1 Then
                    DataGridView1(7, fila).Value = Math.Round(medgeomfads, 2)
                    columna = columna + 1
                Else
                    DataGridView1(7, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomenls <> 1 Then
                    DataGridView1(8, fila).Value = Math.Round(medgeomenls, 2)
                    columna = columna + 1
                Else
                    DataGridView1(8, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomems <> 1 Then
                    DataGridView1(9, fila).Value = Math.Round(medgeomems, 2)
                    columna = columna + 1
                Else
                    DataGridView1(9, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomfcs <> 1 Then
                    DataGridView1(10, fila).Value = Math.Round(medgeomfcs, 2)
                    columna = columna + 1
                Else
                    DataGridView1(10, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomphh <> 1 Then
                    DataGridView1(11, fila).Value = Math.Round(medgeomphh, 2)
                    columna = columna + 1
                Else
                    DataGridView1(11, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomees <> 1 Then
                    DataGridView1(12, fila).Value = Math.Round(medgeomees, 2)
                    columna = columna + 1
                Else
                    DataGridView1(12, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomnidah <> 1 Then
                    DataGridView1(13, fila).Value = Math.Round(medgeomnidah, 2)
                    columna = columna + 1
                Else
                    DataGridView1(13, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomdon <> 1 Then
                    DataGridView1(15, fila).Value = Math.Round(medgeomdon, 2)
                    columna = columna + 1
                Else
                    DataGridView1(15, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomafla <> 1 Then
                    DataGridView1(14, fila).Value = Math.Round(medgeomafla, 2)
                    columna = columna + 1
                Else
                    DataGridView1(14, fila).Value = "-"
                    columna = columna + 1
                End If
                If medgeomzea <> 1 Then
                    DataGridView1(16, fila).Value = Math.Round(medgeomzea, 2)
                    columna = 0
                Else
                    DataGridView1(16, fila).Value = "-"
                    columna = 0
                End If
            End If
        End If
    End Sub

    Private Sub ComboClase2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboClase2.SelectedIndexChanged
        cargarComboAlimento2()
    End Sub

    Private Sub ComboAlimento2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAlimento2.SelectedIndexChanged
        'cargarComboAlimento()
    End Sub

    Private Sub CheckClaseAlimento2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckClaseAlimento2.CheckedChanged
        ComboClase2.Text = ""
        habilitar_clase_alimento()
    End Sub

    Private Sub CheckAlimento2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAlimento2.CheckedChanged
        ComboAlimento2.Text = ""
        habilitar_alimento()
    End Sub

    Private Sub ButtonExportar2_Click(sender As Object, e As EventArgs) Handles ButtonExportar2.Click

    End Sub
End Class