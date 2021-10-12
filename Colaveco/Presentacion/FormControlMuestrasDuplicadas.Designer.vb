<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlMuestrasDuplicadas
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
        Me.ButtonProcesar = New System.Windows.Forms.Button
        Me.TextArchivo = New System.Windows.Forms.TextBox
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioBentley = New System.Windows.Forms.RadioButton
        Me.RadioDelta = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'ButtonProcesar
        '
        Me.ButtonProcesar.Location = New System.Drawing.Point(12, 130)
        Me.ButtonProcesar.Name = "ButtonProcesar"
        Me.ButtonProcesar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonProcesar.TabIndex = 6
        Me.ButtonProcesar.Text = "Procesar"
        Me.ButtonProcesar.UseVisualStyleBackColor = True
        '
        'TextArchivo
        '
        Me.TextArchivo.Location = New System.Drawing.Point(12, 93)
        Me.TextArchivo.Name = "TextArchivo"
        Me.TextArchivo.Size = New System.Drawing.Size(290, 20)
        Me.TextArchivo.TabIndex = 5
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(12, 64)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(112, 23)
        Me.ButtonBuscar.TabIndex = 4
        Me.ButtonBuscar.Text = "Seleccionar archivo"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(343, 24)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(205, 225)
        Me.ListBox1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Muestras duplicadas"
        '
        'RadioBentley
        '
        Me.RadioBentley.AutoSize = True
        Me.RadioBentley.Location = New System.Drawing.Point(12, 8)
        Me.RadioBentley.Name = "RadioBentley"
        Me.RadioBentley.Size = New System.Drawing.Size(60, 17)
        Me.RadioBentley.TabIndex = 9
        Me.RadioBentley.TabStop = True
        Me.RadioBentley.Text = "Bentley"
        Me.RadioBentley.UseVisualStyleBackColor = True
        '
        'RadioDelta
        '
        Me.RadioDelta.AutoSize = True
        Me.RadioDelta.Location = New System.Drawing.Point(78, 8)
        Me.RadioDelta.Name = "RadioDelta"
        Me.RadioDelta.Size = New System.Drawing.Size(50, 17)
        Me.RadioDelta.TabIndex = 10
        Me.RadioDelta.TabStop = True
        Me.RadioDelta.Text = "Delta"
        Me.RadioDelta.UseVisualStyleBackColor = True
        '
        'FormControlMuestrasDuplicadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 262)
        Me.Controls.Add(Me.RadioDelta)
        Me.Controls.Add(Me.RadioBentley)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ButtonProcesar)
        Me.Controls.Add(Me.TextArchivo)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Name = "FormControlMuestrasDuplicadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de muestras duplicadas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonProcesar As System.Windows.Forms.Button
    Friend WithEvents TextArchivo As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioBentley As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDelta As System.Windows.Forms.RadioButton
End Class
