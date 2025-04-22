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
        cargarComboCajas()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
    End Sub
    Public Sub cargarComboCajas()
        Dim c As New dCajas
        Dim lista As New ArrayList
        lista = c.listar2
        ComboCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboCajas.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Private Sub listar()
        'If TextCaja.Text.Length > 0 Then
        If ComboCajas.Text.Length > 0 Then
            'Dim idcaja As String = TextCaja.Text.Trim
            Dim idcaja As String = ComboCajas.Text.Trim
            Dim ec As New dEnvioCajas

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
                            Dim p As New dCliente
                            p.ID = ec.IDPRODUCTOR
                            p = p.buscar
                            If Not p Is Nothing Then
                                DataGridView1(columna, fila).Value = p.NOMBRE
                                columna = columna + 1
                            Else
                                DataGridView1(columna, fila).Value = ""
                                columna = columna + 1
                            End If
                            p = Nothing
                            DataGridView1(columna, fila).Value = ec.FECHARECIBO
                            columna = columna + 1
                            Dim c As New dCliente
                            c.ID = ec.CLIENTE
                            c = c.buscar
                            If Not c Is Nothing Then
                                DataGridView1(columna, fila).Value = c.NOMBRE
                                columna = 0
                                fila = fila + 1
                            Else
                                If ec.RECIBIDO = 1 Then
                                    DataGridView1(columna, fila).Value = "Entrada manual"
                                    columna = 0
                                    fila = fila + 1
                                Else
                                    DataGridView1(columna, fila).Value = ""
                                    columna = 0
                                    fila = fila + 1
                                End If
                            End If
                            c = Nothing
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
            'para controlar si esta recibida*********
            Dim recibido As Integer = 0
            Dim id2 As Long = 0
            Dim ec2 As New dEnvioCajas

            id2 = row.Cells("Id").Value

            ec2.ID = id2
            ec2 = ec2.buscar2
            If Not ec2 Is Nothing Then
                If ec2.RECIBIDO = 1 Then
                    recibido = 1
                End If
            End If
            '****************************************
            ec.ID = id
            ec.IDCAJA = row.Cells("Caja").Value
            ec.IDAGENCIA = 8
            ec.RECIBO = "s/n"
            ec.FECHARECIBO = fec
            ec.OBSRECIBO = "Entrada manual"
            ec.RECIBIDO = 1
            ec.CLIENTE = Usuario.ID
            ec.CARGADA = 0
            If recibido = 0 Then
                If (ec.marcarrecibido(Usuario)) Then
                    Dim c As New dCajas
                    Dim caja As String = ""
                    caja = row.Cells("Caja").Value
                    c.CODIGO = caja
                    c.marcarLaboratorioManual(Usuario)
                    'MsgBox("Caja recibida", MsgBoxStyle.Information, "Atención")
                    listar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                MsgBox("Ya fué recibida anteriormente!")
            End If
        End If
    End Sub

    Private Sub ComboCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCajas.SelectedIndexChanged

    End Sub
End Class