<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudParasitologia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.CheckCoccidias = New System.Windows.Forms.CheckBox()
        Me.CheckFasciola = New System.Windows.Forms.CheckBox()
        Me.CheckGastrointesinales = New System.Windows.Forms.CheckBox()
        Me.CheckCoproparasitario_can = New System.Windows.Forms.CheckBox()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(82, 150)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 16
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckCoproparasitario_can)
        Me.GroupBox7.Controls.Add(Me.CheckCoccidias)
        Me.GroupBox7.Controls.Add(Me.CheckFasciola)
        Me.GroupBox7.Controls.Add(Me.CheckGastrointesinales)
        Me.GroupBox7.Location = New System.Drawing.Point(25, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(200, 132)
        Me.GroupBox7.TabIndex = 15
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Análisis requeridos"
        '
        'CheckCoccidias
        '
        Me.CheckCoccidias.AutoSize = True
        Me.CheckCoccidias.Location = New System.Drawing.Point(11, 74)
        Me.CheckCoccidias.Name = "CheckCoccidias"
        Me.CheckCoccidias.Size = New System.Drawing.Size(72, 17)
        Me.CheckCoccidias.TabIndex = 2
        Me.CheckCoccidias.Text = "Coccidias"
        Me.CheckCoccidias.UseVisualStyleBackColor = True
        '
        'CheckFasciola
        '
        Me.CheckFasciola.AutoSize = True
        Me.CheckFasciola.Location = New System.Drawing.Point(11, 51)
        Me.CheckFasciola.Name = "CheckFasciola"
        Me.CheckFasciola.Size = New System.Drawing.Size(65, 17)
        Me.CheckFasciola.TabIndex = 1
        Me.CheckFasciola.Text = "Fasciola"
        Me.CheckFasciola.UseVisualStyleBackColor = True
        '
        'CheckGastrointesinales
        '
        Me.CheckGastrointesinales.AutoSize = True
        Me.CheckGastrointesinales.Location = New System.Drawing.Point(11, 28)
        Me.CheckGastrointesinales.Name = "CheckGastrointesinales"
        Me.CheckGastrointesinales.Size = New System.Drawing.Size(138, 17)
        Me.CheckGastrointesinales.TabIndex = 0
        Me.CheckGastrointesinales.Text = "Coproparasitario Bovino"
        Me.CheckGastrointesinales.UseVisualStyleBackColor = True
        '
        'CheckCoproparasitario_can
        '
        Me.CheckCoproparasitario_can.AutoSize = True
        Me.CheckCoproparasitario_can.Location = New System.Drawing.Point(11, 97)
        Me.CheckCoproparasitario_can.Name = "CheckCoproparasitario_can"
        Me.CheckCoproparasitario_can.Size = New System.Drawing.Size(138, 17)
        Me.CheckCoproparasitario_can.TabIndex = 3
        Me.CheckCoproparasitario_can.Text = "Coproparasitario Canino"
        Me.CheckCoproparasitario_can.UseVisualStyleBackColor = True
        '
        'FormSolicitudParasitologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 184)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "FormSolicitudParasitologia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Parasitología"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckCoccidias As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFasciola As System.Windows.Forms.CheckBox
    Friend WithEvents CheckGastrointesinales As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCoproparasitario_can As System.Windows.Forms.CheckBox
End Class
