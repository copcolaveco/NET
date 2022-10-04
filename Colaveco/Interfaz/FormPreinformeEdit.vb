Public Class FormPreinformeEdit

    Dim IdNuevoTI As Integer = 0
    Dim IdFicha As Integer = 0



#Region "Constructores"
    Public Sub New(ByVal Pre As dPreinformes)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        respuesta.Text = ""
        respuesta.Enabled = False
        Dim Preinfo As New dPreinformes
        Preinfo = Pre

        If Not Preinfo Is Nothing Then
            tbxFicha.Text = Preinfo.FICHA
            IdFicha = Preinfo.FICHA
            tbxFicha.Enabled = False
            If Preinfo.TIPO = 1 Then
                tbxTI.Text = "Control Lechero"
            ElseIf Preinfo.TIPO = 10 Then
                tbxTI.Text = "Calidad de leche"
            End If
            tbxTI.Enabled = False
        End If

        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    If ti.ID = 1 Or ti.ID = 10 Then
                        cbxTI.Items.Add(ti)
                    End If
                Next
            End If
        End If
        cbxTI.SelectedIndex = 1
        Dim idtipoinforme As dTipoInforme = CType(cbxTI.SelectedItem, dTipoInforme)
        IdNuevoTI = idtipoinforme.ID

    End Sub
#End Region

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        respuesta.Text = ""
        respuesta.Enabled = False
        Dim Preinfo As New dPreinformes
        If Preinfo.ModificarPreinforme(IdNuevoTI, IdFicha) = True Then
            respuesta.Text = "Pre-Informe modificado con Exito!, Ahora el Robot se encargara de crear el mismo, aguarde unos minutos. Gracias."
            respuesta.Enabled = True
        Else
            respuesta.Text = "Error, por algun motivo no se pudo concretar la operacion, consultar con IT."
            respuesta.Enabled = True
        End If
    End Sub

    Private Sub cbxTI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTI.SelectedIndexChanged
        Dim idtipoinforme As dTipoInforme = CType(cbxTI.SelectedItem, dTipoInforme)
        IdNuevoTI = idtipoinforme.ID
    End Sub
End Class