Public Class FormUltimasCompras
    Private idproducto As Long
#Region "Constructores"
    Public Sub New(ByVal idprod As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idproducto = idprod
        cargarcompras()
        
    End Sub
#End Region
    Private Sub cargarcompras()
        Dim lc As New dLineaCompra
        Dim lista As New ArrayList
        lista = lc.listarultimos10(idproducto)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            DataGridView1.Rows.Add(lista.Count)
            For Each lc In lista
                DataGridView1(columna, fila).Value = lc.ID
                columna = columna + 1
                Dim c As New dCompras
                c.ID = lc.IDCOMPRA
                c = c.buscar
                If Not c Is Nothing Then
                    DataGridView1(columna, fila).Value = c.FECHA
                    columna = columna + 1
                    Dim p As New dProveedores
                    p.ID = c.PROVEEDOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                Else
                    DataGridView1(columna, fila).Value = ""
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ""
                    columna = columna + 1
                End If
                If lc.MONEDA = 0 Then
                    DataGridView1(columna, fila).Value = "$"
                    columna = columna + 1
                ElseIf lc.MONEDA = 1 Then
                    DataGridView1(columna, fila).Value = "U$S"
                    columna = columna + 1
                End If
                DataGridView1(columna, fila).Value = lc.PRECIO
                columna = 0
                fila = fila + 1
            Next
        End If
    End Sub
End Class