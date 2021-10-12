Public Class FormMetodos
#Region "Atributos"
    Private _usuario As dUsuario
    Private _idanalisis As Integer
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
    Public Sub New(ByVal idana As Integer, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _idanalisis = idana
        cargarLista()

        Dim lp As New dListaPrecios
        lp.ID = _idanalisis
        lp = lp.buscar
        If Not lp Is Nothing Then
            Me.Text = lp.DESCRIPCION
        End If

    End Sub
#End Region
    Private Sub cargarLista()
        Dim m As New dListaMetodos
        Dim lista As New ArrayList
        Dim idanal As Long = _idanalisis
        lista = m.listarxanalisis(idanal)
        ListMetodos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ListMetodos().Items.Add(m)
                Next
            End If
        End If
        TextMetodo.Text = ""
    End Sub
    Private Sub guardar()
        If _idanalisis <> 0 Then
            If TextId.Text <> "" Then
                Dim id As Integer = TextId.Text
                Dim metodo As String = ""
                Dim xdef As Integer = 0
                If CheckPorDefecto.Checked = True Then
                    xdef = 1
                    desmarcarxdefecto()
                Else
                    xdef = 0
                End If
                If TextMetodo.Text <> "" Then
                    metodo = TextMetodo.Text
                    Dim m As New dListaMetodos
                    m.ID = id
                    m.ANALISIS = _idanalisis
                    m.METODO = metodo
                    m.PORDEFECTO = xdef
                    m.modificar(Usuario)
                    limpiar()
                Else
                    MsgBox("Debe ingresar un método!")
                    TextMetodo.Focus()
                End If
            Else
                Dim metodo As String = ""
                Dim xdef As Integer = 0
                If CheckPorDefecto.Checked = True Then
                    xdef = 1
                    desmarcarxdefecto()
                Else
                    xdef = 0
                End If
                If TextMetodo.Text <> "" Then
                    metodo = TextMetodo.Text
                    Dim m As New dListaMetodos
                    m.ANALISIS = _idanalisis
                    m.METODO = metodo
                    m.PORDEFECTO = xdef
                    m.guardar(Usuario)
                    limpiar()
                Else
                    MsgBox("Debe ingresar un método!")
                    TextMetodo.Focus()
                End If
            End If
        End If
       

    End Sub
    Private Sub desmarcarxdefecto()
        Dim m As New dListaMetodos
        m.ANALISIS = _idanalisis
        m.desmarcarxdefecto(Usuario)
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextMetodo.Text = ""
        CheckPorDefecto.Checked = False
        cargarLista()
    End Sub

    Private Sub ListMetodos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMetodos.SelectedIndexChanged
        TextMetodo.Text = ""
        If ListMetodos.SelectedItems.Count = 1 Then
            Dim m As dListaMetodos = CType(ListMetodos.SelectedItem, dListaMetodos)
            TextId.Text = m.ID
            TextMetodo.Text = m.METODO
            If m.PORDEFECTO = 1 Then
                CheckPorDefecto.Checked = True
            Else
                CheckPorDefecto.Checked = False
            End If
            TextMetodo.Focus()
        End If
    End Sub

    Private Sub ButtonAgergar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgergar.Click
        guardar()
    End Sub

    Private Sub ButtonQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuitar.Click
        If TextId.Text <> "" Then
            eliminar()
        End If
    End Sub
    Private Sub eliminar()
        Dim lm As New dListaMetodos
        Dim id As Integer = 0
        id = TextId.Text
        lm.ID = id
        If (lm.eliminar(Usuario)) Then
            MsgBox("Método eliminado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        TextMetodo.Text = ""
        TextId.Text = ""
        cargarLista()

    End Sub
End Class