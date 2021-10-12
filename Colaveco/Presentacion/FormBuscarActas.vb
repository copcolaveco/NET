Public Class FormBuscarActas
    Private _actas As dActas
    Public Property Actas() As dActas
        Get
            Return _actas
        End Get
        Set(ByVal value As dActas)
            _actas = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarGrupos()
        RadioFecha.Checked = True
    End Sub

#End Region
    Public Sub cargarGrupos()
        Dim s As New dSectores
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ComboGrupo.Items.Add(s)
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Numero" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActas
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                Actas = a
                Me.Close()
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActas
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                Actas = a
                Me.Close()
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Grupo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dActas
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                Actas = a
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        If RadioFecha.Checked = True Then
            buscarxfecha()
        ElseIf RadioGrupo.Checked = True Then
            buscarxgrupo()
        ElseIf RadioFechaGrupo.Checked = True Then
            buscarxfechaxgrupo()
        End If
    End Sub
    Private Sub buscarxfecha()
        Dim a As New dActas
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = a.listarxfecha(fechad, fechah)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    DataGridView1(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FECHA
                    columna = columna + 1
                    Dim s As New dSectores
                    s.ID = a.GRUPO
                    s = s.buscar
                    If Not s Is Nothing Then
                        DataGridView1(columna, fila).Value = s.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If
                    
                Next
            End If
        End If
    End Sub
    Private Sub buscarxgrupo()
        Dim a As New dActas
        Dim idgrupo As Integer = 0
        If ComboGrupo.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado el grupo", MsgBoxStyle.Exclamation, "Atención") : ComboGrupo.Focus() : Exit Sub
        Dim grupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        idgrupo = grupo.ID
        Dim lista As New ArrayList
        lista = a.listarxgrupo(idgrupo)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    DataGridView1(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FECHA
                    columna = columna + 1
                    Dim s As New dSectores
                    s.ID = a.GRUPO
                    s = s.buscar
                    If Not s Is Nothing Then
                        DataGridView1(columna, fila).Value = s.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If

                Next
            End If
        End If
    End Sub
    Private Sub buscarxfechaxgrupo()
        Dim a As New dActas
        Dim idgrupo As Integer = 0
        If ComboGrupo.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado el grupo", MsgBoxStyle.Exclamation, "Atención") : ComboGrupo.Focus() : Exit Sub
        Dim grupo As dSectores = CType(ComboGrupo.SelectedItem, dSectores)
        idgrupo = grupo.ID
        Dim fechadesde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fechad As String = Format(fechadesde, "yyyy-MM-dd")
        Dim fechah As String = Format(fechahasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = a.listarxfechaxgrupo(fechad, fechah, idgrupo)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    DataGridView1(columna, fila).Value = a.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.NUMERO
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = a.FECHA
                    columna = columna + 1
                    Dim s As New dSectores
                    s.ID = a.GRUPO
                    s = s.buscar
                    If Not s Is Nothing Then
                        DataGridView1(columna, fila).Value = s.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                    End If

                Next
            End If
        End If
    End Sub
End Class