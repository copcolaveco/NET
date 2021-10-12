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
        Me.SuspendLayout()
        '
        'ButtonProcesar
        '
        Me.ButtonProcesar.Location = New System.Drawing.Point(313, 144)
        Me.ButtonProcesar.Name = "ButtonProcesar"
        Me.ButtonProcesar.Size = New System.Drawing.Size(127, 31)
        Me.ButtonProcesar.TabIndex = 42
        Me.ButtonProcesar.Text = "Cargar valores medios"
        Me.ButtonProcesar.UseVisualStyleBackColor = True
        '
        'ButtonDelta600
        '
        Me.ButtonDelta600.Location = New System.Drawing.Point(12, 107)
        Me.ButtonDelta600.Name = "ButtonDelta600"
        Me.ButtonDelta600.Size = New System.Drawing.Size(111, 23)
        Me.ButtonDelta600.TabIndex = 46
        Me.ButtonDelta600.Text = "Delta 600"
        Me.ButtonDelta600.UseVisualStyleBackColor = True
        '
        'ButtonDelta400
        '
        Me.ButtonDelta400.Location = New System.Drawing.Point(12, 77)
        Me.ButtonDelta400.Name = "ButtonDelta400"
        Me.ButtonDelta400.Size = New System.Drawing.Size(111, 23)
        Me.ButtonDelta400.TabIndex = 45
        Me.ButtonDelta400.Text = "Delta 400"
        Me.ButtonDelta400.UseVisualStyleBackColor = True
        '
        'ButtonBentley
        '
        Me.ButtonBentley.Location = New System.Drawing.Point(12, 48)
        Me.ButtonBentley.Name = "ButtonBentley"
        Me.ButtonBentley.Size = New System.Drawing.Size(111, 23)
        Me.ButtonBentley.TabIndex = 44
        Me.ButtonBentley.Text = "Bentley"
        Me.ButtonBentley.UseVisualStyleBackColor = True
        '
        'TextBentley
        '
        Me.TextBentley.Location = New System.Drawing.Point(129, 50)
        Me.TextBentley.Name = "TextBentley"
        Me.TextBentley.Size = New System.Drawing.Size(311, 20)
        Me.TextBentley.TabIndex = 43
        '
        'TextDelta400
        '
        Me.TextDelta400.Location = New System.Drawing.Point(129, 80)
        Me.TextDelta400.Name = "TextDelta400"
        Me.TextDelta400.Size = New System.Drawing.Size(311, 20)
        Me.TextDelta400.TabIndex = 47
        '
        'TextDelta600
        '
        Me.TextDelta600.Location = New System.Drawing.Point(129, 107)
        Me.TextDelta600.Name = "TextDelta600"
        Me.TextDelta600.Size = New System.Drawing.Size(311, 20)
        Me.TextDelta600.TabIndex = 48
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(12, 12)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(111, 20)
        Me.DateFecha.TabIndex = 49
        '
        'FormValoresMediosBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 185)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextDelta600)
        Me.Controls.Add(Me.TextDelta400)
        Me.Controls.Add(Me.ButtonDelta600)
        Me.Controls.Add(Me.ButtonDelta400)
        Me.Controls.Add(Me.ButtonBentley)
        Me.Controls.Add(Me.TextBentley)
        Me.Controls.Add(Me.ButtonProcesar)
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
End Class
