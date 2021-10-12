<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClientesPorEmpresa
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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonAgregarEmpresa = New System.Windows.Forms.Button()
        Me.TextNombreEmpresa = New System.Windows.Forms.TextBox()
        Me.TextIdEmpresa = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(24, 87)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(106, 20)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(136, 87)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(106, 20)
        Me.DateHasta.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(260, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Listar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desde"
        '
        'ButtonAgregarEmpresa
        '
        Me.ButtonAgregarEmpresa.Location = New System.Drawing.Point(280, 36)
        Me.ButtonAgregarEmpresa.Name = "ButtonAgregarEmpresa"
        Me.ButtonAgregarEmpresa.Size = New System.Drawing.Size(124, 23)
        Me.ButtonAgregarEmpresa.TabIndex = 14
        Me.ButtonAgregarEmpresa.Text = "Seleccionar empresa"
        Me.ButtonAgregarEmpresa.UseVisualStyleBackColor = True
        '
        'TextNombreEmpresa
        '
        Me.TextNombreEmpresa.Location = New System.Drawing.Point(18, 36)
        Me.TextNombreEmpresa.Name = "TextNombreEmpresa"
        Me.TextNombreEmpresa.ReadOnly = True
        Me.TextNombreEmpresa.Size = New System.Drawing.Size(247, 20)
        Me.TextNombreEmpresa.TabIndex = 13
        '
        'TextIdEmpresa
        '
        Me.TextIdEmpresa.Location = New System.Drawing.Point(18, 12)
        Me.TextIdEmpresa.Name = "TextIdEmpresa"
        Me.TextIdEmpresa.ReadOnly = True
        Me.TextIdEmpresa.Size = New System.Drawing.Size(44, 20)
        Me.TextIdEmpresa.TabIndex = 15
        '
        'FormClientesPorEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 176)
        Me.Controls.Add(Me.TextIdEmpresa)
        Me.Controls.Add(Me.ButtonAgregarEmpresa)
        Me.Controls.Add(Me.TextNombreEmpresa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormClientesPorEmpresa"
        Me.Text = "FormClientesPorEmpresa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonAgregarEmpresa As System.Windows.Forms.Button
    Friend WithEvents TextNombreEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents TextIdEmpresa As System.Windows.Forms.TextBox
End Class
