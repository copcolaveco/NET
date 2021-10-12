Public Class pMedios
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMedios = CType(o, dMedios)
        Dim sql As String = "INSERT INTO medios (endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, nitrato, nitrito, dureza) VALUES ('" & obj.ENDO35 & "', '" & obj.MFC44_5 & "', '" & obj.CENTRIMIDE37 & "', '" & obj.MHPC & "', '" & obj.AGUADEDILUCION & "', '" & obj.NITRATO & "', '" & obj.NITRITO & "', '" & obj.DUREZA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'medios', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMedios = CType(o, dMedios)
        Dim sql As String = "UPDATE medios SET endo35 = '" & obj.ENDO35 & "', mfc44_5 = '" & obj.MFC44_5 & "', centrimide37 = '" & obj.CENTRIMIDE37 & "', mhpc = '" & obj.MHPC & "', aguadedilucion = '" & obj.AGUADEDILUCION & "', nitrato = '" & obj.NITRATO & "', nitrito = '" & obj.NITRITO & "', dureza = '" & obj.DUREZA & "' "

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'medios', 'modificación', " & obj.ENDO35 & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function buscar(ByVal o As Object) As dMedios
        Dim obj As dMedios = CType(o, dMedios)
        Dim m As New dMedios
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ifnull(nitrato,''), ifnull(nitrito,''), ifnull(dureza,'') FROM medios")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ENDO35 = CType(unaFila.Item(0), String)
                m.MFC44_5 = CType(unaFila.Item(1), String)
                m.CENTRIMIDE37 = CType(unaFila.Item(2), String)
                m.MHPC = CType(unaFila.Item(3), String)
                m.AGUADEDILUCION = CType(unaFila.Item(4), String)
                m.NITRATO = CType(unaFila.Item(5), String)
                m.NITRITO = CType(unaFila.Item(6), String)
                m.DUREZA = CType(unaFila.Item(7), String)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT endo35, mfc44_5, centrimide37, mhpc, aguadedilucion, ifnull(nitrato,''), ifnull(nitrito,''), ifnull(dureza,'') FROM medios"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMedios
                    m.ENDO35 = CType(unaFila.Item(0), String)
                    m.MFC44_5 = CType(unaFila.Item(1), String)
                    m.CENTRIMIDE37 = CType(unaFila.Item(2), String)
                    m.MHPC = CType(unaFila.Item(3), String)
                    m.AGUADEDILUCION = CType(unaFila.Item(4), String)
                    m.NITRATO = CType(unaFila.Item(5), String)
                    m.NITRITO = CType(unaFila.Item(6), String)
                    m.DUREZA = CType(unaFila.Item(7), String)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    End Class
