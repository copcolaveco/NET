Public Class FormSeleccionarTecnico

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        idparatecnico1 = 0
        idparatecnico2 = 0
        idparatecnico3 = 0
        idparatecnico4 = 0
        idparatecnico5 = 0
        idparatecnico6 = 0
        If CheckBoxDiego.Checked = True Then
            idparatecnico1 = 1
        End If
        If CheckBoxLorena.Checked = True Then
            idparatecnico2 = 1
        End If
        If CheckBoxClaudia.Checked = True Then
            idparatecnico3 = 1
        End If
        If CheckBoxErika.Checked = True Then
            idparatecnico4 = 1
        End If
        If CheckBoxVirginia.Checked = True Then
            idparatecnico5 = 1
        End If
        If CheckBoxJeny.Checked = True Then
            idparatecnico6 = 1
        End If
        Me.Close()
    End Sub
End Class