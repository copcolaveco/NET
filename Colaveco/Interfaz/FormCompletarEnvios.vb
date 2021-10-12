Public Class FormCompletarEnvios
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
        cargar()
    End Sub
#End Region
    Private Sub cargar()
        Dim e As New dEnvioCajas
        Dim a As New dEmpresaT

        Dim lista As New ArrayList
        lista = e.listarsinenvio

        DataGridView1.Rows.Clear()
        'ListPendientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim id As Long
                Dim pedido As Long
                Dim productor As Long
                Dim nomproductor As String = ""
                Dim fecha As Date
                Dim agencia As Integer
                Dim nomagencia As String = ""
                Dim envio As String
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each e In lista
                    Dim p As New dCliente
                    id = e.ID
                    pedido = e.IDPEDIDO
                    productor = e.IDPRODUCTOR
                    p.ID = e.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        nomproductor = p.NOMBRE
                    End If
                    fecha = e.FECHAENVIO
                    agencia = e.IDEMPRESA
                    If e.IDEMPRESA <> 0 Then
                        a.ID = e.IDEMPRESA
                        a = a.buscar
                        If Not a Is Nothing Then
                            nomagencia = a.NOMBRE
                        End If
                    End If
                    envio = e.ENVIO
                    DataGridView1(columna, fila).Value = id
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pedido
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomproductor
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = fecha
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = nomagencia
                    columna = 0
                    fila = fila + 1
                    p = Nothing
                Next
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextPedido.Text = ""
        TextEnvio.Text = ""
        cargar()
    End Sub
    Private Sub cargarultimoenvio()
        Dim ne As New dNumeracionEnvios
        Dim ec As New dEnvioCajas
        Dim id As Long = 0
        Dim agencia As Integer = 0
        id = TextId.Text
        ec.ID = id
        ec = ec.buscarxenvio
        If Not ec Is Nothing Then
            agencia = ec.IDEMPRESA
            ne.IDAGENCIA = agencia
            ne = ne.buscar
            If Not ne Is Nothing Then
                TextEnvio.Text = ne.ENVIO
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Id" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pedido As Long = 0
            'Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            pedido = row.Cells("Pedido").Value
            TextId.Text = id
            TextPedido.Text = pedido
            cargarultimoenvio()
            TextEnvio.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Pedido" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pedido As Long = 0
            'Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            pedido = row.Cells("Pedido").Value
            TextId.Text = id
            TextPedido.Text = pedido
            cargarultimoenvio()
            TextEnvio.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Cliente" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pedido As Long = 0
            'Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            pedido = row.Cells("Pedido").Value
            TextId.Text = id
            TextPedido.Text = pedido
            cargarultimoenvio()
            TextEnvio.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pedido As Long = 0
            'Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            pedido = row.Cells("Pedido").Value
            TextId.Text = id
            TextPedido.Text = pedido
            cargarultimoenvio()
            TextEnvio.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Agencia" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pedido As Long = 0
            'Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            pedido = row.Cells("Pedido").Value
            TextId.Text = id
            TextPedido.Text = pedido
            cargarultimoenvio()
            TextEnvio.Focus()
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Envio" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pedido As Long = 0
            'Dim ec As New dEnvioCajas
            id = row.Cells("Id").Value
            pedido = row.Cells("Pedido").Value
            TextId.Text = id
            TextPedido.Text = pedido
            cargarultimoenvio()
            TextEnvio.Focus()
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ec As New dEnvioCajas
        Dim ec2 As New dEnvioCajas
        Dim ne As New dNumeracionEnvios
        Dim id As Long
        Dim pedido As Long
        Dim agencia As Integer
        Dim envio As String
        If TextId.Text.Trim.Length = 0 Then MsgBox("Seleccione un envío", MsgBoxStyle.Exclamation, "Atención") : TextPedido.Focus() : Exit Sub
        id = TextId.Text.Trim
        ec2.ID = id
        ec2 = ec2.buscar
        If Not ec2 Is Nothing Then
            agencia = ec2.IDEMPRESA
        End If
        If TextPedido.Text.Trim.Length = 0 Then MsgBox("Seleccione un envío", MsgBoxStyle.Exclamation, "Atención") : TextPedido.Focus() : Exit Sub
        pedido = TextPedido.Text.Trim
        If TextEnvio.Text.Trim.Length = 0 Then MsgBox("Ingrese el nº de envío", MsgBoxStyle.Exclamation, "Atención") : TextPedido.Focus() : Exit Sub
        envio = TextEnvio.Text.Trim
        ec.ID = id
        ec.ENVIO = envio
        ec.completarenvio(Usuario)
        ne.IDAGENCIA = agencia
        ne.ENVIO = envio
        ne.modificar(Usuario)
        limpiar()
    End Sub

End Class