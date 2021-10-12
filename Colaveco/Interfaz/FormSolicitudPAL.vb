Public Class FormSolicitudPAL
    Private _usuario As dUsuario
    Dim idsol As Long
    Dim idprod As Long
    Dim es_empresa As Integer
    Dim tiene_dicose As Integer


    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As Long, ByVal idproductor As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        'listarultimoid()

        idsol = solicitud
        idprod = idproductor
        cant_muestras = 0
        buscarsolicitud()


        'Ver que tipo de cliente es ****
        Dim p As New dCliente
        p.ID = idproductor
        p = p.buscar
        If Not p Is Nothing Then
            If p.TIPOUSUARIO = 2 Then
                es_empresa = 1
            Else
                es_empresa = 0
            End If
            If p.DICOSE = "" Then
                tiene_dicose = 0
            Else
                tiene_dicose = 1
            End If
        End If
        '*********************************

    End Sub
#End Region

    Private Sub TextMatricula_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMatricula.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim ficha As String = idsol
            Dim matricula As String = Trim(TextMatricula.Text)
            Dim vacas As Integer
            If TextVacas.Text <> "" Then
                vacas = Trim(TextVacas.Text)
            End If
            Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")

            Dim sp As New dSolicitudPAL
            Dim pe As New dProductorEmpresa
            Dim listaprodemp As New ArrayList
            listaprodemp = pe.buscarproductorempresa(idprod, matricula)


            If es_empresa = 1 Then
                If Not listaprodemp Is Nothing Then
                    For Each pe In listaprodemp
                        Dim p As New dCliente
                        p.ID = pe.IDPRODUCTOR
                        p = p.buscar
                        If Not p Is Nothing Then
                            If p.DICOSE = "" Then
                                MsgBox("La matrícula asociada no tiene cargado el DICOSE", MsgBoxStyle.Critical, "Atención")
                                'Exit Sub
                            End If
                        End If
                    Next
                Else
                    MsgBox("La matrícula no esta asociada a este productor", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                If tiene_dicose = 0 Then
                    MsgBox("El productor no tiene cargado el DICOSE", MsgBoxStyle.Critical, "Atención")
                End If
            End If



            Dim lista As ArrayList

            If TextMatricula.Text.Length > 0 Then
                lista = sp.controlarmuestras(ficha, matricula)
                If Not lista Is Nothing Then
                    My.Computer.Audio.Play("c:\debug\aviso.wav")
                    Dim result = MessageBox.Show("La matricula ya fué ingresada, desea repetirla?", "Atención", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        Exit Sub
                    ElseIf result = DialogResult.Yes Then
                        Dim spal As New dSolicitudPAL
                        spal.FICHA = idsol
                        spal.MATRICULA = matricula
                        If vacas <> "" Then
                            spal.VACAS = vacas
                        End If
                        spal.FECHAEXT = fec
                        If (spal.guardar(Usuario)) Then
                            'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    End If
                Else
                    Dim spal As New dSolicitudPAL
                    spal.FICHA = idsol
                    spal.MATRICULA = matricula
                    If vacas <> 0 Then
                        spal.VACAS = vacas
                    End If
                    spal.FECHAEXT = fec
                    If (spal.guardar(Usuario)) Then
                        'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If

                End If
            End If

            'solicitud_pal()
            listar_solicitud_pal()
            TextMatricula.Text = ""
            TextMatricula.Focus()

        End If



    End Sub
    Private Sub solicitud_pal()
        Dim ficha As String = idsol
        Dim matricula As String = Trim(TextMatricula.Text)

        If TextMatricula.Text <> "" Then
            Dim sp As New dSolicitudPAL
            sp.FICHA = idsol
            sp.MATRICULA = matricula
            If (sp.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Public Sub listar_solicitud_pal()
        Dim sp As New dSolicitudPAL
        Dim lista As New ArrayList
        lista = sp.listarporid(idsol)
        ListMatriculas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sp In lista
                    ListMatriculas().Items.Add(sp)
                Next
            End If
        End If
    End Sub
    Private Sub buscarsolicitud()
        Dim sp As New dSolicitudPAL
        Dim lista As New ArrayList
        lista = sp.listarporsolicitud(idsol)
        ListMatriculas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sp In lista
                    ListMatriculas().Items.Add(sp)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListMatriculas.SelectedItem Is Nothing Then
            Dim sp As New dSolicitudPAL
            Dim id As Long = CType(TextId.Text, Long)
            sp.ID = id
            If (sp.eliminar(Usuario)) Then
                MsgBox("Matrícula eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        TextMatricula.Text = ""
        TextId.Text = ""
        'listar_solicitud_calidad_muestras()
        'cant_muestras = cant_muestras - 1
        'LabelMuestras.Text = cant_muestras
    End Sub

    Private Sub TextMatricula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMatricula.TextChanged

    End Sub

    Private Sub ListMatriculas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMatriculas.SelectedIndexChanged
        TextMatricula.Text = ""
        If ListMatriculas.SelectedItems.Count = 1 Then
            Dim sp As dSolicitudPAL = CType(ListMatriculas.SelectedItem, dSolicitudPAL)
            TextId.Text = sp.ID

        End If
    End Sub
End Class