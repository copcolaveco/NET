<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormObservacionNutricion
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
        Me.RadioGenerales = New System.Windows.Forms.RadioButton()
        Me.RadioSilo = New System.Windows.Forms.RadioButton()
        Me.ButtonCancelar = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextObservacion = New System.Windows.Forms.TextBox()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'RadioGenerales
        '
        Me.RadioGenerales.AutoSize = True
        Me.RadioGenerales.Location = New System.Drawing.Point(15, 35)
        Me.RadioGenerales.Name = "RadioGenerales"
        Me.RadioGenerales.Size = New System.Drawing.Size(265, 17)
        Me.RadioGenerales.TabIndex = 18
        Me.RadioGenerales.TabStop = True
        Me.RadioGenerales.Text = "Observación para muestras en paquetes generales"
        Me.RadioGenerales.UseVisualStyleBackColor = True
        '
        'RadioSilo
        '
        Me.RadioSilo.AutoSize = True
        Me.RadioSilo.Location = New System.Drawing.Point(15, 12)
        Me.RadioSilo.Name = "RadioSilo"
        Me.RadioSilo.Size = New System.Drawing.Size(238, 17)
        Me.RadioSilo.TabIndex = 17
        Me.RadioSilo.TabStop = True
        Me.RadioSilo.Text = "Observación para muestras de silo y pasturas"
        Me.RadioSilo.UseVisualStyleBackColor = True
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(255, 180)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancelar.TabIndex = 16
        Me.ButtonCancelar.Text = "Cancelar"
        Me.ButtonCancelar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(336, 180)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 15
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextObservacion
        '
        Me.TextObservacion.Location = New System.Drawing.Point(12, 58)
        Me.TextObservacion.Multiline = True
        Me.TextObservacion.Name = "TextObservacion"
        Me.TextObservacion.Size = New System.Drawing.Size(399, 116)
        Me.TextObservacion.TabIndex = 14
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(311, 12)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.ReadOnly = True
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 13
        '
        'FormObservacionNutricion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 211)
        Me.Controls.Add(Me.RadioGenerales)
        Me.Controls.Add(Me.RadioSilo)
        Me.Controls.Add(Me.ButtonCancelar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.TextObservacion)
        Me.Controls.Add(Me.TextFicha)
        Me.Name = "FormObservacionNutricion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones Nutricion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioGenerales As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSilo As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextObservacion As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
End Class
