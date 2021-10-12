<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInterpretacionesNutricion
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
        Me.ButtonCancelar = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextInterpretacion = New System.Windows.Forms.TextBox()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(255, 160)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancelar.TabIndex = 9
        Me.ButtonCancelar.Text = "Cancelar"
        Me.ButtonCancelar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(336, 160)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 8
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextInterpretacion
        '
        Me.TextInterpretacion.Location = New System.Drawing.Point(12, 38)
        Me.TextInterpretacion.Multiline = True
        Me.TextInterpretacion.Name = "TextInterpretacion"
        Me.TextInterpretacion.Size = New System.Drawing.Size(399, 116)
        Me.TextInterpretacion.TabIndex = 7
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(311, 12)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.ReadOnly = True
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 6
        '
        'FormInterpretacionesNutricion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 192)
        Me.Controls.Add(Me.ButtonCancelar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.TextInterpretacion)
        Me.Controls.Add(Me.TextFicha)
        Me.Name = "FormInterpretacionesNutricion"
        Me.Text = "Interpretación  Nutrición"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextInterpretacion As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
End Class
