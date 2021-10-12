<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNoticias
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
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListNoticias = New System.Windows.Forms.ListBox()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.NumericMes = New System.Windows.Forms.NumericUpDown()
        Me.NumericDia = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckDiaria = New System.Windows.Forms.CheckBox()
        CType(Me.NumericMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(90, 18)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(54, 20)
        Me.TextId.TabIndex = 0
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(90, 44)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(295, 60)
        Me.TextDescripcion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(186, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha en la que se mostrará la noticia"
        '
        'ListNoticias
        '
        Me.ListNoticias.BackColor = System.Drawing.SystemColors.Info
        Me.ListNoticias.FormattingEnabled = True
        Me.ListNoticias.Location = New System.Drawing.Point(402, 18)
        Me.ListNoticias.Name = "ListNoticias"
        Me.ListNoticias.Size = New System.Drawing.Size(347, 433)
        Me.ListNoticias.TabIndex = 7
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(86, 260)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 8
        Me.ButtonNuevo.Text = "Nueva"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(167, 260)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 9
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(248, 260)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 10
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'NumericMes
        '
        Me.NumericMes.Location = New System.Drawing.Point(90, 142)
        Me.NumericMes.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericMes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericMes.Name = "NumericMes"
        Me.NumericMes.Size = New System.Drawing.Size(71, 20)
        Me.NumericMes.TabIndex = 11
        Me.NumericMes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericDia
        '
        Me.NumericDia.Location = New System.Drawing.Point(90, 168)
        Me.NumericDia.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.NumericDia.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericDia.Name = "NumericDia"
        Me.NumericDia.Size = New System.Drawing.Size(71, 20)
        Me.NumericDia.TabIndex = 12
        Me.NumericDia.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Mes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Día"
        '
        'CheckDiaria
        '
        Me.CheckDiaria.AutoSize = True
        Me.CheckDiaria.Location = New System.Drawing.Point(90, 211)
        Me.CheckDiaria.Name = "CheckDiaria"
        Me.CheckDiaria.Size = New System.Drawing.Size(82, 17)
        Me.CheckDiaria.TabIndex = 15
        Me.CheckDiaria.Text = "Aviso Diario"
        Me.CheckDiaria.UseVisualStyleBackColor = True
        '
        'FormNoticias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 469)
        Me.Controls.Add(Me.CheckDiaria)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericDia)
        Me.Controls.Add(Me.NumericMes)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ListNoticias)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormNoticias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Noticias"
        CType(Me.NumericMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListNoticias As System.Windows.Forms.ListBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents NumericMes As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericDia As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckDiaria As System.Windows.Forms.CheckBox
End Class
