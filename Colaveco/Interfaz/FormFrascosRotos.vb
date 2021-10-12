Public Class FormFrascosRotos
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
    Private _frascosrotos As dFrascosRotos
    Public Property FrascosRotos() As dFrascosRotos
        Get
            Return _frascosrotos
        End Get
        Set(ByVal value As dFrascosRotos)
            _frascosrotos = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        limpiar()
    End Sub
#End Region
    Public Sub cargarLista()
        Dim f As New dFrascosRotos
        Dim lista As New ArrayList
        lista = f.listar
        ListFrascosRotos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each f In lista
                    ListFrascosRotos.Items.Add(f)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now()
        TextCantidad.Text = ""
        DateFecha.Focus()
    End Sub

    Private Sub ListFrascosRotos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFrascosRotos.SelectedIndexChanged
        limpiar()
        If ListFrascosRotos.SelectedItems.Count = 1 Then
            Dim fr As dFrascosRotos = CType(ListFrascosRotos.SelectedItem, dFrascosRotos)
            TextId.Text = fr.ID
            DateFecha.Value = fr.FECHA
            TextCantidad.Text = fr.CANTIDAD
            DateFecha.Focus()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextCantidad.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la cantidad", MsgBoxStyle.Exclamation, "Atención") : TextCantidad.Focus() : Exit Sub
        Dim cantidad As Integer = TextCantidad.Text.Trim
        If Not ListFrascosRotos Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextId.Text.Trim.Length > 0 Then
                Dim fr As New dFrascosRotos()
                Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                fec = Format(fecha, "yyyy-MM-dd")
                fr.ID = id
                fr.FECHA = fec
                fr.CANTIDAD = cantidad
                If (fr.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            'If TextIdProductor.Text.Trim.Length > 0 Then
            Dim fr As New dFrascosRotos()
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            fr.FECHA = fec
            fr.CANTIDAD = cantidad
            If (fr.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
            'End If
        End If
        cargarLista()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListFrascosRotos.SelectedItem Is Nothing Then
            Dim f As New dFrascosRotos
            Dim id As Long = CType(TextId.Text, Long)
            f.ID = id
            If (f.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub
End Class