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
        Me.ButtonProcesar = New System.Windows.Forms.Button()
        Me.TextArchivo = New System.Windows.Forms.TextBox()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioBentley = New System.Windows.Forms.RadioButton()
        Me.RadioB6 = New System.Windows.Forms.RadioButton()
        Me.RadioDelta600 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'ButtonProcesar
        '
        Me.ButtonProcesar.Location = New System.Drawing.Point(16, 160)
        Me.ButtonProcesar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonProcesar.Name = "ButtonProcesar"
        Me.ButtonProcesar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonProcesar.TabIndex = 6
        Me.ButtonProcesar.Text = "Procesar"
        Me.ButtonProcesar.UseVisualStyleBackColor = True
        '
        'TextArchivo
        '
        Me.TextArchivo.Location = New System.Drawing.Point(16, 114)
        Me.TextArchivo.Margin = New System.Windows.Forms.Padding(4)
        Me.TextArchivo.Name = "TextArchivo"
        Me.TextArchivo.Size = New System.Drawing.Size(385, 22)
        Me.TextArchivo.TabIndex = 5
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(16, 79)
        Me.ButtonBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(149, 28)
        Me.ButtonBuscar.TabIndex = 4
        Me.ButtonBuscar.Text = "Seleccionar archivo"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Info
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(457, 30)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(272, 276)
        Me.ListBox1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(453, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Muestras duplicadas"
        '
        'RadioBentley
        '
        Me.RadioBentley.AutoSize = True
        Me.RadioBentley.Location = New System.Drawing.Point(16, 10)
        Me.RadioBentley.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioBentley.Name = "RadioBentley"
        Me.RadioBentley.Size = New System.Drawing.Size(76, 21)
        Me.RadioBentley.TabIndex = 9
        Me.RadioBentley.TabStop = True
        Me.RadioBentley.Text = "Bentley"
        Me.RadioBentley.UseVisualStyleBackColor = True
        '
        'RadioB6
        '
        Me.RadioB6.AutoSize = True
        Me.RadioB6.Location = New System.Drawing.Point(104, 10)
        Me.RadioB6.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioB6.Name = "RadioB6"
        Me.RadioB6.Size = New System.Drawing.Size(104, 21)
        Me.RadioB6.TabIndex = 10
        Me.RadioB6.TabStop = True
        Me.RadioB6.Text = "Bentley 600"
        Me.RadioB6.UseVisualStyleBackColor = True
        '
        'RadioDelta600
        '
        Me.RadioDelta600.AutoSize = True
        Me.RadioDelta600.Location = New System.Drawing.Point(216, 10)
        Me.RadioDelta600.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioDelta600.Name = "RadioDelta600"
        Me.RadioDelta600.Size = New System.Drawing.Size(90, 21)
        Me.RadioDelta600.TabIndex = 11
        Me.RadioDelta600.TabStop = True
        Me.RadioDelta600.Text = "Delta 600"
        Me.RadioDelta600.UseVisualStyleBackColor = True
        '
        'FormControlMuestrasDuplicadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 322)
        Me.Controls.Add(Me.RadioDelta600)
        Me.Controls.Add(Me.RadioB6)
        Me.Controls.Add(Me.RadioBentley)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ButtonProcesar)
        Me.Controls.Add(Me.TextArchivo)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents RadioB6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDelta600 As System.Windows.Forms.RadioButton
End Class
