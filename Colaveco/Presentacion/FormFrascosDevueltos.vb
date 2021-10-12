Public Class FormFrascosDevueltos
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
    Private _frascosdevueltos As dFrascosDevueltos
    Public Property frascosdevueltos() As dFrascosDevueltos
        Get
            Return _frascosdevueltos
        End Get
        Set(ByVal value As dFrascosDevueltos)
            _frascosdevueltos = value
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
        Dim f As New dFrascosDevueltos
        Dim lista As New ArrayList
        lista = f.listar
        Listfrascosdevueltos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each f In lista
                    Listfrascosdevueltos.Items.Add(f)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now()
        TextFicha.Text = ""
        TextIdCliente.Text = ""
        TextNombreCliente.Text = ""
        TextRC_compos.Text = ""
        TextAgua.Text = ""
        TextSangre.Text = ""
        TextEsteriles.Text = ""
        TextOtros.Text = ""
        TextObservaciones.Text = ""
        DateFecha.Focus()
    End Sub

    Private Sub Listfrascosdevueltos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listfrascosdevueltos.SelectedIndexChanged
        limpiar()
        If Listfrascosdevueltos.SelectedItems.Count = 1 Then
            Dim fr As dFrascosDevueltos = CType(Listfrascosdevueltos.SelectedItem, dFrascosDevueltos)
            Dim p As New dProductor
            TextId.Text = fr.ID
            DateFecha.Value = fr.FECHA
            TextIdCliente.Text = fr.IDCLIENTE
            p.ID = fr.IDCLIENTE
            p = p.buscar
            TextNombreCliente.Text = p.NOMBRE
            TextRC_compos.Text = fr.RC_COMPOS
            TextAgua.Text = fr.AGUA
            TextSangre.Text = fr.SANGRE
            TextEsteriles.Text = fr.ESTERILES
            TextOtros.Text = fr.OTROS
            TextObservaciones.Text = fr.OBSERVACIONES
            DateFecha.Focus()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If TextIdCliente.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado cliente", MsgBoxStyle.Exclamation, "Atención") : ButtonBuscar.Focus() : Exit Sub
        Dim idcliente As Long = TextIdCliente.Text.Trim

        Dim rc_compos As Integer
        If TextRC_compos.Text <> "" Then
            rc_compos = TextRC_compos.Text.Trim
        End If
        Dim agua As Integer
        If TextAgua.Text <> "" Then
            agua = TextAgua.Text.Trim
        End If
        Dim sangre As Integer
        If TextSangre.Text <> "" Then
            sangre = TextSangre.Text.Trim
        End If
        Dim esteriles As Integer
        If TextEsteriles.Text <> "" Then
            esteriles = TextEsteriles.Text.Trim
        End If
        Dim otros As Integer
        If TextOtros.Text <> "" Then
            otros = TextOtros.Text.Trim
        End If
        Dim observaciones As String = TextObservaciones.Text.Trim
        If Not ListFrascosDevueltos Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextId.Text.Trim.Length > 0 Then
                Dim fr As New dFrascosDevueltos()
                Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                fec = Format(fecha, "yyyy-MM-dd")
                fr.ID = id
                fr.FECHA = fec
                fr.IDCLIENTE = idcliente
                fr.RC_COMPOS = rc_compos
                fr.AGUA = agua
                fr.SANGRE = sangre
                fr.ESTERILES = esteriles
                fr.OTROS = otros
                fr.OBSERVACIONES = observaciones
                If (fr.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            'If TextIdProductor.Text.Trim.Length > 0 Then
            Dim fr As New dFrascosDevueltos()
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            fr.FECHA = fec
            fr.IDCLIENTE = idcliente
            fr.RC_COMPOS = rc_compos
            fr.AGUA = agua
            fr.SANGRE = sangre
            fr.ESTERILES = esteriles
            fr.OTROS = otros
            fr.OBSERVACIONES = observaciones
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
        If Not Listfrascosdevueltos.SelectedItem Is Nothing Then
            Dim f As New dFrascosDevueltos
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

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdCliente.Text = pro.ID
            TextNombreCliente.Text = pro.NOMBRE
            TextRC_compos.Focus()
        End If
    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextRC_compos.Focus()
        End If
    End Sub

    Private Sub TextFicha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFicha.LostFocus
        Dim s As New dSolicitudAnalisis
        Dim p As New dProductor
        Dim ficha As Long = 0
        If TextFicha.Text.Trim.Length > 0 Then
            ficha = TextFicha.Text.Trim
            s.ID = ficha
            s = s.buscar
            If Not s Is Nothing Then
                p.ID = s.IDPRODUCTOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextIdCliente.Text = p.ID
                    TextNombreCliente.Text = p.NOMBRE
                End If
            End If
        End If
    End Sub

    Private Sub DateFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateFecha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextFicha.Focus()
        End If
    End Sub

    Private Sub TextRC_compos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextRC_compos.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextAgua.Focus()
        End If
    End Sub

    Private Sub TextAgua_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAgua.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextSangre.Focus()
        End If
    End Sub

    Private Sub TextSangre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextSangre.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextEsteriles.Focus()
        End If
    End Sub

    Private Sub TextEsteriles_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextEsteriles.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextOtros.Focus()
        End If
    End Sub

    Private Sub TextOtros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextOtros.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextObservaciones.Focus()
        End If
    End Sub

    Private Sub TextObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextObservaciones.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ButtonGuardar.Focus()
        End If
    End Sub

End Class