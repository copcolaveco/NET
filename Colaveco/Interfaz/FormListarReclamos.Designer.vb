<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListarReclamos
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboFuente = New System.Windows.Forms.ComboBox
        Me.ComboCategoria = New System.Windows.Forms.ComboBox
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.ComboTipo = New System.Windows.Forms.ComboBox
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Fuente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Categoría"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Tipo"
        '
        'ComboFuente
        '
        Me.ComboFuente.FormattingEnabled = True
        Me.ComboFuente.Items.AddRange(New Object() {"Detección interna", "Cliente", "Auditoría", "Otro"})
        Me.ComboFuente.Location = New System.Drawing.Point(71, 109)
        Me.ComboFuente.Name = "ComboFuente"
        Me.ComboFuente.Size = New System.Drawing.Size(121, 21)
        Me.ComboFuente.TabIndex = 21
        '
        'ComboCategoria
        '
        Me.ComboCategoria.FormattingEnabled = True
        Me.ComboCategoria.Items.AddRange(New Object() {"Acreditado", "Administración", "Laboratorio", "IT", "Otro"})
        Me.ComboCategoria.Location = New System.Drawing.Point(71, 82)
        Me.ComboCategoria.Name = "ComboCategoria"
        Me.ComboCategoria.Size = New System.Drawing.Size(121, 21)
        Me.ComboCategoria.TabIndex = 20
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(71, 29)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(121, 20)
        Me.DateDesde.TabIndex = 19
        '
        'ComboTipo
        '
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Items.AddRange(New Object() {"Reclamo", "No conformidad", "Comunicación", "Sugerencia"})
        Me.ComboTipo.Location = New System.Drawing.Point(71, 55)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(121, 21)
        Me.ComboTipo.TabIndex = 18
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(198, 29)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(121, 20)
        Me.DateHasta.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Desde"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(198, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Hasta"
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(244, 150)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 29
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'FormListarReclamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 194)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboFuente)
        Me.Controls.Add(Me.ComboCategoria)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.ComboTipo)
        Me.Name = "FormListarReclamos"
        Me.Text = "Listar reclamos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboFuente As System.Windows.Forms.ComboBox
    Friend WithEvents ComboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
End Class
