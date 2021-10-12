<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeFrascosEnviados
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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Año = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Mes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rc_compos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Agua = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sangre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Esteriles = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Otros = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(12, 19)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(94, 20)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(112, 19)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(94, 20)
        Me.DateHasta.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(212, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Listar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Año, Me.Mes, Me.Rc_compos, Me.Agua, Me.Sangre, Me.Esteriles, Me.Otros})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 47)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(357, 319)
        Me.DataGridView1.TabIndex = 3
        '
        'Año
        '
        Me.Año.HeaderText = "Año"
        Me.Año.Name = "Año"
        Me.Año.Width = 50
        '
        'Mes
        '
        Me.Mes.HeaderText = "Mes"
        Me.Mes.Name = "Mes"
        Me.Mes.Width = 50
        '
        'Rc_compos
        '
        Me.Rc_compos.HeaderText = "Rc_compos"
        Me.Rc_compos.Name = "Rc_compos"
        Me.Rc_compos.Width = 50
        '
        'Agua
        '
        Me.Agua.HeaderText = "Agua"
        Me.Agua.Name = "Agua"
        Me.Agua.Width = 50
        '
        'Sangre
        '
        Me.Sangre.HeaderText = "Sangre"
        Me.Sangre.Name = "Sangre"
        Me.Sangre.Width = 50
        '
        'Esteriles
        '
        Me.Esteriles.HeaderText = "Esteriles"
        Me.Esteriles.Name = "Esteriles"
        Me.Esteriles.Width = 50
        '
        'Otros
        '
        Me.Otros.HeaderText = "Otros"
        Me.Otros.Name = "Otros"
        Me.Otros.Width = 50
        '
        'FormInformeFrascosEnviados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 378)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormInformeFrascosEnviados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frascos Enviados"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Año As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rc_compos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agua As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sangre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Esteriles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Otros As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
