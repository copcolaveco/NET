Public Class FormPsicrotrofos
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property


    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        NumericPaginado.Value = 50
        listar()
        limpiar()

    End Sub

    Public Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        TextFicha.Text = ""
        TextMuestra.Text = ""
        TextValor1.Text = ""
        TextValor2.Text = ""
        TextPromedio.Text = ""
        TextFicha.Focus()
    End Sub
    Public Sub limpiar2()
        TextId.Text = ""
        TextMuestra.Text = ""
        TextValor1.Text = ""
        TextValor2.Text = ""
        TextPromedio.Text = ""
        TextFicha.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub listar()
        Dim p As New dPsicrotrofos
        Dim paginado As Integer = 0
        paginado = NumericPaginado.Value
        Dim lista As New ArrayList
        lista = p.listar(paginado)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridView1(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.MUESTRA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.VALOR1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.VALOR2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.PROMEDIO
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim ficha As Long = TextFicha.Text.Trim
        Dim muestra As String = TextMuestra.Text.Trim
        Dim valor1 As String = TextValor1.Text.Trim
        Dim valor2 As String = TextValor2.Text.Trim
        Dim promedio As String = TextPromedio.Text.Trim

        If TextId.Text.Trim.Length > 0 Then
            Dim p As New dPsicrotrofos
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            p.ID = id
            p.FECHA = fec
            p.FICHA = ficha
            p.MUESTRA = muestra
            p.VALOR1 = valor1
            p.VALOR2 = valor2
            p.PROMEDIO = promedio
            If (p.modificar(Usuario)) Then
                'MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim p As New dPsicrotrofos
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            p.FECHA = fec
            p.FICHA = ficha
            p.MUESTRA = muestra
            p.VALOR1 = valor1
            p.VALOR2 = valor2
            p.PROMEDIO = promedio
            If (p.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        listar()
        limpiar2()
    End Sub
    Private Sub calcular_promedio()
        Dim v1 As String = ""
        Dim v2 As String = ""
        Dim valor1 As Double = 0
        Dim valor2 As Double = 0
        Dim promedio As String = ""
        Dim promedio2 As Decimal = 0
        v1 = TextValor1.Text.Trim
        v2 = TextValor2.Text.Trim
        If v1 = ">300" And v2 = ">300" Then
            promedio = ">3000"
        ElseIf v1 = "0" And v2 = "0" Then
            promedio = "<1"
        ElseIf v1 <> "0" And v1 <> ">300" And v2 = "0" Then
            promedio = v1
        ElseIf v1 = ">300" And v2 <> "0" And v2 <> ">300" Then
            promedio = v2 & "0"
        ElseIf v1 <> "0" And v1 <> ">300" And v2 <> "0" And v2 <> ">300" Then
            valor1 = Val(v1) * 1000
            valor2 = Val(v2) * 10000
            promedio2 = (valor1 + valor2) / 2000
            'promedio2 = Int(valor1 * 10 ^ 0 + 1 / 2) / 10 ^ 0
            'promedio = Math.Round(promedio2, 0)
            promedio = Int(promedio2 * 10 ^ 0 + 1 / 2) / 10 ^ 0
        End If
        TextPromedio.Text = promedio
    End Sub

    Private Sub TextValor1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextValor2.Focus()
        End If
    End Sub

    Private Sub TextValor1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextValor1.TextChanged
        calcular_promedio()
    End Sub

    Private Sub TextValor2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextValor2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
        End If
    End Sub

    Private Sub TextValor2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextValor2.TextChanged
        calcular_promedio()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dPsicrotrofos
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar()
            If Not p Is Nothing Then
                TextId.Text = id
                DateFecha.Value = p.FECHA
                TextFicha.Text = p.FICHA
                TextMuestra.Text = p.MUESTRA
                TextValor1.Text = p.VALOR1
                TextValor2.Text = p.VALOR2
                TextPromedio.Text = p.PROMEDIO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Ficha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dPsicrotrofos
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar()
            If Not p Is Nothing Then
                TextId.Text = id
                DateFecha.Value = p.FECHA
                TextFicha.Text = p.FICHA
                TextMuestra.Text = p.MUESTRA
                TextValor1.Text = p.VALOR1
                TextValor2.Text = p.VALOR2
                TextPromedio.Text = p.PROMEDIO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Muestra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dPsicrotrofos
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar()
            If Not p Is Nothing Then
                TextId.Text = id
                DateFecha.Value = p.FECHA
                TextFicha.Text = p.FICHA
                TextMuestra.Text = p.MUESTRA
                TextValor1.Text = p.VALOR1
                TextValor2.Text = p.VALOR2
                TextPromedio.Text = p.PROMEDIO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "valor1" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dPsicrotrofos
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar()
            If Not p Is Nothing Then
                TextId.Text = id
                DateFecha.Value = p.FECHA
                TextFicha.Text = p.FICHA
                TextMuestra.Text = p.MUESTRA
                TextValor1.Text = p.VALOR1
                TextValor2.Text = p.VALOR2
                TextPromedio.Text = p.PROMEDIO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "valor2" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dPsicrotrofos
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar()
            If Not p Is Nothing Then
                TextId.Text = id
                DateFecha.Value = p.FECHA
                TextFicha.Text = p.FICHA
                TextMuestra.Text = p.MUESTRA
                TextValor1.Text = p.VALOR1
                TextValor2.Text = p.VALOR2
                TextPromedio.Text = p.PROMEDIO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Resultado" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dPsicrotrofos
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar()
            If Not p Is Nothing Then
                TextId.Text = id
                DateFecha.Value = p.FECHA
                TextFicha.Text = p.FICHA
                TextMuestra.Text = p.MUESTRA
                TextValor1.Text = p.VALOR1
                TextValor2.Text = p.VALOR2
                TextPromedio.Text = p.PROMEDIO
            End If
        End If
    End Sub

    Private Sub DateFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateFecha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextFicha.Focus()
        End If
    End Sub

    Private Sub DateFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateFecha.ValueChanged

    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub TextFicha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFicha.TextChanged

    End Sub

    Private Sub TextMuestra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextValor1.Focus()
        End If
    End Sub

    Private Sub TextMuestra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestra.TextChanged

    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim p As New dPsicrotrofos
                Dim id As Long = CType(TextId.Text, Long)
                p.ID = id
                If (p.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        listar()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub
End Class