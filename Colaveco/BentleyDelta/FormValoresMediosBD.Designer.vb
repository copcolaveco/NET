<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormValoresMediosBD
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
        Me.ButtonDelta600 = New System.Windows.Forms.Button()
        Me.ButtonDelta400 = New System.Windows.Forms.Button()
        Me.ButtonBentley = New System.Windows.Forms.Button()
        Me.TextBentley = New System.Windows.Forms.TextBox()
        Me.TextDelta400 = New System.Windows.Forms.TextBox()
        Me.TextDelta600 = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.ButtonB6 = New System.Windows.Forms.Button()
        Me.TextB6 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonProcesar
        '
        Me.ButtonProcesar.Location = New System.Drawing.Point(416, 247)
        Me.ButtonProcesar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonProcesar.Name = "ButtonProcesar"
        Me.ButtonProcesar.Size = New System.Drawing.Size(169, 38)
        Me.ButtonProcesar.TabIndex = 42
        Me.ButtonProcesar.Text = "Cargar valores medios"
        Me.ButtonProcesar.UseVisualStyleBackColor = True
        '
        'ButtonDelta600
        '
        Me.ButtonDelta600.Location = New System.Drawing.Point(15, 131)
        Me.ButtonDelta600.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDelta600.Name = "ButtonDelta600"
        Me.ButtonDelta600.Size = New System.Drawing.Size(148, 28)
        Me.ButtonDelta600.TabIndex = 46
        Me.ButtonDelta600.Text = "Delta 600"
        Me.ButtonDelta600.UseVisualStyleBackColor = True
        '
        'ButtonDelta400
        '
        Me.ButtonDelta400.Location = New System.Drawing.Point(15, 170)
        Me.ButtonDelta400.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDelta400.Name = "ButtonDelta400"
        Me.ButtonDelta400.Size = New System.Drawing.Size(148, 28)
        Me.ButtonDelta400.TabIndex = 45
        Me.ButtonDelta400.Text = "Delta 400"
        Me.ButtonDelta400.UseVisualStyleBackColor = True
        Me.ButtonDelta400.Visible = False
        '
        'ButtonBentley
        '
        Me.ButtonBentley.Location = New System.Drawing.Point(16, 59)
        Me.ButtonBentley.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonBentley.Name = "ButtonBentley"
        Me.ButtonBentley.Size = New System.Drawing.Size(148, 28)
        Me.ButtonBentley.TabIndex = 44
        Me.ButtonBentley.Text = "Bentley"
        Me.ButtonBentley.UseVisualStyleBackColor = True
        '
        'TextBentley
        '
        Me.TextBentley.Location = New System.Drawing.Point(172, 62)
        Me.TextBentley.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBentley.Name = "TextBentley"
        Me.TextBentley.Size = New System.Drawing.Size(413, 22)
        Me.TextBentley.TabIndex = 43
        '
        'TextDelta400
        '
        Me.TextDelta400.Location = New System.Drawing.Point(171, 173)
        Me.TextDelta400.Margin = New System.Windows.Forms.Padding(4)
        Me.TextDelta400.Name = "TextDelta400"
        Me.TextDelta400.Size = New System.Drawing.Size(413, 22)
        Me.TextDelta400.TabIndex = 47
        Me.TextDelta400.Visible = False
        '
        'TextDelta600
        '
        Me.TextDelta600.Location = New System.Drawing.Point(171, 131)
        Me.TextDelta600.Margin = New System.Windows.Forms.Padding(4)
        Me.TextDelta600.Name = "TextDelta600"
        Me.TextDelta600.Size = New System.Drawing.Size(413, 22)
        Me.TextDelta600.TabIndex = 48
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(16, 15)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(147, 22)
        Me.DateFecha.TabIndex = 49
        '
        'ButtonB6
        '
        Me.ButtonB6.Location = New System.Drawing.Point(15, 95)
        Me.ButtonB6.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonB6.Name = "ButtonB6"
        Me.ButtonB6.Size = New System.Drawing.Size(148, 28)
        Me.ButtonB6.TabIndex = 51
        Me.ButtonB6.Text = "Bentley600"
        Me.ButtonB6.UseVisualStyleBackColor = True
        '
        'TextB6
        '
        Me.TextB6.Location = New System.Drawing.Point(171, 98)
        Me.TextB6.Margin = New System.Windows.Forms.Padding(4)
        Me.TextB6.Name = "TextB6"
        Me.TextB6.Size = New System.Drawing.Size(413, 22)
        Me.TextB6.TabIndex = 50
        '
        'FormValoresMediosBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 298)
        Me.Controls.Add(Me.ButtonB6)
        Me.Controls.Add(Me.TextB6)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextDelta600)
        Me.Controls.Add(Me.TextDelta400)
        Me.Controls.Add(Me.ButtonDelta600)
        Me.Controls.Add(Me.ButtonDelta400)
        Me.Controls.Add(Me.ButtonBentley)
        Me.Controls.Add(Me.TextBentley)
        Me.Controls.Add(Me.ButtonProcesar)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormValoresMediosBD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valores Medios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonProcesar As System.Windows.Forms.Button
    Friend WithEvents ButtonDelta600 As System.Windows.Forms.Button
    Friend WithEvents ButtonDelta400 As System.Windows.Forms.Button
    Friend WithEvents ButtonBentley As System.Windows.Forms.Button
    Friend WithEvents TextBentley As System.Windows.Forms.TextBox
    Friend WithEvents TextDelta400 As System.Windows.Forms.TextBox
    Friend WithEvents TextDelta600 As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonB6 As System.Windows.Forms.Button
    Friend WithEvents TextB6 As System.Windows.Forms.TextBox
End Class
