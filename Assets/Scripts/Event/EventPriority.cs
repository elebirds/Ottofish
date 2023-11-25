public enum EventPriority : int
{
    /**
     * LOWEST级别
     * 事件调用的重要性最低，应该首先运行，以允许其他监听器进一步自定义结果
    */
    LOWEST,
    /**
     * LOWEST级别
     * 事件调用的重要性低
     */
    LOW,
    /**
     * NORMAL级别
     * 事件调用一般重要，一般来说正常就选此级别。
     */
    NORMAL,
    /**
     * HIGH级别
     * 事件调用的重要性搞
     */
    HIGH,
    /**
     * HIGHEST级别
     * 事件调用至关重要，必须对事件发生的情况拥有最终发言权
     */
    HIGHEST,
    /**
     * MONITOR级别
     * 此级别纯粹是为了监视事件的结果/UI更新。在此优先级下，不应对事件进行任何修改。
     */
    MONITOR
}

