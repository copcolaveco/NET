Public Class FormBuscarCajas
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
    End Sub
    Private Sub listar()
        If TextCaja.Text.Length > 0 Then
            Dim idcaja As Long = TextCaja.Text.Trim
            Dim ec As New dEnvioCajas
            Dim p As New dProductor
            Dim lista As New ArrayList
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            lista = ec.listarxcaja(idcaja)
            DataGridView1.Rows.Clear()
            If Not lista Is Nothing Then

                DataGridView1.Rows.Add(lista.Count)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each ec In lista
                            DataGridView1(columna, fila).Value = ec.ID
                            columna = columna + 1
                            DataGridView1(columna, fila).Value = ec.FECHAENVIO
                            columna = columna + 1
                            DataGridView1(columna, fila).Value = ec.ENVIO
                            columna = columna + 1
                            Dim ag As New dEmpresaT
                            ag.ID = ec.IDEMPRESA
                            ag = ag.buscar
                            If Not ag Is Nothing Then
                                DataGridView1(columna, fila).Value = ag.NOMBRE
                                columna = columna + 1
                            Else
                                DataGridView1(columna, fila).Value = ""
                                columna = columna + 1
                            End If
                            DataGridView1(columna, fila).Value = ec.IDCAJA
                            columna = columna + 1
                            p.ID = ec.IDPRODUCTOR
                            p = p.buscar
                            If Not p Is Nothing Then
                                DataGridView1(columna, fila).Value = p.NOMBRE
                                columna = columna + 1
                            Else
                                DataGridView1(columna, fila).Value = ""
                                columna = columna + 1
                            End If
                            DataGridView1(columna, fila).Value = ec.FECHARECIBO
                            columna = 0
                            fila = fila + 1
                        Next
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        listar()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Marcar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ec As New dEnvioCajas
            Dim fecharecibo As Date = Now
            Dim fec As String
            fec = Format(fecharecibo, "yyyy-MM-dd")
            id = row.Cells("Id").Value
            ec.ID = id
            ec.IDAGENCIA = 8
            ec.RECIBO = "s/n"
            ec.FECHARECIBO = fec
            ec.OBSRECIBO = "Entrada manual"
            ec.RECIBIDO = 1
            If (ec.marcarrecibido(Usuario)) Then
                'MsgBox("Caja recibida", MsgBoxStyle.Information, "Atención")
                listar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If

        End If
    End Sub
End Class