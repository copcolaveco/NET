Imports System.Text

Public Class pControlInformesDetalle
    Inherits Conectoras.ConexionMySQL

    'Public Function listar_informes_gestor_con_controladores(
    'ByVal desde As String,
    'ByVal hasta As String,
    'ByVal filtroEstado As String,
    'ByVal incluirFQ As Boolean,
    'ByVal incluirMicro As Boolean,
    'ByVal incluirSuelos As Boolean,
    'ByVal incluirNutricion As Boolean,
    'ByVal incluirEfluentes As Boolean) As ArrayList

    '    Dim sql As New StringBuilder()
    '    Dim tablas As New List(Of String)

    '    If incluirFQ Then tablas.Add("controlinformesfq")
    '    If incluirMicro Then tablas.Add("controlinformesmicro")
    '    If incluirSuelos Then tablas.Add("controlinformessuelos")
    '    If incluirNutricion Then tablas.Add("controlinformesnutricion")
    '    If incluirEfluentes Then tablas.Add("controlinformesefluentes")

    '    Dim contadorPartes As Integer = 0

    '    ' SUBIDOS
    '    If filtroEstado = "SUBIDO" Or filtroEstado = "AMBOS" Then
    '        For Each tabla As String In tablas
    '            If contadorPartes > 0 Then sql.Append(" UNION ALL ")

    '            sql.Append("SELECT sa.id AS ficha, ")
    '            sql.Append("c.nombre AS cliente, ")
    '            sql.Append("ti.nombre AS tipoinforme, ")
    '            sql.Append("DATE_FORMAT(ctab.fechacontrol, '%d/%m/%Y') AS fechaingreso, ")
    '            sql.Append("'SUBIDO' AS estado, ")
    '            sql.Append("CASE WHEN ctab.controlado = 1 THEN 'SI' ELSE 'NO' END AS Controlado, ")
    '            sql.Append("IFNULL(u.nombre, '') AS controlador, ")
    '            sql.Append("IFNULL(sub.nombre, '') AS subtipo, ")
    '            sql.Append("IFNULL(m.nombre, '') AS muestra, ")
    '            sql.Append("IFNULL(ctab.resultado, '') AS resultado, ")
    '            sql.Append("IFNULL(ctab.coincide, '') AS coincide, ")
    '            sql.Append("IFNULL(ctab.opcionmejora, '') AS om, ")
    '            sql.Append("IFNULL(ctab.noconformidad, '') AS nc, ")
    '            sql.Append("IFNULL(ctab.observaciones, '') AS observaciones ")
    '            sql.Append("FROM solicitudanalisis sa ")
    '            sql.Append("INNER JOIN cliente c ON c.id = sa.idproductor ")
    '            sql.Append("INNER JOIN tipoinforme ti ON ti.id = sa.idtipoinforme ")
    '            sql.Append("INNER JOIN " & tabla & " ctab ON ctab.ficha = sa.id AND ctab.controlado = 1 ")
    '            sql.Append("LEFT JOIN usuario u ON u.id = ctab.controlador ")
    '            sql.Append("LEFT JOIN subtiposdeinformes sub ON sub.id = sa.idsubinforme ")
    '            sql.Append("LEFT JOIN muestra m ON m.id = sa.idmuestra ")
    '            sql.Append("WHERE sa.marca = 1 ")
    '            sql.Append("AND ctab.fechacontrol BETWEEN '" & desde & "' AND '" & hasta & "' ")

    '            contadorPartes += 1
    '        Next
    '    End If

    '    ' PENDIENTES
    '    If filtroEstado = "PENDIENTE" Or filtroEstado = "AMBOS" Then
    '        For Each tabla As String In tablas
    '            If contadorPartes > 0 Then sql.Append(" UNION ALL ")

    '            sql.Append("SELECT sa.id AS ficha, ")
    '            sql.Append("c.nombre AS cliente, ")
    '            sql.Append("ti.nombre AS tipoinforme, ")
    '            sql.Append("DATE_FORMAT(sa.fechaingreso, '%d/%m/%Y') AS fechaingreso, ")
    '            sql.Append("'PENDIENTE' AS estado, ")
    '            sql.Append("'' AS Controlado, ")
    '            sql.Append("'' AS controlador, ")
    '            sql.Append("IFNULL(sub.nombre, '') AS subtipo, ")
    '            sql.Append("IFNULL(m.nombre, '') AS muestra, ")
    '            sql.Append("'' AS resultado, ")
    '            sql.Append("'' AS coincide, ")
    '            sql.Append("IFNULL(ctab.opcionmejora, '') AS om, ")
    '            sql.Append("IFNULL(ctab.noconformidad, '') AS nc, ")
    '            sql.Append("'' AS observaciones ")
    '            sql.Append("FROM solicitudanalisis sa ")
    '            sql.Append("INNER JOIN cliente c ON c.id = sa.idproductor ")
    '            sql.Append("INNER JOIN tipoinforme ti ON ti.id = sa.idtipoinforme ")
    '            sql.Append("LEFT JOIN " & tabla & " ctab ON ctab.ficha = sa.id ")
    '            sql.Append("LEFT JOIN subtiposdeinformes sub ON sub.id = sa.idsubinforme ")
    '            sql.Append("LEFT JOIN muestra m ON m.id = sa.idmuestra ")
    '            sql.Append("WHERE (sa.marca = 0 OR ctab.controlado = 0) ")
    '            sql.Append("AND sa.fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "' ")

    '            contadorPartes += 1
    '        Next
    '    End If

    '    sql.Append(" ORDER BY fechaingreso DESC")

    '    Try
    '        Dim lista As New ArrayList
    '        Dim Ds As New DataSet
    '        Ds = Me.EjecutarSQL(sql.ToString())

    '        For Each fila As DataRow In Ds.Tables(0).Rows
    '            Dim i As New dInformeGestor
    '            i.FICHA = CType(fila.Item("ficha"), Long)
    '            i.FECHAINGRESO = CType(fila.Item("fechaingreso"), String)
    '            i.CLIENTE = CType(fila.Item("cliente"), String)
    '            i.TIPOINFORME = CType(fila.Item("tipoinforme"), String)
    '            i.ESTADO = CType(fila.Item("estado"), String)
    '            i.CONTROLADO = CType(fila.Item("Controlado"), String)
    '            i.CONTROLADOR = CType(fila.Item("controlador"), String)
    '            i.SUBTIPO = CType(fila.Item("subtipo"), String)
    '            i.MUESTRA = CType(fila.Item("muestra"), String)
    '            Dim resultadoBytes() As Byte = CType(fila.Item("resultado"), Byte())
    '            Dim coincideBytes() As Byte = CType(fila.Item("coincide"), Byte())
    '            Dim omBytes() As Byte = CType(fila.Item("om"), Byte())
    '            Dim ncBytes() As Byte = CType(fila.Item("nc"), Byte())

    '            i.RESULTADO = Convert.ToInt32(System.Text.Encoding.Default.GetString(resultadoBytes))
    '            i.COINCIDE = Convert.ToInt32(System.Text.Encoding.Default.GetString(coincideBytes))
    '            i.OM = Convert.ToInt32(System.Text.Encoding.Default.GetString(omBytes))
    '            i.NC = Convert.ToInt32(System.Text.Encoding.Default.GetString(ncBytes))

    '            i.OBSERVACIONES = CType(fila.Item("observaciones"), String)
    '            lista.Add(i)
    '        Next

    '        Return lista

    '    Catch ex As Exception
    '        MsgBox("Error: " & ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    Public Function GenerarConsultaControlInformesDetalleExtendida(
     ByVal fechaDesde As String,
     ByVal fechaHasta As String,
     ByVal estado As String,
     ByVal sector As String,
     ByVal controlador As String,
     ByVal tipoInforme As String,
    ByVal ficha As String
 ) As ArrayList

        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT")
        sb.AppendLine("  distinct(sa.id) AS ficha,")
        sb.AppendLine("  ci.id AS id,")
        sb.AppendLine("  ci.fechacontrol AS fechaingreso,")
        sb.AppendLine("  COALESCE(")
        sb.AppendLine("    (SELECT nombre FROM usuario WHERE id = (SELECT controlador FROM controlinformesfq WHERE ficha = sa.id LIMIT 1)),")
        sb.AppendLine("    (SELECT nombre FROM usuario WHERE id = (SELECT controlador FROM controlinformesmicro WHERE ficha = sa.id LIMIT 1)),")
        sb.AppendLine("    (SELECT nombre FROM usuario WHERE id = (SELECT controlador FROM controlinformessuelos WHERE ficha = sa.id LIMIT 1)),")
        sb.AppendLine("    (SELECT nombre FROM usuario WHERE id = (SELECT controlador FROM controlinformesnutricion WHERE ficha = sa.id LIMIT 1)),")
        sb.AppendLine("    (SELECT nombre FROM usuario WHERE id = (SELECT controlador FROM controlinformesefluentes WHERE ficha = sa.id LIMIT 1)),")
        sb.AppendLine("    ''")
        sb.AppendLine("  ) AS controlador,")
        sb.AppendLine("  ti.nombre AS tipoinforme,")
        sb.AppendLine("  sub.nombre AS subtipo,")
        sb.AppendLine("  m.nombre AS muestra,")
        sb.AppendLine("  ci.observaciones,")
        sb.AppendLine("  ci.resultado,")
        sb.AppendLine("  ci.coincide,")
        sb.AppendLine("  ci.opcionmejora AS om,")
        sb.AppendLine("  ci.noconformidad AS nc,")
        sb.AppendLine("  c.nombre AS cliente,")
        sb.AppendLine("  sec.nombre AS sector,")
        sb.AppendLine("  ci.controlado AS controladoDir,")
        sb.AppendLine("  CASE")

        ' Filtro por estado y fechas
        Dim filtroFechaYControlador As String = " AND fechacontrol BETWEEN '" & fechaDesde & "' AND '" & fechaHasta & "'"
        If Not String.IsNullOrEmpty(controlador) Then
            filtroFechaYControlador += " AND controlador = '" & controlador & "'"
        End If

        sb.AppendLine("    WHEN EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ") THEN 'Si'")
        sb.AppendLine("    WHEN EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ") THEN 'Si'")
        sb.AppendLine("    WHEN EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ") THEN 'Si'")
        sb.AppendLine("    WHEN EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ") THEN 'Si'")
        sb.AppendLine("    WHEN EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ") THEN 'Si'")
        sb.AppendLine("    ELSE 'No'")
        sb.AppendLine("  END AS controlado")
        sb.AppendLine("FROM controldeinformes ci")
        sb.AppendLine("INNER JOIN solicitudanalisis sa ON sa.id = ci.ficha")
        sb.AppendLine("INNER JOIN nuevoanalisis na ON na.ficha = sa.id")
        sb.AppendLine("INNER JOIN sector_tipoinforme san ON san.tipo_informe_id = na.tipoinforme")
        sb.AppendLine("INNER JOIN muestra m ON m.id = sa.idmuestra")
        sb.AppendLine("INNER JOIN tipoinforme ti ON ti.id = ci.tipo")
        sb.AppendLine("INNER JOIN subtiposdeinformes sub ON sub.id = ci.subtipo")
        sb.AppendLine("INNER JOIN usuario u ON u.id = ci.controlador")
        sb.AppendLine("INNER JOIN cliente c ON c.id = sa.idproductor")
        sb.AppendLine("INNER JOIN sectores sec ON sec.id = san.sector_id")

        sb.AppendLine("WHERE 1=1")

        ' Filtro por ficha
        If Not String.IsNullOrEmpty(ficha) Then
            sb.AppendLine("AND sa.id = '" & ficha & "'")
        End If

        ' Filtro por sector
        If Not String.IsNullOrEmpty(sector) Then
            sb.AppendLine("AND san.sector_id = '" & sector & "'")
        End If

        ' Filtro por tipo de informe
        If Not String.IsNullOrEmpty(tipoInforme) Then
            sb.AppendLine("AND ci.tipo = '" & tipoInforme & "'")
        End If

        Select Case estado.ToUpper().Trim()
            Case "SUBIDO"
                sb.AppendLine("AND sa.marca = 1")
                sb.AppendLine("AND (")
                sb.AppendLine("    EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(")")
            Case "PENDIENTE"
                sb.AppendLine("AND sa.marca = 1")
                sb.AppendLine("AND (")
                sb.AppendLine("    EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(")")
            Case "AMBOS"
                sb.AppendLine("AND (")
                sb.AppendLine("    EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(")")
        End Select

        sb.AppendLine("ORDER BY ci.fechacontrol DESC")

        Try
            Dim lista As New ArrayList()
            Dim Ds As New DataSet()
            Ds = Me.EjecutarSQL(sb.ToString())

            For Each fila As DataRow In Ds.Tables(0).Rows
                Dim i As New dInformeGestor()
                i.ID = CType(fila.Item("id"), Long)
                i.FICHA = CType(fila.Item("ficha"), Long)
                i.FECHAINGRESO = CType(fila.Item("fechaingreso"), String)
                i.CLIENTE = CType(fila.Item("cliente"), String)
                i.TIPOINFORME = CType(fila.Item("tipoinforme"), String)
                i.ESTADO = estado
                i.CONTROLADOR = CType(fila.Item("controlador"), String)
                i.SUBTIPO = CType(fila.Item("subtipo"), String)
                i.MUESTRA = CType(fila.Item("muestra"), String)
                i.RESULTADO = CType(fila.Item("resultado"), String)
                i.COINCIDE = CType(fila.Item("coincide"), String)
                i.OM = CType(fila.Item("om"), String)
                i.NC = CType(fila.Item("nc"), String)
                i.OBSERVACIONES = CType(fila.Item("observaciones"), String)
                i.SECTOR = CType(fila.Item("sector"), String)
                i.Controlado = CType(fila.Item("controlado"), String)
                i.ControladoDir = CType(fila.Item("controladoDir"), Long)
                lista.Add(i)
            Next

            Return lista

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function GenerarResumenInformesPorSectorYTipo(
    ByVal fechaDesde As String,
    ByVal fechaHasta As String,
    ByVal estado As String,
    ByVal sector As String,
    ByVal controlador As String,
    ByVal tipoInforme As String,
    ByVal ficha As String
) As DataTable

        Dim sb As New StringBuilder()

        sb.AppendLine("SELECT")
        sb.AppendLine("  sec.nombre AS sector,")
        sb.AppendLine("  ti.nombre AS tipoinforme,")
        sb.AppendLine("  COUNT(DISTINCT sa.id) AS cantidad")
        sb.AppendLine("FROM controldeinformes ci")
        sb.AppendLine("INNER JOIN solicitudanalisis sa ON sa.id = ci.ficha")
        sb.AppendLine("INNER JOIN nuevoanalisis na ON na.ficha = sa.id")
        sb.AppendLine("INNER JOIN sector_tipoinforme san ON san.tipo_informe_id = na.tipoinforme")
        sb.AppendLine("INNER JOIN muestra m ON m.id = sa.idmuestra")
        sb.AppendLine("INNER JOIN tipoinforme ti ON ti.id = ci.tipo")
        sb.AppendLine("INNER JOIN subtiposdeinformes sub ON sub.id = ci.subtipo")
        sb.AppendLine("INNER JOIN usuario u ON u.id = ci.controlador")
        sb.AppendLine("INNER JOIN cliente c ON c.id = sa.idproductor")
        sb.AppendLine("INNER JOIN sectores sec ON sec.id = san.sector_id")
        sb.AppendLine("WHERE 1=1")

        ' Filtro por ficha
        If Not String.IsNullOrEmpty(ficha) Then
            sb.AppendLine("AND ci.ficha = '" & ficha & "'")
        End If

        ' Filtro por sector
        If Not String.IsNullOrEmpty(sector) Then
            sb.AppendLine("AND san.sector_id = '" & sector & "'")
        End If

        ' Filtro por tipo de informe
        If Not String.IsNullOrEmpty(tipoInforme) Then
            sb.AppendLine("AND ci.tipo = '" & tipoInforme & "'")
        End If

        ' Filtro por controlador
        Dim filtroFechaYControlador As String = " AND fechacontrol BETWEEN '" & fechaDesde & "' AND '" & fechaHasta & "'"
        If Not String.IsNullOrEmpty(controlador) Then
            filtroFechaYControlador += " AND controlador = '" & controlador & "'"
        End If

        ' Filtro por estado
        Select Case estado.ToUpper().Trim()
            Case "SUBIDO"
                sb.AppendLine("AND sa.marca = 1")
                sb.AppendLine("AND (")
                sb.AppendLine("    EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 1" & filtroFechaYControlador & ")")
                sb.AppendLine(")")
            Case "PENDIENTE"
                sb.AppendLine("AND sa.marca = 1")
                sb.AppendLine("AND (")
                sb.AppendLine("    EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 0" & filtroFechaYControlador & ")")
                sb.AppendLine(")")
            Case "AMBOS"
                sb.AppendLine("AND (")
                sb.AppendLine("    EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(" OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id" & filtroFechaYControlador & ")")
                sb.AppendLine(")")
        End Select

        sb.AppendLine("GROUP BY sec.nombre, ti.nombre")
        sb.AppendLine("ORDER BY sec.nombre, ti.nombre")

        Try
            Dim Ds As DataSet = Me.EjecutarSQL(sb.ToString())
            Return Ds.Tables(0)
        Catch ex As Exception
            MsgBox("Error al generar resumen: " & ex.Message)
            Return Nothing
        End Try
    End Function

End Class
