Public Class FormEstadisticaCompras
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


    End Sub
#End Region
    Private Sub proveedoresxmonto()
        Dim p As New dProveedores
        Dim listap As New ArrayList
        Dim cotizacion As Double = 0
        cotizacion = TextCotizacion.Text.Trim
        Dim fila As Integer = 0
        Dim columna As Integer = 0
       
        listap = p.listar
        If Not listap Is Nothing Then
            If listap.Count > 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(listap.Count)
                For Each p In listap
                    Dim cantidad As Double = 0
                    Dim precio As Double = 0
                    Dim moneda As Integer = 0
                    Dim subtotal As Double = 0
                    Dim total As Double = 0
                    Dim c As New dCompras
                    Dim listac As New ArrayList
                    Dim idproveedor As Long = 0
                    idproveedor = p.ID
                    listac = c.listarxproveedor(idproveedor)
                    If Not listac Is Nothing Then
                        If listac.Count > 0 Then
                            For Each c In listac
                                Dim lc As New dLineaCompra
                                Dim listalc As New ArrayList
                                Dim idcompra As Long = 0
                                idcompra = c.ID
                                listalc = lc.listarxidcompra(idcompra)
                                If Not listalc Is Nothing Then
                                    If listalc.Count > 0 Then
                                        For Each lc In listalc
                                            If lc.MONEDA = 1 Then
                                                precio = lc.PRECIO * cotizacion
                                            Else
                                                precio = lc.PRECIO
                                            End If
                                            cantidad = lc.CANTIDAD
                                            subtotal = precio * cantidad
                                            total = total + subtotal
                                            cantidad = 0
                                            precio = 0
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    End If
                    DataGridView1(columna, fila).Value = p.NOMBRE
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = total
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
  
    Private Sub articulosmascomprados()
        Dim p As New dProductos
        Dim listap As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0

        listap = p.listar
        If Not listap Is Nothing Then
            If listap.Count > 0 Then
                DataGridView2.Rows.Clear()
                DataGridView2.Rows.Add(listap.Count)
                For Each p In listap
                    Dim cantidad As Double = 0
                    Dim subtotal As Double = 0
                    Dim total As Double = 0
                    Dim lc As New dLineaCompra
                    Dim listalc As New ArrayList
                    Dim idproducto As Long = 0
                    idproducto = p.ID
                    listalc = lc.listarxidproducto(idproducto)
                    If Not listalc Is Nothing Then
                        If listalc.Count > 0 Then
                            For Each lc In listalc
                                cantidad = lc.CANTIDAD
                                subtotal = subtotal + cantidad
                                cantidad = 0
                            Next
                        End If
                    End If
                    DataGridView2(columna, fila).Value = p.NOMBRE
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = subtotal
                    columna = columna + 1
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    DataGridView2(columna, fila).Value = pre.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                
            End If
        End If
        
                
    End Sub

    

    Private Sub ButtonCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCalcular.Click
        proveedoresxmonto()
        articulosmascomprados()
    End Sub
End Class