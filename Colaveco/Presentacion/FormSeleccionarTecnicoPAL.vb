Public Class FormSeleccionarTecnicoPAL

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        idparatecnico1 = 0
        idparatecnico2 = 0
       
        If CheckBoxDario.Checked = True Then
            idparatecnico1 = 1
        End If
        If CheckBoxCecilia.Checked = True Then
            idparatecnico2 = 1
        End If
        
        Me.Close()
    End Sub
End Class