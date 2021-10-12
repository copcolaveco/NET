<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPaquetes
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboTipoInforme = New System.Windows.Forms.ComboBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agregar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.Id3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quitar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Descripcion})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 57)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(236, 247)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Paquete"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 225
        '
        'ComboTipoInforme
        '
        Me.ComboTipoInforme.FormattingEnabled = True
        Me.ComboTipoInforme.Location = New System.Drawing.Point(12, 30)
        Me.ComboTipoInforme.Name = "ComboTipoInforme"
        Me.ComboTipoInforme.Size = New System.Drawing.Size(179, 21)
        Me.ComboTipoInforme.TabIndex = 1
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Descripcion2, Me.Agregar})
        Me.DataGridView2.Location = New System.Drawing.Point(254, 57)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(339, 247)
        Me.DataGridView2.TabIndex = 2
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id2"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Descripcion2
        '
        Me.Descripcion2.HeaderText = "Analisis"
        Me.Descripcion2.Name = "Descripcion2"
        Me.Descripcion2.Width = 225
        '
        'Agregar
        '
        Me.Agregar.HeaderText = ""
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseColumnTextForButtonValue = True
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id3, Me.Descripcion3, Me.Quitar})
        Me.DataGridView3.Location = New System.Drawing.Point(599, 57)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.Size = New System.Drawing.Size(339, 247)
        Me.DataGridView3.TabIndex = 3
        '
        'Id3
        '
        Me.Id3.HeaderText = "Id3"
        Me.Id3.Name = "Id3"
        Me.Id3.Visible = False
        '
        'Descripcion3
        '
        Me.Descripcion3.HeaderText = "Analisis"
        Me.Descripcion3.Name = "Descripcion3"
        Me.Descripcion3.Width = 225
        '
        'Quitar
        '
        Me.Quitar.HeaderText = ""
        Me.Quitar.Name = "Quitar"
        Me.Quitar.Text = "Quitar"
        Me.Quitar.UseColumnTextForButtonValue = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo de informe"
        '
        'FormPaquetes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 342)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.ComboTipoInforme)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormPaquetes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paquetes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agregar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Id3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quitar As System.Windows.Forms.DataGridViewButtonColumn
End Class
