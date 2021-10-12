<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudPAL
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
        Me.ListMatriculas = New System.Windows.Forms.ListBox
        Me.TextMatricula = New System.Windows.Forms.TextBox
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.TextId = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextVacas = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ListMatriculas
        '
        Me.ListMatriculas.FormattingEnabled = True
        Me.ListMatriculas.Location = New System.Drawing.Point(12, 88)
        Me.ListMatriculas.Name = "ListMatriculas"
        Me.ListMatriculas.Size = New System.Drawing.Size(167, 355)
        Me.ListMatriculas.TabIndex = 0
        '
        'TextMatricula
        '
        Me.TextMatricula.Location = New System.Drawing.Point(12, 62)
        Me.TextMatricula.Name = "TextMatricula"
        Me.TextMatricula.Size = New System.Drawing.Size(167, 20)
        Me.TextMatricula.TabIndex = 1
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(194, 62)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 3
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(194, 91)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 4
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(86, 22)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(95, 20)
        Me.DateFecha.TabIndex = 5
        '
        'TextVacas
        '
        Me.TextVacas.Location = New System.Drawing.Point(12, 22)
        Me.TextVacas.Name = "TextVacas"
        Me.TextVacas.Size = New System.Drawing.Size(68, 20)
        Me.TextVacas.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Vacas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha extracción"
        '
        'FormSolicitudPAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 455)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextVacas)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.TextMatricula)
        Me.Controls.Add(Me.ListMatriculas)
        Me.Name = "FormSolicitudPAL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListMatriculas As System.Windows.Forms.ListBox
    Friend WithEvents TextMatricula As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextVacas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
