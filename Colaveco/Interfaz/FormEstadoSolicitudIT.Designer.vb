<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadoSolicitudIT
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
        Me.ButtonGrabar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.RadioFinalizado = New System.Windows.Forms.RadioButton
        Me.RadioProceso = New System.Windows.Forms.RadioButton
        Me.RadioPendiente = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Location = New System.Drawing.Point(27, 129)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGrabar.TabIndex = 11
        Me.ButtonGrabar.Text = "Grabar"
        Me.ButtonGrabar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Solicitud Nº"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(12, 25)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(100, 20)
        Me.TextId.TabIndex = 9
        '
        'RadioFinalizado
        '
        Me.RadioFinalizado.AutoSize = True
        Me.RadioFinalizado.Location = New System.Drawing.Point(12, 97)
        Me.RadioFinalizado.Name = "RadioFinalizado"
        Me.RadioFinalizado.Size = New System.Drawing.Size(72, 17)
        Me.RadioFinalizado.TabIndex = 8
        Me.RadioFinalizado.TabStop = True
        Me.RadioFinalizado.Text = "Finalizada"
        Me.RadioFinalizado.UseVisualStyleBackColor = True
        '
        'RadioProceso
        '
        Me.RadioProceso.AutoSize = True
        Me.RadioProceso.Location = New System.Drawing.Point(12, 74)
        Me.RadioProceso.Name = "RadioProceso"
        Me.RadioProceso.Size = New System.Drawing.Size(79, 17)
        Me.RadioProceso.TabIndex = 7
        Me.RadioProceso.TabStop = True
        Me.RadioProceso.Text = "En proceso"
        Me.RadioProceso.UseVisualStyleBackColor = True
        '
        'RadioPendiente
        '
        Me.RadioPendiente.AutoSize = True
        Me.RadioPendiente.Location = New System.Drawing.Point(12, 51)
        Me.RadioPendiente.Name = "RadioPendiente"
        Me.RadioPendiente.Size = New System.Drawing.Size(73, 17)
        Me.RadioPendiente.TabIndex = 6
        Me.RadioPendiente.TabStop = True
        Me.RadioPendiente.Text = "Pendiente"
        Me.RadioPendiente.UseVisualStyleBackColor = True
        '
        'FormEstadoSolicitudIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(116, 162)
        Me.Controls.Add(Me.ButtonGrabar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.RadioFinalizado)
        Me.Controls.Add(Me.RadioProceso)
        Me.Controls.Add(Me.RadioPendiente)
        Me.Name = "FormEstadoSolicitudIT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormEstadoSolicitudIT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonGrabar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents RadioFinalizado As System.Windows.Forms.RadioButton
    Friend WithEvents RadioProceso As System.Windows.Forms.RadioButton
    Friend WithEvents RadioPendiente As System.Windows.Forms.RadioButton
End Class
