Public Class FormSeleccionarTipoInforme
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        cargarComboTI()
    End Sub
#End Region
    Public Sub cargarComboTI()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTI.Items.Add(ti)
                Next
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim idtipoinforme As dTipoInforme = CType(ComboTI.SelectedItem, dTipoInforme)
        If Not idtipoinforme Is Nothing Then
            idti = idtipoinforme.ID
        End If
        Me.Close()
    End Sub
End Class