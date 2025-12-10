

Public Class pIniaAvisoControl
    Inherits Conectoras.ConexionMySQL
    '------------------------------------------------------------------
    '   GUARDAR
    '   Inserta un nuevo registro en IniaAvisoControl.
    '   Asume que campo "id" es AUTOINCREMENT en la tabla.
    '------------------------------------------------------------------
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dIniaAvisoControl = CType(o, dIniaAvisoControl)
        Dim lista As New ArrayList()

        Dim sql As String = "INSERT INTO IniaAvisoControl (MatriculaId, EmpresaId, Mes, Anio, FechaRegistro) VALUES (" &
                            obj.MATRICULAID & ", " & obj.EMPRESAID & ", " & obj.MES & ", " & obj.ANIO & ", '" &
                            obj.FECHAREGISTRO.ToString("yyyy-MM-dd HH:mm:ss") & "')"

        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function


    '------------------------------------------------------------------
    '   MODIFICAR
    '------------------------------------------------------------------
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dIniaAvisoControl = CType(o, dIniaAvisoControl)
        Dim lista As New ArrayList()

        Dim sql As String = "UPDATE IniaAvisoControl SET " &
                            "MatriculaId = " & obj.MATRICULAID & ", " &
                            "EmpresaId = " & obj.EMPRESAID & ", " &
                            "Mes = " & obj.MES & ", " &
                            "Anio = " & obj.ANIO & ", " &
                            "FechaRegistro = '" & obj.FECHAREGISTRO.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                            "WHERE id = " & obj.ID

        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function


    '------------------------------------------------------------------
    '   ELIMINAR
    '------------------------------------------------------------------
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dIniaAvisoControl = CType(o, dIniaAvisoControl)
        Dim lista As New ArrayList()

        Dim sql As String = "DELETE FROM IniaAvisoControl WHERE id = " & obj.ID
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function


    '------------------------------------------------------------------
    '   BUSCAR POR ID
    '------------------------------------------------------------------
    Public Function buscar(ByVal id As Long) As dIniaAvisoControl
        Dim sql As String = "SELECT id, MatriculaId, EmpresaId, Mes, Anio, FechaRegistro " &
                            "FROM IniaAvisoControl WHERE id = " & id
        Try
            Dim ds As DataSet = EjecutarSQL(sql)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Dim fila As DataRow = ds.Tables(0).Rows(0)
                Dim obj As New dIniaAvisoControl
                obj.ID = fila.Item("id")
                obj.MATRICULAID = fila.Item("MatriculaId")
                obj.EMPRESAID = fila.Item("EmpresaId")
                obj.MES = fila.Item("Mes")
                obj.ANIO = fila.Item("Anio")
                obj.FECHAREGISTRO = fila.Item("FechaRegistro")
                Return obj
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error en buscar IniaAvisoControl: " & ex.Message)
            Return Nothing
        End Try
    End Function


    '------------------------------------------------------------------
    '   LISTAR TODOS
    '------------------------------------------------------------------
    Public Function listar() As ArrayList
        Dim listaResultado As New ArrayList
        Dim sql As String = "SELECT id FROM IniaAvisoControl ORDER BY Anio DESC, Mes DESC, FechaRegistro DESC"
        Try
            Dim ds As DataSet = EjecutarSQL(sql)
            If ds.Tables.Count > 0 Then
                For Each fila As DataRow In ds.Tables(0).Rows
                    Dim obj As dIniaAvisoControl = buscar(fila.Item("id"))
                    If obj IsNot Nothing Then listaResultado.Add(obj)
                Next
            End If
        Catch ex As Exception
            MsgBox("Error listando IniaAvisoControl: " & ex.Message)
        End Try
        Return listaResultado
    End Function


    '------------------------------------------------------------------
    '   EXISTE MES
    '   Devuelve True si ya existe un registro para la misma MatriculaId en Mes/Anio
    '   Útil para evitar duplicados y disparar el aviso solo una vez por mes.
    '------------------------------------------------------------------
    Public Function existeMes(ByVal matriculaId As Long, ByVal mes As Integer, ByVal anio As Integer) As Boolean
        Dim sql As String = "SELECT id FROM IniaAvisoControl WHERE MatriculaId = " & matriculaId &
                            " AND Mes = " & mes & " AND Anio = " & anio & " LIMIT 1"
        Try
            Dim ds As DataSet = EjecutarSQL(sql)
            Return (ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0)
        Catch ex As Exception
            MsgBox("Error en existeMes IniaAvisoControl: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function ExisteRegistroMes(ByVal ClienteId As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As Boolean
        Dim sql As String = ""

        sql &= "SELECT CASE WHEN EXISTS(" &
               "   SELECT 1 " &
               "   FROM IniaAvisoControl iac " &
               "   WHERE iac.Mes = " & Mes & " AND iac.Anio = " & Anio & " " &
               "   AND (" &
               "       (iac.EmpresaId = " & ClienteId & " AND (SELECT tipousuario FROM Cliente WHERE id = " & ClienteId & ") = 2)" &
               "       OR " &
               "       (iac.MatriculaId = " & ClienteId & " AND iac.EmpresaId = (SELECT idempresa FROM ProductorEmpresa WHERE idproductor = " & ClienteId & "))" &
               "   )" &
               "   AND EXISTS (" &
               "       SELECT 1 FROM solicitudanalisis sa" &
               "       JOIN nuevoanalisis na ON na.ficha = sa.id" &
               "       WHERE sa.idproductor = " & ClienteId &
               "       AND sa.idtipoinforme = 10 " &
               "       AND na.analisis IN (SELECT analisisid FROM IniaAnalisisPermitidos WHERE permitido = 1 AND activo = 1)" &
               "   )" &
               ") THEN 1 ELSE 0 END AS Existe"

        Dim tabla As DataSet = EjecutarSQL(sql)

        If tabla IsNot Nothing AndAlso tabla.Tables.Count > 0 AndAlso tabla.Tables(0).Rows.Count > 0 Then
            Return CInt(tabla.Tables(0).Rows(0).Item(0)) = 1
        End If

        Return False
    End Function



End Class
