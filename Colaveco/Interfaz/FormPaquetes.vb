Public Class FormPaquetes
    Private tipoinforme As String
    Private _usuario As dUsuario
    Private idtipoinf As Integer = 0
    Private _idpadre As Integer = 0
    Private _idhijo As Integer = 0

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
        cargarComboInformes()

    End Sub
#End Region
    Public Sub cargarComboInformes()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTipoInforme.Items.Add(ti)
                Next
            End If
        End If
    End Sub

    Private Sub ComboTipoInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoInforme.SelectedIndexChanged
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        If Not idtipoinforme Is Nothing Then
            If idtipoinforme.ID = 1 Then
                idtipoinf = 1
            ElseIf idtipoinforme.ID = 3 Then
                idtipoinf = 3
            ElseIf idtipoinforme.ID = 4 Then
                idtipoinf = 4
            ElseIf idtipoinforme.ID = 6 Then
                idtipoinf = 6
            ElseIf idtipoinforme.ID = 7 Then
                idtipoinf = 7
            ElseIf idtipoinforme.ID = 8 Then
                idtipoinf = 8
            ElseIf idtipoinforme.ID = 9 Then
                idtipoinf = 9
            ElseIf idtipoinforme.ID = 10 Then
                idtipoinf = 10
            ElseIf idtipoinforme.ID = 11 Then
                idtipoinf = 11
            ElseIf idtipoinforme.ID = 13 Then
                idtipoinf = 13
            ElseIf idtipoinforme.ID = 14 Then
                idtipoinf = 14
            ElseIf idtipoinforme.ID = 15 Then
                idtipoinf = 15
            ElseIf idtipoinforme.ID = 16 Then
                idtipoinf = 16
            ElseIf idtipoinforme.ID = 17 Then
                idtipoinf = 17
            ElseIf idtipoinforme.ID = 18 Then
                idtipoinf = 18
            ElseIf idtipoinforme.ID = 19 Then
                idtipoinf = 19
            ElseIf idtipoinforme.ID = 20 Then
                idtipoinf = 20
            ElseIf idtipoinforme.ID = 99 Then
                idtipoinf = 99
            End If

        End If
        'listaranalisis()
        'listaranalisis2()
        listarpaquetes()
        listaranalisis()
    End Sub
    'Private Sub listaranalisis()
    '    Dim l As New dListaPrecios
    '    Dim lista As New ArrayList
    '    Dim fila As Integer = 0
    '    Dim columna As Integer = 0
    '    lista = l.listarxti(idtipoinf)
    '    DataGridView1.Rows.Clear()
    '    If Not lista Is Nothing Then
    '        DataGridView1.Rows.Add(lista.Count)
    '    End If
    '    If Not lista Is Nothing Then
    '        For Each l In lista
    '            DataGridView1(columna, fila).Value = l.ID
    '            columna = columna + 1
    '            DataGridView1(columna, fila).Value = l.DESCRIPCION
    '            columna = 0
    '            fila = fila + 1
    '        Next
    '    End If
    'End Sub
    'Private Sub listaranalisis2()
    '    Dim l As New dListaPrecios
    '    Dim lista As New ArrayList
    '    Dim fila As Integer = 0
    '    Dim columna As Integer = 0
    '    lista = l.listarxti(idtipoinf)
    '    DataGridView2.Rows.Clear()
    '    If Not lista Is Nothing Then
    '        DataGridView2.Rows.Add(lista.Count)
    '    End If
    '    If Not lista Is Nothing Then
    '        For Each l In lista
    '            DataGridView2(columna, fila).Value = l.ID
    '            columna = columna + 1
    '            DataGridView2(columna, fila).Value = l.DESCRIPCION
    '            columna = 0
    '            fila = fila + 1
    '        Next
    '    End If
    'End Sub
    Private Sub listarpaquetes()
        Dim l As New dListaPrecios
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        'lista = l.listarxti(idtipoinf)
        lista = l.listarpaquetes(idtipoinf)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            For Each l In lista
                DataGridView1(columna, fila).Value = l.ID
                DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                columna = columna + 1
                DataGridView1(columna, fila).Value = l.DESCRIPCION
                DataGridView1(columna, fila).Style.BackColor = Color.SkyBlue
                columna = 0
                fila = fila + 1
            Next
        End If
    End Sub
    Private Sub listaranalisis()
        Dim l As New dListaPrecios
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = l.listar_solo_analisis(idtipoinf)
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView2.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            For Each l In lista
                DataGridView2(columna, fila).Value = l.ID
                columna = columna + 1
                DataGridView2(columna, fila).Value = l.DESCRIPCION
                columna = 0
                fila = fila + 1
            Next
        End If
    End Sub
    Private Sub listaranalisis3()
        Dim p As New dPaquetes
        Dim pp As Integer = 1
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = p.listarxpadre(_idpadre)
        DataGridView3.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView3.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            For Each p In lista
                DataGridView3(columna, fila).Value = p.ID
                columna = columna + 1
                Dim l As New dListaPrecios
                l.ID = p.IDHIJO
                l = l.buscar
                If Not l Is Nothing Then
                    DataGridView3(columna, fila).Value = l.DESCRIPCION
                    columna = 0
                    fila = fila + 1
                End If
                If p.PRECIOPADRE = 0 Then
                    pp = 0
                End If
            Next
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Descripcion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id").Value
            _idpadre = id
            listaranalisis3()
        End If
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Agregar" Then
            Dim preciopadre As Integer = 1
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id2").Value
            _idhijo = id
            Dim p As New dPaquetes
            p.IDPADRE = _idpadre
            p.IDHIJO = _idhijo
            p.PRECIOPADRE = preciopadre
            p.guardar(Usuario)
            listaranalisis3()
        End If
    End Sub

    Private Sub DataGridView3_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        If DataGridView3.Columns(e.ColumnIndex).Name = "Quitar" Then
            Dim row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id3").Value
            Dim p As New dPaquetes
            p.ID = id
            p.eliminar(Usuario)
            listaranalisis3()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class