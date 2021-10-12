Public Class FormSolucionTrabajo
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
        cargarUnidades()
        cargarlista()
       limpiar()
    End Sub

#End Region
    Private Sub ButtonBuscarProducrto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProducto.Click
        Dim v As New FormBuscarProducto
        v.ShowDialog()
        If Not v.Producto Is Nothing Then
            Dim pro As dProductos = v.Producto
            TextIdProducto.Text = pro.ID
            TextNombreProducto.Text = pro.NOMBRE
            TextCodigo.Text = pro.CODIGO
            TextCantidad.Focus()
        End If
    End Sub
    Public Sub cargarUnidades()
        Dim uni As New dUnidades
        Dim lista As New ArrayList
        lista = uni.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each uni In lista
                    ComboUnidad.Items.Add(uni)
                Next
            End If
        End If
    End Sub

    Private Sub cargarlista()
        Dim s As New dSolucionTrabajo
        Dim lista As New ArrayList
        lista = s.listar
        DataGridSoluciones.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridSoluciones.Rows.Add(lista.Count)
                For Each s In lista
                    DataGridSoluciones(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridSoluciones(columna, fila).Value = s.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()

    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextIdReceta.Text = ""
        TextNombre.Focus()
    End Sub
    Private Sub limpiar2()
        TextIdProducto.Text = ""
        TextNombreProducto.Text = ""
        TextCodigo.Text = ""
        TextCantidad.Text = ""
        ComboUnidad.Text = ""
        ComboUnidad.SelectedItem = Nothing
        TextIdLinea.Text = ""
        ButtonBuscarProducto.Focus()
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text
        If TextId.Text.Trim.Length > 0 Then
            Dim s As New dSolucionTrabajo
            Dim id As Long = CType(TextId.Text.Trim, Long)
            s.ID = id
            s.NOMBRE = nombre
            If (s.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim s As New dSolucionTrabajo
            s.NOMBRE = nombre
            If (s.guardar(Usuario)) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarlista()
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim s As New dSolucionTrabajo
                Dim id As Long = CType(TextId.Text, Long)
                s.ID = id
                If (s.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarlista()
    End Sub

    Private Sub DataGridSoluciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridSoluciones.CellContentClick
        If DataGridSoluciones.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridSoluciones.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolucionTrabajo
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                TextNombre.Text = s.NOMBRE
                TextIdReceta.Text = s.ID
            End If
            limpiar2()
            listarreceta()
        End If
    End Sub
    Private Sub listarreceta()
        Dim sr As New dSolucionTrabajoReceta
        Dim lista As New ArrayList
        Dim id As Integer = TextIdReceta.Text.Trim
        lista = sr.listarxid(Id)
        DataGridReceta.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridReceta.Rows.Add(lista.Count)
                For Each sr In lista
                    DataGridReceta(columna, fila).Value = sr.ID
                    columna = columna + 1
                    DataGridReceta(columna, fila).Value = sr.IDST
                    columna = columna + 1
                    Dim p As New dProductos
                    p.ID = sr.IDPRODUCTO
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridReceta(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridReceta(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridReceta(columna, fila).Value = sr.CANTIDAD
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = sr.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        DataGridReceta(columna, fila).Value = uni.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridReceta(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardarLinea.Click
        Dim idst As Integer = TextIdReceta.Text.Trim
        Dim idproducto As Integer = TextIdProducto.Text.Trim
        Dim cantidad As Double = TextCantidad.Text.Trim
        Dim unidad As dUnidades = CType(ComboUnidad.SelectedItem, dUnidades)
        If TextIdLinea.Text.Trim.Length > 0 Then
            Dim sr As New dSolucionTrabajoReceta
            Dim id As Long = CType(TextIdLinea.Text.Trim, Long)
            sr.ID = id
            sr.IDST = idst
            sr.IDPRODUCTO = idproducto
            sr.CANTIDAD = cantidad
            sr.UNIDAD = unidad.ID
            If (sr.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim sr As New dSolucionTrabajoReceta
            sr.IDST = idst
            sr.IDPRODUCTO = idproducto
            sr.CANTIDAD = cantidad
            sr.UNIDAD = unidad.ID
            If (sr.guardar(Usuario)) Then
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        listarreceta()
        limpiar2()
    End Sub

    Private Sub DataGridReceta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridReceta.CellContentClick
        If DataGridReceta.Columns(e.ColumnIndex).Name = "Producto" Then
            Dim row As DataGridViewRow = DataGridReceta.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim sr As New dSolucionTrabajoReceta
            id = row.Cells("Id2").Value
            sr.ID = id
            sr = sr.buscar
            If Not sr Is Nothing Then
                TextIdProducto.Text = sr.IDPRODUCTO
                Dim p As New dProductos
                p.ID = sr.IDPRODUCTO
                p = p.buscar
                If Not p Is Nothing Then
                    TextNombreProducto.Text = p.NOMBRE
                    TextCodigo.Text = p.CODIGO
                End If
                TextCantidad.Text = sr.CANTIDAD
                Dim uni As New dUnidades
                For Each uni In ComboUnidad.Items
                    If uni.ID = sr.UNIDAD Then
                        ComboUnidad.SelectedItem = uni
                        ComboUnidad.Text = uni.NOMBRE
                        Exit For
                    End If
                Next
                TextIdReceta.Text = sr.IDST
                TextIdLinea.Text = sr.ID
            End If
        End If
        If DataGridReceta.Columns(e.ColumnIndex).Name = "Cantidad" Then
            Dim row As DataGridViewRow = DataGridReceta.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim sr As New dSolucionTrabajoReceta
            id = row.Cells("Id2").Value
            sr.ID = id
            sr = sr.buscar
            If Not sr Is Nothing Then
                TextIdProducto.Text = sr.IDPRODUCTO
                Dim p As New dProductos
                p.ID = sr.IDPRODUCTO
                p = p.buscar
                If Not p Is Nothing Then
                    TextNombreProducto.Text = p.NOMBRE
                    TextCodigo.Text = p.CODIGO
                End If
                TextCantidad.Text = sr.CANTIDAD
                Dim uni As New dUnidades
                For Each uni In ComboUnidad.Items
                    If uni.ID = sr.UNIDAD Then
                        ComboUnidad.SelectedItem = uni
                        ComboUnidad.Text = uni.NOMBRE
                        Exit For
                    End If
                Next
                TextIdReceta.Text = sr.IDST
                TextIdLinea.Text = sr.ID
            End If
        End If
        If DataGridReceta.Columns(e.ColumnIndex).Name = "Unidad" Then
            Dim row As DataGridViewRow = DataGridReceta.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim sr As New dSolucionTrabajoReceta
            id = row.Cells("Id2").Value
            sr.ID = id
            sr = sr.buscar
            If Not sr Is Nothing Then
                TextIdProducto.Text = sr.IDPRODUCTO
                Dim p As New dProductos
                p.ID = sr.IDPRODUCTO
                p = p.buscar
                If Not p Is Nothing Then
                    TextNombreProducto.Text = p.NOMBRE
                    TextCodigo.Text = p.CODIGO
                End If
                TextCantidad.Text = sr.CANTIDAD
                Dim uni As New dUnidades
                For Each uni In ComboUnidad.Items
                    If uni.ID = sr.UNIDAD Then
                        ComboUnidad.SelectedItem = uni
                        ComboUnidad.Text = uni.NOMBRE
                        Exit For
                    End If
                Next
                TextIdReceta.Text = sr.IDST
                TextIdLinea.Text = sr.ID
            End If
        End If
    End Sub

    Private Sub FormSolucionTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonEliminarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarLinea.Click
        If TextIdLinea.Text <> "" Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim sr As New dSolucionTrabajoReceta
                Dim id As Long = CType(TextIdLinea.Text, Long)
                sr.ID = id
                If (sr.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar2()
        listarreceta()
    End Sub

    Private Sub ButtonNuevaLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevaLinea.Click
        limpiar2()
    End Sub
End Class