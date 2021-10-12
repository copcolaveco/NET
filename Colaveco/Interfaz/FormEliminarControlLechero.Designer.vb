<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEliminarControlLechero
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
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.RadioCalidad = New System.Windows.Forms.RadioButton
        Me.RadioControl = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(78, 91)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ingrese el numero de ficha"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(90, 117)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 2
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'RadioCalidad
        '
        Me.RadioCalidad.AutoSize = True
        Me.RadioCalidad.Location = New System.Drawing.Point(12, 35)
        Me.RadioCalidad.Name = "RadioCalidad"
        Me.RadioCalidad.Size = New System.Drawing.Size(104, 17)
        Me.RadioCalidad.TabIndex = 3
        Me.RadioCalidad.TabStop = True
        Me.RadioCalidad.Text = "Calidad de leche"
        Me.RadioCalidad.UseVisualStyleBackColor = True
        '
        'RadioControl
        '
        Me.RadioControl.AutoSize = True
        Me.RadioControl.Location = New System.Drawing.Point(12, 12)
        Me.RadioControl.Name = "RadioControl"
        Me.RadioControl.Size = New System.Drawing.Size(96, 17)
        Me.RadioControl.TabIndex = 4
        Me.RadioControl.TabStop = True
        Me.RadioControl.Text = "Control lechero"
        Me.RadioControl.UseVisualStyleBackColor = True
        '
        'FormEliminarControlLechero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 162)
        Me.Controls.Add(Me.RadioControl)
        Me.Controls.Add(Me.RadioCalidad)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Name = "FormEliminarControlLechero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Eliminar importación"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents RadioCalidad As System.Windows.Forms.RadioButton
    Friend WithEvents RadioControl As System.Windows.Forms.RadioButton
End Class
