Public Class FormEsporulados
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
        Numeric1.Value = 0
        Numeric2.Value = 0
        Numeric3.Value = 0
        TextResultado.Text = ""
        TextFicha.Focus()
    End Sub
    Public Sub limpiar2()
        TextId.Text = ""
        TextMuestra.Text = ""
        Numeric1.Value = 0
        Numeric2.Value = 0
        Numeric3.Value = 0
        TextResultado.Text = ""
        TextFicha.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text.Length > 0 Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim esp As New dEsporulados
                Dim id As Long = CType(TextId.Text, Long)
                esp.ID = id
                If (esp.eliminar(Usuario)) Then
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
    Private Sub listar()
        Dim esp As New dEsporulados
        Dim paginado As Integer = 0
        paginado = NumericPaginado.Value
        Dim lista As New ArrayList
        lista = esp.listar(paginado)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each esp In lista
                    DataGridView1(columna, fila).Value = esp.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp.MUESTRA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp.VALOR1
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp.VALOR2
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp.VALOR3
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = esp.RESULTADO
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub calcular_resultado()
        Dim v1 As Integer = 0
        Dim v2 As Integer = 0
        Dim v3 As Integer = 0
        Dim resultado As String = ""
        v1 = Numeric1.Value
        v2 = Numeric2.Value
        v3 = Numeric3.Value
        If v1 = 0 And v2 = 0 And v3 = 0 Then
            resultado = "< 300"
        ElseIf v1 = 0 And v2 = 0 And v3 = 1 Then
            resultado = "300"
        ElseIf v1 = 0 And v2 = 1 And v3 = 0 Then
            resultado = "300"
        ElseIf v1 = 0 And v2 = 1 And v3 = 1 Then
            resultado = "610"
        ElseIf v1 = 0 And v2 = 1 And v3 = 0 Then
            resultado = "620"
        ElseIf v1 = 0 And v2 = 3 And v3 = 0 Then
            resultado = "940"
        ElseIf v1 = 1 And v2 = 0 And v3 = 0 Then
            resultado = "360"
        ElseIf v1 = 1 And v2 = 0 And v3 = 1 Then
            resultado = "720"
        ElseIf v1 = 1 And v2 = 0 And v3 = 2 Then
            resultado = "1100"
        ElseIf v1 = 1 And v2 = 1 And v3 = 0 Then
            resultado = "740"
        ElseIf v1 = 1 And v2 = 1 And v3 = 1 Then
            resultado = "1100"
        ElseIf v1 = 1 And v2 = 2 And v3 = 0 Then
            resultado = "1100"
        ElseIf v1 = 1 And v2 = 2 And v3 = 1 Then
            resultado = "1500"
        ElseIf v1 = 1 And v2 = 3 And v3 = 0 Then
            resultado = "1600"
        ElseIf v1 = 2 And v2 = 0 And v3 = 0 Then
            resultado = "920"
        ElseIf v1 = 2 And v2 = 0 And v3 = 1 Then
            resultado = "1400"
        ElseIf v1 = 2 And v2 = 0 And v3 = 2 Then
            resultado = "2000"
        ElseIf v1 = 2 And v2 = 1 And v3 = 0 Then
            resultado = "1500"
        ElseIf v1 = 2 And v2 = 1 And v3 = 1 Then
            resultado = "2000"
        ElseIf v1 = 2 And v2 = 1 And v3 = 2 Then
            resultado = "2700"
        ElseIf v1 = 2 And v2 = 2 And v3 = 0 Then
            resultado = "2100"
        ElseIf v1 = 2 And v2 = 2 And v3 = 1 Then
            resultado = "2800"
        ElseIf v1 = 2 And v2 = 2 And v3 = 2 Then
            resultado = "3500"
        ElseIf v1 = 2 And v2 = 3 And v3 = 0 Then
            resultado = "2900"
        ElseIf v1 = 2 And v2 = 3 And v3 = 1 Then
            resultado = "3600"
        ElseIf v1 = 0 And v2 = 3 And v3 = 0 Then
            resultado = "940"
        ElseIf v1 = 3 And v2 = 0 And v3 = 0 Then
            resultado = "2300"
        ElseIf v1 = 3 And v2 = 0 And v3 = 1 Then
            resultado = "3800"
        ElseIf v1 = 3 And v2 = 0 And v3 = 2 Then
            resultado = "6400"
        ElseIf v1 = 3 And v2 = 1 And v3 = 0 Then
            resultado = "4300"
        ElseIf v1 = 3 And v2 = 1 And v3 = 1 Then
            resultado = "7500"
        ElseIf v1 = 3 And v2 = 1 And v3 = 2 Then
            resultado = "12000"
        ElseIf v1 = 3 And v2 = 1 And v3 = 3 Then
            resultado = "16000"
        ElseIf v1 = 3 And v2 = 2 And v3 = 0 Then
            resultado = "9300"
        ElseIf v1 = 3 And v2 = 2 And v3 = 1 Then
            resultado = "15000"
        ElseIf v1 = 3 And v2 = 2 And v3 = 2 Then
            resultado = "21000"
        ElseIf v1 = 3 And v2 = 2 And v3 = 3 Then
            resultado = "29000"
        ElseIf v1 = 3 And v2 = 3 And v3 = 0 Then
            resultado = "24000"
        ElseIf v1 = 3 And v2 = 3 And v3 = 1 Then
            resultado = "46000"
        ElseIf v1 = 3 And v2 = 3 And v3 = 2 Then
            resultado = "110000"
        ElseIf v1 = 3 And v2 = 3 And v3 = 3 Then
            resultado = "> 110000"
        End If
        TextResultado.Text = resultado

    End Sub

    Private Sub Numeric1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Numeric1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Numeric2.Focus()
        End If
    End Sub

    Private Sub Numeric1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Numeric1.ValueChanged
        calcular_resultado()
    End Sub

    Private Sub Numeric2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Numeric2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Numeric3.Focus()
        End If
    End Sub

    Private Sub Numeric2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Numeric2.ValueChanged
        calcular_resultado()
    End Sub

    Private Sub Numeric3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Numeric3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
        End If
    End Sub

    Private Sub Numeric3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Numeric3.ValueChanged
        calcular_resultado()
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
            Numeric1.Focus()
        End If
    End Sub

    Private Sub TextMuestra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMuestra.TextChanged

    End Sub
    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim ficha As Long = TextFicha.Text.Trim
        Dim muestra As String = TextMuestra.Text.Trim
        Dim valor1 As String = Numeric1.Value
        Dim valor2 As String = Numeric2.Value
        Dim valor3 As String = Numeric3.Value
        Dim resultado As String = TextResultado.Text.Trim

        If TextId.Text.Trim.Length > 0 Then
            Dim esp As New dEsporulados
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            esp.ID = id
            esp.FECHA = fec
            esp.FICHA = ficha
            esp.MUESTRA = muestra
            esp.VALOR1 = valor1
            esp.VALOR2 = valor2
            esp.VALOR3 = valor3
            esp.RESULTADO = resultado
            If (esp.modificar(Usuario)) Then
                'MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim esp As New dEsporulados
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            esp.FECHA = fec
            esp.FICHA = ficha
            esp.MUESTRA = muestra
            esp.VALOR1 = valor1
            esp.VALOR2 = valor2
            esp.VALOR3 = valor3
            esp.RESULTADO = resultado
            If (esp.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        listar()
        limpiar2()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim esp As New dEsporulados
            id = row.Cells("Id").Value
            esp.ID = id
            esp = esp.buscar()
            If Not esp Is Nothing Then
                TextId.Text = id
                DateFecha.Value = esp.FECHA
                TextFicha.Text = esp.FICHA
                TextMuestra.Text = esp.MUESTRA
                Numeric1.Value = esp.VALOR1
                Numeric2.Value = esp.VALOR2
                Numeric3.Value = esp.VALOR3
                TextResultado.Text = esp.RESULTADO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Ficha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim esp As New dEsporulados
            id = row.Cells("Id").Value
            esp.ID = id
            esp = esp.buscar()
            If Not esp Is Nothing Then
                TextId.Text = id
                DateFecha.Value = esp.FECHA
                TextFicha.Text = esp.FICHA
                TextMuestra.Text = esp.MUESTRA
                Numeric1.Value = esp.VALOR1
                Numeric2.Value = esp.VALOR2
                Numeric3.Value = esp.VALOR3
                TextResultado.Text = esp.RESULTADO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Muestra" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim esp As New dEsporulados
            id = row.Cells("Id").Value
            esp.ID = id
            esp = esp.buscar()
            If Not esp Is Nothing Then
                TextId.Text = id
                DateFecha.Value = esp.FECHA
                TextFicha.Text = esp.FICHA
                TextMuestra.Text = esp.MUESTRA
                Numeric1.Value = esp.VALOR1
                Numeric2.Value = esp.VALOR2
                Numeric3.Value = esp.VALOR3
                TextResultado.Text = esp.RESULTADO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "valor1" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim esp As New dEsporulados
            id = row.Cells("Id").Value
            esp.ID = id
            esp = esp.buscar()
            If Not esp Is Nothing Then
                TextId.Text = id
                DateFecha.Value = esp.FECHA
                TextFicha.Text = esp.FICHA
                TextMuestra.Text = esp.MUESTRA
                Numeric1.Value = esp.VALOR1
                Numeric2.Value = esp.VALOR2
                Numeric3.Value = esp.VALOR3
                TextResultado.Text = esp.RESULTADO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "valor2" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim esp As New dEsporulados
            id = row.Cells("Id").Value
            esp.ID = id
            esp = esp.buscar()
            If Not esp Is Nothing Then
                TextId.Text = id
                DateFecha.Value = esp.FECHA
                TextFicha.Text = esp.FICHA
                TextMuestra.Text = esp.MUESTRA
                Numeric1.Value = esp.VALOR1
                Numeric2.Value = esp.VALOR2
                Numeric3.Value = esp.VALOR3
                TextResultado.Text = esp.RESULTADO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "valor3" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim esp As New dEsporulados
            id = row.Cells("Id").Value
            esp.ID = id
            esp = esp.buscar()
            If Not esp Is Nothing Then
                TextId.Text = id
                DateFecha.Value = esp.FECHA
                TextFicha.Text = esp.FICHA
                TextMuestra.Text = esp.MUESTRA
                Numeric1.Value = esp.VALOR1
                Numeric2.Value = esp.VALOR2
                Numeric3.Value = esp.VALOR3
                TextResultado.Text = esp.RESULTADO
            End If
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Resultado" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim esp As New dEsporulados
            id = row.Cells("Id").Value
            esp.ID = id
            esp = esp.buscar()
            If Not esp Is Nothing Then
                TextId.Text = id
                DateFecha.Value = esp.FECHA
                TextFicha.Text = esp.FICHA
                TextMuestra.Text = esp.MUESTRA
                Numeric1.Value = esp.VALOR1
                Numeric2.Value = esp.VALOR2
                Numeric3.Value = esp.VALOR3
                TextResultado.Text = esp.RESULTADO
            End If
        End If

    End Sub
End Class