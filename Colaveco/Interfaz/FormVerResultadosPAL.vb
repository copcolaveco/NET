Public Class FormVerResultadosPAL
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

    End Sub

#End Region

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        listar()

    End Sub
    Private Sub listar()
        If TextFicha.Text <> "" Then
            Dim p As New dPal
            Dim texto As Long = TextFicha.Text.Trim
            Dim lista As New ArrayList
            lista = p.listarporsolicitud(texto)
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            DataGridView1.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView1.Rows.Add(lista.Count)
            End If
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each p In lista
                        DataGridView1(columna, fila).Value = p.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = p.FICHA
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = p.MUESTRA
                        columna = columna + 1
                        If p.RESULTADO = 0 Then
                            DataGridView1(columna, fila).Value = "Negativo"
                            columna = 0
                            fila = fila + 1
                        Else
                            DataGridView1(columna, fila).Value = "Positivo"
                            columna = 0
                            fila = fila + 1
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If DataGridView1.Columns(e.ColumnIndex).Name = "Muestra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim muestra As String = ""
            Dim p As New dPal
            id = row.Cells("Id").Value
            muestra = row.Cells("Muestra").Value
            p.ID = id
            p.MUESTRA = muestra
            If (p.modificarmuestra(Usuario)) Then
                MsgBox("Muestra modificada", MsgBoxStyle.Information, "Atención")
                listar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
End Class